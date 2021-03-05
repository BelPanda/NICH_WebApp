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
        public int IdDept { get; set; }
    }

    public class ListSRW
    {
        public int IdSWR { get; set; }
        public string NumSRW { get; set; }
        public string FullNameSRW { get; set; }
        public int IdType { get; set; }
        public DateTime B_DateTime { get; set; }
        public DateTime? E_DateTime { get; set; }
        public int IdDirection { get; set; }
        public int IdOrganization { get; set; }
        public string BaseSRW { get; set; }
        public bool OtherFin { get; set; }
        public string BaseExec { get; set; }
        public string Phone { get; set; }
        public string SSheff { get; set; }
        public string OrdNum { get; set; }
        public DateTime OrdDate { get; set; }
        public string NomReg { get; set; }
        public short iTypeSub { get; set; }
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
                        if (!reader.IsDBNull(reader.GetOrdinal("E_DateTime")))
                        {
                            srw.E_DateTime = reader.GetDateTime(reader.GetOrdinal("E_DateTime"));
                        }
                        else
                        {
                            srw.E_DateTime = null;
                        }
                        srw.NameDirection = reader["NameDirection"].ToString();
                        srw.ShortName = reader["ShortName"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("ExecutorName")))
                        {
                            srw.ExecutorName = reader["ExecutorName"].ToString();
                        }
                        else
                        {
                            srw.ExecutorName = null;
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("IdDept")))
                        {
                            srw.IdDept = Convert.ToInt32(reader["IdDept"]);
                        }
                        else
                        {
                            srw.IdDept = 0;
                        }
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

        void ParamSet(SqlParameterCollection pSqlParameterCollection, string sParamName, int? iValue)
        {
            SqlParameter P = pSqlParameterCollection.Add(sParamName, SqlDbType.Int, 0);
            if (iValue == null || iValue == 0)
            {
                P.IsNullable = true;
                P.Value = DBNull.Value;
            }
            else
                P.Value = iValue;
        }
        void ParamSet(SqlParameterCollection pSqlParameterCollection, string sParamName, string sParamValue)
        {
            SqlParameter P = pSqlParameterCollection.Add(sParamName, SqlDbType.VarChar, 0);
            if (sParamValue == null || sParamValue.Trim().Length == 0)
            {
                P.IsNullable = true;
                P.Value = DBNull.Value;
            }
            else
            {
                sParamValue = sParamValue.Trim();
                P.Size = sParamValue.Length;
                P.Value = sParamValue;
            }
        }
        void ParamSet(SqlParameterCollection pSqlParameterCollection, string sParamName, DateTime? iValue)
        {
            SqlParameter P = pSqlParameterCollection.Add(sParamName, SqlDbType.Date, 0);
            if (iValue == null)
            {
                P.IsNullable = true;
                P.Value = DBNull.Value;
            }
            else
                P.Value = iValue;
        }
        
        public bool UpdateSRW(ListSRW listSRW)
        {
            bool res = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand Q = new SqlCommand("[nir].[UpdateSRW]", connection)){
                        SqlParameterCollection PP = Q.Parameters;

                        ParamSet(PP, "@IdSWR", listSRW.IdSWR);
                        ParamSet(PP, "@NumSRW", listSRW.NumSRW);
                        ParamSet(PP, "@FullNameSRW", listSRW.FullNameSRW);
                        ParamSet(PP, "@IdType", listSRW.IdType);
                        ParamSet(PP, "@B_DateTime", listSRW.B_DateTime);
                        ParamSet(PP, "@E_DateTime", listSRW.E_DateTime);
                        ParamSet(PP, "@IdDirection", listSRW.IdDirection);
                        ParamSet(PP, "@IdOrganization", listSRW.IdOrganization);
                        ParamSet(PP, "@BaseSRW", listSRW.BaseSRW);
                        PP.Add("@OtherFin", SqlDbType.Bit).Value = listSRW.OtherFin;
                        ParamSet(PP, "@BaseExec", listSRW.BaseExec);
                        ParamSet(PP, "@Phone", listSRW.Phone);
                        ParamSet(PP, "@SSheff", listSRW.SSheff);
                        ParamSet(PP, "@OrdNum", listSRW.OrdNum);
                        ParamSet(PP, "@OrdDate", listSRW.OrdDate);
                        ParamSet(PP, "@NomReg", listSRW.NomReg);
                        ParamSet(PP, "@iTypeSub", listSRW.iTypeSub);
                        Q.ExecuteNonQuery();
                        Q.Dispose();
                    }
                }
            }
            catch (SqlException ex)
            {
                Exception ex2 = new Exception(ex.Message);
                throw (ex2);
            }
            return res;
        }
    }
}