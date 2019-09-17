using FlightSystemProject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbGeneratorWpf
{
    class AirlineDb
    {
        public string name { get; set; }

        public void Add(List<AirlineDb> companies)
        {
            foreach (AirlineDb item in companies)
            {
                using (SqlConnection conn = new SqlConnection(FlightSystemCFG.CONNECTION_FLIGHT_DB))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"Insert Into AirlineCompanies(AIRLINE_NAME) Values ('{item.name}')", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
