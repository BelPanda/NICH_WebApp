using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NICH_WebApp.Models
{
    public class SRWStaffSchedule
    {
        public int IdSnir { get; set; }
        public DateTime DateS { get; set; }
        public string NumSRW { get; set; }
        public int IdDeptE { get; set; }
        public int? IDSmeta { get; set; }
        public int? IdArticle { get; set; }
        public DateTime? B_DateTimeE { get; set; }
        public decimal? Fact1 { get; set; }
        public decimal? Fact2 { get; set; }
        public decimal? Distr { get; set; }
        public decimal? ISumma { get; set; }
        public decimal? FOTSm { get; set; }
        public bool? State { get; set; }
        public DateTime? DateSE { get; set; }
        public DateTime? DateSE_F { get; set; }
        public decimal? Indexsation { get; set; }
        public int? PersonHours { get; set; }
    }


    public class SRWStaffScheduleDataAccessLayer
    {
        private IConfiguration configuration;

        private string connectionString;

        public SRWStaffScheduleDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //To View all employees details

        public IEnumerable<SRWStaffSchedule> GetSRWStaffSchedule(int idSrw, int idDept)
        {

            try
            {
                List<SRWStaffSchedule> listSRW = new List<SRWStaffSchedule>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[nir].[DateStaffNir]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlParameter idSrwParameter = new SqlParameter("IdSrw", SqlDbType.Int);
                    idSrwParameter.Value = idSrw;

                    SqlParameter idDeptParameter = new SqlParameter("IdDept", SqlDbType.Int);
                    idDeptParameter.Value = idDept;

                    cmd.Parameters.Add(idSrwParameter);
                    cmd.Parameters.Add(idDeptParameter);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SRWStaffSchedule srwStaffSchedule = new SRWStaffSchedule();
                        srwStaffSchedule.IdSnir = Convert.ToInt32(reader["IdSnir"]);
                        srwStaffSchedule.DateS = reader.GetDateTime(reader.GetOrdinal("DateS"));
                        srwStaffSchedule.NumSRW = reader["NumSRW"].ToString();
                        srwStaffSchedule.IdDeptE = Convert.ToInt32(reader["IdDeptE"]);

                        int i = reader.GetOrdinal("IDSmeta");

                        if (reader.IsDBNull(i))
                            srwStaffSchedule.IDSmeta = null;
                        else
                            srwStaffSchedule.IDSmeta = reader.GetInt32(i);

                        i = reader.GetOrdinal("IdArticle");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.IdArticle = null;
                        else
                            srwStaffSchedule.IdArticle = reader.GetInt32(i);

                        i = reader.GetOrdinal("B_DateTimeE");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.B_DateTimeE = null;
                        else
                            srwStaffSchedule.B_DateTimeE = reader.GetDateTime(i);

                        i = reader.GetOrdinal("Fact1");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.Fact1 = null;
                        else
                            srwStaffSchedule.Fact1 = reader.GetDecimal(i);

                        i = reader.GetOrdinal("Fact2");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.Fact2 = null;
                        else
                            srwStaffSchedule.Fact2 = reader.GetDecimal(i);

                        i = reader.GetOrdinal("Distr");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.Distr = null;
                        else
                            srwStaffSchedule.Distr = reader.GetDecimal(i);

                        i = reader.GetOrdinal("ISumma");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.ISumma = null;
                        else
                            srwStaffSchedule.ISumma = reader.GetDecimal(i);

                        i = reader.GetOrdinal("State");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.State = null;
                        else
                            srwStaffSchedule.State = reader.GetBoolean(i);

                        i = reader.GetOrdinal("DateSE");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.DateSE = null;
                        else
                            srwStaffSchedule.DateSE = reader.GetDateTime(i);

                        i = reader.GetOrdinal("FOTSm");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.FOTSm = null;
                        else
                            srwStaffSchedule.FOTSm = reader.GetDecimal(i);

                        i = reader.GetOrdinal("DateSE_F");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.DateSE_F = null;
                        else
                            srwStaffSchedule.DateSE_F = reader.GetDateTime(i);

                        i = reader.GetOrdinal("Indexsation");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.Indexsation = null;
                        else
                            srwStaffSchedule.Indexsation = reader.GetDecimal(i);

                        i = reader.GetOrdinal("PersonHours");
                        if (reader.IsDBNull(i))
                            srwStaffSchedule.PersonHours = null;
                        else
                            srwStaffSchedule.PersonHours = reader.GetInt32(i);

                        listSRW.Add(srwStaffSchedule);
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
