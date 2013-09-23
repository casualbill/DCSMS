using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System;

namespace DCSMS.DAL
{
    public class DBHelper
    {
        // 建立数据库连接
        private MySqlConnection getMySqlConnection()
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
            return mySqlConnection;
        }

        protected int executeSqlCommandNoQuery(string sqlCommandStr)
        {
            return executeSqlCommandNoQuery(sqlCommandStr, null);
        }

        protected int executeSqlCommandNoQuery(string sqlCommandStr, MySqlParameter[] paramArray)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);

                if (paramArray.Length > 0)
                {
                    foreach (MySqlParameter param in paramArray)
                    {
                        sqlCommand.Parameters.Add(param);
                    }
                }
                int num = Convert.ToInt16(sqlCommand.ExecuteNonQuery());
                sqlCommand.Dispose();
                return num;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        protected String executeSqlCommandScalar(String sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                String str = sqlCommand.ExecuteScalar().ToString();
                sqlCommand.Dispose();
                return str;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        protected MySqlDataReader executeSqlCommandDataReader(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                sqlCon.Open();
                MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
                sqlCommand.Dispose();
                return sqlReader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        protected DataSet executeSqlCommandDataSet(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommandStr, sqlCon);
                DataSet ds = new DataSet();
                sqlAdapter.Fill(ds);
                sqlAdapter.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
    }
}