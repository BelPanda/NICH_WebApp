using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NICH_WebApp.Models
{
    public class SRW
    {
        public int IdSWR { get; set; }
        public string NumSRW { get; set; }
        public string FullNameSRW { get; set; }
        public string Type { get; set; }
        public DateTime B_DateTime { get; set; }
        public DateTime? E_DateTime { get; set; }
        public string NameDirection { get; set; }
        public string ShortName { get; set; }
        public string ExecutorName { get; set; }
    }


    public class SRWDataAccessLayer
    {
        private IConfiguration configuration;

        private string connectionString;

        public SRWDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //To View all employees details

        public IEnumerable<SRW> GetAllSRW(bool isAll = false)
        {

            try
            {
                List<SRW> listSRW = new List<SRW>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[n_GetAllSRWWithExec]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlParameter isAllParameter = new SqlParameter("all", SqlDbType.Bit);
                    isAllParameter.Value = isAll;
                    cmd.Parameters.Add(isAllParameter);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SRW srw = new SRW();
                        srw.IdSWR = Convert.ToInt32(reader["IdSWR"]);
                        srw.NumSRW = reader["NumSRW"].ToString();
                        srw.FullNameSRW = reader["FullNameSRW"].ToString();
                        srw.Type = reader["Type"].ToString();
                        srw.B_DateTime = reader.GetDateTime(reader.GetOrdinal("B_DateTime"));
                        //srw.E_DateTime = reader.GetDateTime(reader.GetOrdinal("E_DateTime"));
                        srw.NameDirection = reader["NameDirection"].ToString();
                        srw.ShortName = reader["ShortName"].ToString();
                        srw.ExecutorName = reader["ExecutorName"].ToString();

                        listSRW.Add(srw);
                    }

                    con.Close();
                }

                return listSRW;
            }
            catch
            {
                throw;
            }
        }
    }
}