using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class UserDB : DBHelper
    {
        public int userCreate(String userName, String password, int userType)
        {
            String sqlCommand = "insert into userinfo (UserName, Password, UserType) values (@userName, @password, @userType)";
            MySqlParameter[] para = new MySqlParameter[3];

            para[0] = new MySqlParameter("@userName", userName);
            para[1] = new MySqlParameter("@password", password);
            para[2] = new MySqlParameter("@userType", userType);

            return executeSqlCommandNoQuery(sqlCommand, para);
        }

        public String checkUserExist(String userName)
        {
            String sqlCommand = "select count(*) from userinfo where UserName = '" + userName + "'";
            return executeSqlCommandScalar(sqlCommand);
        }

        public String validateUserLogin(String userName, String password)
        {
            String sqlCommand = "select count(*) from userinfo where UserName = '" + userName + "' and Password = '" + password + "'";
            return executeSqlCommandScalar(sqlCommand);
        }

        public int userUpdate(int id, String userName, int userType)
        {
            String sqlCommand = "update userinfo set UserName = '" + userName + "', UserType = " + userType + " where Id = " + id;
            return executeSqlCommandNoQuery(sqlCommand);
        }

        public DataSet userQueryByUserId(int id)
        {
            String sqlCommand = "select * from userinfo where Id = " + id;
            return executeSqlCommandDataSet(sqlCommand);
        }

        public DataSet userQueryByUserName(String userName)
        {
            String sqlCommand = "select * from userinfo where UserName = '" + userName + "'";
            return executeSqlCommandDataSet(sqlCommand);
        }

        public DataSet userQueryByUserNameVaguely(String userName)
        {
            String sqlCommand = "select * from userinfo where UserName like '%" + userName + "%'";
            return executeSqlCommandDataSet(sqlCommand);
        }

    }
}