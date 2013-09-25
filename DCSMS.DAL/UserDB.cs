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

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@userName", userName));
            paramList.Add(new MySqlParameter("@password", password));
            paramList.Add(new MySqlParameter("@userType", userType));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public String checkUserExist(String userName)
        {
            String sqlCommand = "select count(*) from userinfo where UserName = @userName";
            MySqlParameter param = new MySqlParameter("@userName", userName);
            return executeSqlCommandScalar(sqlCommand, param);
        }

        public String validateUserLogin(String userName, String password)
        {
            String sqlCommand = "select count(*) from userinfo where UserName = @userName and Password = @password";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@userName", userName));
            paramList.Add(new MySqlParameter("@password", password));

            return executeSqlCommandScalar(sqlCommand, paramList);
        }

        public int userUpdate(int id, String userName, int userType)
        {
            String sqlCommand = "update userinfo set UserName = @userName, UserType = @userType where Id = @id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@userName", userName));
            paramList.Add(new MySqlParameter("@userType", userType));
            paramList.Add(new MySqlParameter("@id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet userQueryByUserId(int id)
        {
            String sqlCommand = "select * from userinfo where Id = @id";
            MySqlParameter param = new MySqlParameter("@id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByUserName(String userName)
        {
            String sqlCommand = "select * from userinfo where UserName = @userName";
            MySqlParameter param = new MySqlParameter("@userName", userName);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByUserNameVaguely(String userName)
        {
            String sqlCommand = "select * from userinfo where UserName like '%" + userName + "%'";
            return executeSqlCommandDataSet(sqlCommand);
        }

    }
}