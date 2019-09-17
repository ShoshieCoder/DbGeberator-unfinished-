using FlightSystemProject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbGeneratorWpf
{
    public class AdminDb
    {
        public string username { get; set; }
        public string password { get; set; }

        public void Add(List<AdminDb> customers)
        {
            foreach (AdminDb item in customers)
            {
                using (SqlConnection conn = new SqlConnection(FlightSystemCFG.CONNECTION_FLIGHT_DB))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"Insert Into Administrators(USER_NAME, PASSWORD) Values" +
                        $"{item.username},{item.password}", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
