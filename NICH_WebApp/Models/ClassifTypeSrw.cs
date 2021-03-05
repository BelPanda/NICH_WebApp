using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NICH_WebApp.Models
{
    public class ClassifTypeSrw
    {
        public int IdType { get; set; }
        public int IdBT { get; set; }
        public string NameBT { get; set; }
        public int IdTypeSRW { get; set; }
        public string NameSRW { get; set; }
        public string Name { get; set; }
    }

    public class ClassifTypeSrwDataAccessLayer
    {
        private IConfiguration configuration;
        
        private string connectionString;

        public ClassifTypeSrwDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ClassifTypeSrw> GetClassifTypeSrw()
        {
            try
            {
                List<ClassifTypeSrw> typeSrwTypeSRW = new List<ClassifTypeSrw>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[nir].[ClassifSRW_List]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassifTypeSrw typeSrw = new ClassifTypeSrw();
                        typeSrw.NameBT = reader["NameBT"].ToString();
                        typeSrw.IdType = Convert.ToInt32(reader["IdType"]);
                        typeSrw.NameSRW = reader["NameSRW"].ToString();
                        typeSrw.IdBT = Convert.ToInt32(reader["IdBT"]);
                        typeSrw.Name = reader["Name"].ToString();
                        typeSrw.IdTypeSRW = Convert.ToInt32(reader["IdTypeSRW"]);

                        typeSrwTypeSRW.Add(typeSrw);
                    }
                    con.Close();
                }
                return typeSrwTypeSRW;
            }
            catch
            {
                throw;
            }
        }
    }
}
