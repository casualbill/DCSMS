using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System;

namespace DCSMS.DAL
{
    public class DBHelper
    {
        // 建立数据库连接
        protected MySqlConnection getMySqlConnection()
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
            return mySqlConnection;
        }

        public void executeSqlCommandNoQuery(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                sqlCon.Close();
                sqlCon.Dispose();
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

        public MySqlDataReader executeSqlCommandDataReader(string sqlCommandStr)
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

        public DataSet executeSqlCommandDataSet(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommandStr, sqlCon);
                DataSet ds = new DataSet();
                sqlAdapter.Fill(ds);
                sqlAdapter.Dispose();
                sqlCon.Close();
                sqlCon.Dispose();
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