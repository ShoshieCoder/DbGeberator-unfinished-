using FlightSystemProject;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DbGeneratorWpf
{

    public class ViewModel:INotifyPropertyChanged
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();


        private int _countrynum;
        private int _airlinenum;
        private int _customernum;
        private int _adminnum;
        public int AdminNum { get {return _adminnum; } set {_adminnum = value; } }
        public int CustomerNum { get { return _customernum; } set { _customernum = value; } }
        public int ArilineNum { get { return _airlinenum; } set { _airlinenum = value; } }
        public int CountryNum { get { return _countrynum; } set { _countrynum = value; } }

        public DelegateCommand AddCommand { get; set; }

        CountryDb CountryAdd = new CountryDb();
        AirlineDb AirlineAdd = new AirlineDb();
        CustomerDb CustomerAdd = new CustomerDb();
        AdminDb AdminAdd = new AdminDb();

        private BackgroundWorker _bgWorker = new BackgroundWorker();
        private int _workerState;

        public event PropertyChangedEventHandler PropertyChanged;

        public int WorkerState { get { return _workerState; }
            set { _workerState = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("WorkerState"));
                }
            } }

        public ViewModel()
        {

            AddCommand = new DelegateCommand(() => {

                _bgWorker.DoWork += (s, e) =>
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        Thread.Sleep(50);
                        WorkerState = i;
                    }
                };

                _bgWorker.RunWorkerAsync();

                CountryAddMethod(); AirlineAddMethod(); CustomerAddMethod(); AdminAddMethod();


            }, 
                () => { return true; });

        }


        public void CountryAddMethod()
        {
            string json = new WebClient().DownloadString("https://restcountries.eu/rest/v2");
    
            List<CountryDb> countries = JsonConvert.DeserializeObject<List<CountryDb>>(json);
            List<CountryDb> partList = new List<CountryDb>();
            
            for(int i = 0; i < CountryNum; i++)
            {
                partList.Add(countries[i]);
            }

            CountryAdd.Add(partList);
        }

        public void AirlineAddMethod()
        {
            string json = new WebClient().DownloadString("https://raw.githubusercontent.com/BesrourMS/Airlines/master/airlines.json");

            List<AirlineDb> companies = JsonConvert.DeserializeObject<List<AirlineDb>>(json);
            List<AirlineDb> partList = new List<AirlineDb>();

            for (int i = 0; i < ArilineNum; i++)
            {
                partList.Add(companies[i]);
            }

            AirlineAdd.Add(partList);
        }

        public void CustomerAddMethod()
        {
            string json = new WebClient().DownloadString("https://raw.githubusercontent.com/pixelastic/fakeusers/master/data/final.json");

            List<CustomerDb> customers = JsonConvert.DeserializeObject<List<CustomerDb>>(json);
            List<CustomerDb> partList = new List<CustomerDb>();

            for (int i = 0; i < CustomerNum; i++)
            {
                partList.Add(customers[i]);
            }

            CustomerAdd.Add(partList);
        }

        public void AdminAddMethod()
        {
            string json = new WebClient().DownloadString("https://raw.githubusercontent.com/pixelastic/fakeusers/master/data/final.json");

            List<CustomerDb> admins = JsonConvert.DeserializeObject<List<CustomerDb>>(json);
            List<CustomerDb> partList = new List<CustomerDb>();

            for (int i = 0; i < AdminNum; i++)
            {
                partList.Add(admins[i]);
            }

            CustomerAdd.Add(partList);
        }
    }


}
