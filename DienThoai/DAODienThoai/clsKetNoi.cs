using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace DAODienThoai
{
    public class clsKetNoi
    {
        String cnStr;
        SqlConnection cn;
        public clsKetNoi()
        {
            cnStr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            cn = new SqlConnection(cnStr);
        }

        private void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void DisConnect()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
        }

        public SqlDataReader ExcuteReader(string sql)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int ExecuteNonQuery(string sql, CommandType Type, List<SqlParameter> paras)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = Type;
                if (paras != null)
                {
                    foreach (SqlParameter para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
            
        }
    }
}
