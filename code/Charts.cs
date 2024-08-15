using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.code
{
    public class Charts
    {
        public Charts() { }

        DataSet ds=new DataSet();

        public DataSet GetChartData(string query, bool isSP)
        {
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = sql;
                if (isSP)
                    cmd.CommandType = CommandType.StoredProcedure;
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }

           
        }
    }
}