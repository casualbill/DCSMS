using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

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

        // 执行MySqlCommand
        public void executeSqlCommandNoQuery(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            sqlCon.Open();
            MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlCon.Close();
            sqlCon.Dispose();
        }

        public MySqlDataReader executeSqlCommandDataReader(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            MySqlCommand sqlCommand = new MySqlCommand(sqlCommandStr, sqlCon);
            sqlCon.Open();
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlCommand.Dispose();
            sqlCon.Close();
            sqlCon.Dispose();
            return sqlReader;
        }

        public DataSet executeSqlCommandDataSet(string sqlCommandStr)
        {
            MySqlConnection sqlCon = this.getMySqlConnection();
            sqlCon.Open();
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommandStr, sqlCon);
            DataSet ds = new DataSet();
            sqlAdapter.Fill(ds);
            sqlAdapter.Dispose();
            sqlCon.Close();
            sqlCon.Dispose();
            return ds;
        }
    }
}