using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NICH_WebApp.Models
{
    public class Organization
    {
        public int IdOrganization { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
    public class OrganizationDataAccessLayer 
    {
        private IConfiguration configuration;

        private string connectionString;

        public OrganizationDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public IEnumerable<Organization> GetOrganization()
        {
            try
            {
                List<Organization> organizations = new List<Organization>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[nir].[Organization_List]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Organization org = new Organization();
                        org.IdOrganization = Convert.ToInt32(reader["IdOrganization"]);
                        org.FullName = reader["FullName"].ToString();
                        org.ShortName = reader["ShortName"].ToString();

                        organizations.Add(org);
                    }
                    con.Close();
                }
                return organizations;
            }
            catch
            {
                throw;
            }
        }
    }
}
