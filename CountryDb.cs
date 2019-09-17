using FlightSystemProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DbGeneratorWpf
{
    public class CountryDb
    {

        public string name { get; set; }

        public void Add(List<CountryDb> countries)
        {
            foreach (CountryDb item in countries)
            {
                using (SqlConnection conn = new SqlConnection(FlightSystemCFG.CONNECTION_FLIGHT_DB))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"Insert Into Countries(COUNTRY_NAME) Values ('{item.name}')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
