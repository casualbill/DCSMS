using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class DBHelper
    {
        // 建立数据库连接
        private MySqlConnection getMySqlConnection()
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            MySqlConnection mySqlConnection = new MySqlConnection(connectionStr);
            return mySqlConnection;
        }

        #region executeSqlCommandNoQuery
        protected int executeSqlCommandNoQuery(String sqlCommandStr)
        {
            List<MySqlParameter> paramList = null;
            return executeSqlCommandNoQuery(sqlCommandStr, paramList);
        }

        protected int executeSqlCommandNoQuery(String sqlCommandStr, MySqlParameter param)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(param);
            return executeSqlCommandNoQuery(sqlCommandStr, paramList);
        }

        protected int executeSqlCommandNoQuery(String sqlCommandStr, List<MySqlParameter> paramList)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                if (paramList.Count > 0)
                {
                    foreach (MySqlParameter param in paramList)
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
        #endregion



        #region executeSqlCommandScalar
        protected String executeSqlCommandScalar(String sqlCommandStr)
        {
            List<MySqlParameter> paramList = null;
            return executeSqlCommandScalar(sqlCommandStr, paramList);
        }

        protected String executeSqlCommandScalar(String sqlCommandStr, MySqlParameter param)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(param);
            return executeSqlCommandScalar(sqlCommandStr, paramList);
        }

        protected String executeSqlCommandScalar(String sqlCommandStr, List<MySqlParameter> paramList)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                if (paramList != null && paramList.Count > 0)
                {
                    foreach (MySqlParameter param in paramList)
                    {
                        sqlCommand.Parameters.Add(param);
                    }
                }
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
        #endregion



        #region executeSqlCommandDataReader
        protected MySqlDataReader executeSqlCommandDataReader(String sqlCommandStr)
        {
            List<MySqlParameter> paramList = null;
            return executeSqlCommandDataReader(sqlCommandStr, paramList);
        }

        protected MySqlDataReader executeSqlCommandDataReader(String sqlCommandStr, MySqlParameter param)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(param);
            return executeSqlCommandDataReader(sqlCommandStr, paramList);
        }

        protected MySqlDataReader executeSqlCommandDataReader(String sqlCommandStr, List<MySqlParameter> paramList)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                if (paramList != null && paramList.Count > 0)
                {
                    foreach (MySqlParameter param in paramList)
                    {
                        sqlCommand.Parameters.Add(param);
                    }
                }
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
        #endregion



        #region executeSqlCommandDataSet
        protected DataSet executeSqlCommandDataSet(String sqlCommandStr)
        {
            List<MySqlParameter> paramList = null;
            return executeSqlCommandDataSet(sqlCommandStr, paramList);
        }

        protected DataSet executeSqlCommandDataSet(String sqlCommandStr, MySqlParameter param)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(param);
            return executeSqlCommandDataSet(sqlCommandStr, paramList);
        }

        protected DataSet executeSqlCommandDataSet(String sqlCommandStr, List<MySqlParameter> paramList)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            try
            {
                sqlCon.Open();
                MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
                if (paramList != null && paramList.Count > 0)
                {
                    foreach (MySqlParameter param in paramList)
                    {
                        sqlCommand.Parameters.Add(param);
                    }
                }
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
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
        #endregion
    }
}