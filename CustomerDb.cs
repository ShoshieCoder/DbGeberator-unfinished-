using FlightSystemProject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbGeneratorWpf
{
    public class CustomerDb
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Location location { get; set; }
        public string phone_number { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public void Add(List<CustomerDb> customers)
        {
            foreach (CustomerDb item in customers)
            {
                using (SqlConnection conn = new SqlConnection(FlightSystemCFG.CONNECTION_FLIGHT_DB))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"Insert Into Customers(FIRST_NAME, LAST_NAME, USER_NAME, PASSWORD," +
                        $" ADDRESS, PHONE_NO) Values ('{item.first_name}','{item.last_name}','{item.username}','{item.password}'," +
                        $"'{item.location.city + item.location.street + item.location.state}','{item.phone_number}')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }



    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }


}
