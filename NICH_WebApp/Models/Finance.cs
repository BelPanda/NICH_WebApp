using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace NICH_WebApp.Models
{
    public class Finance
    {
        public int IdDirection { get; set; }
        public string NameDirection { get; set; }
    }
    public class FinanceDataAccessLayer
    {
        private IConfiguration configuration;

        private string connectionString;

        public FinanceDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public IEnumerable<Finance> GetFinance()
        {
            try
            {
                List<Finance> finances = new List<Finance>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[nir].[Finance_List]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Finance fin = new Finance();
                        fin.IdDirection = Convert.ToInt32(reader["IdDirection"]);
                        fin.NameDirection = reader["NameDirection"].ToString();

                        finances.Add(fin);
                    }
                    con.Close();
                }
                return finances;
            }
            catch
            {
                throw;
            }
        }
    }
}
