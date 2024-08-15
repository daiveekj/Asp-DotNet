using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace WebApplication1.code
{
    public class DBCalling
    {
        public DBCalling() { }


        public DataTable GetData(string query, bool isSP = true)
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
                    cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable GetCountryData(string query, bool isSP = true)
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
                    cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetDataState(string query, int index)
        {
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", index));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void AddMemberDetails(Parameters pR)
        {
            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AddMember";
            cmd.Connection = sql;
            cmd.CommandType = CommandType.StoredProcedure;

            List<SqlParameter> lstPar = new List<SqlParameter>();
            lstPar.Add(new SqlParameter("@name", pR.Name));
            lstPar.Add(new SqlParameter("@phnumber", pR.Number));
            lstPar.Add(new SqlParameter("@email", pR.Email));
            lstPar.Add(new SqlParameter("@aadharno", pR.AadhaarNo));
            lstPar.Add(new SqlParameter("@dateofjoining", pR.DOJ));
            lstPar.Add(new SqlParameter("@country", pR.Country));
            lstPar.Add(new SqlParameter("@state", pR.States));
            lstPar.Add(new SqlParameter("@floor", pR.Floor));
            lstPar.Add(new SqlParameter("@sharing", pR.Sharing));
            lstPar.Add(new SqlParameter("@price", pR.Price));
            lstPar.Add(new SqlParameter("@EmpId", pR.MemberId));

            foreach (SqlParameter p in lstPar)
            {
                cmd.Parameters.Add(p);
            }
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public void UpdateMemberDetails(Parameters pR)
        {
            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UpdateMember";
            cmd.Connection = sql;
            cmd.CommandType = CommandType.StoredProcedure;

            List<SqlParameter> lstPar = new List<SqlParameter>();
            lstPar.Add(new SqlParameter("@name", pR.Name));
            lstPar.Add(new SqlParameter("@phnumber", pR.Number));
            lstPar.Add(new SqlParameter("@email", pR.Email));
            lstPar.Add(new SqlParameter("@aadharno", pR.AadhaarNo));
            lstPar.Add(new SqlParameter("@dateofjoining", pR.DOJ));
            lstPar.Add(new SqlParameter("@country", pR.Country));
            lstPar.Add(new SqlParameter("@state", pR.States));
            lstPar.Add(new SqlParameter("@floor", pR.Floor));
            lstPar.Add(new SqlParameter("@sharing", pR.Sharing));
            lstPar.Add(new SqlParameter("@price", pR.Price));
            lstPar.Add(new SqlParameter("@MemberId", pR.MemberId));

            foreach (SqlParameter p in lstPar)
            {
                cmd.Parameters.Add(p);
            }
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public void DeleteMember(string query, int index)
        {
            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sql;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", index));
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }


        public DataSet CardData(string query, bool isSP)

        {

            try

            {

                DataSet Ds = new DataSet();

                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString);

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = query;

                cmd.Connection = sql;

                if (isSP)

                    cmd.CommandType = CommandType.StoredProcedure;

                else

                    cmd.CommandType = CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(Ds);

                return Ds;

            }

            catch (Exception ex)

            {

                return null;

            }
        }
            public bool IsValidCredentials(string username, string password)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PG"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("ValidateCredentials", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        command.Parameters.Add("@IsValid", SqlDbType.Bit).Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();

                        return Convert.ToBoolean(command.Parameters["@IsValid"].Value);
                    }
                }
            }

        }

    }

