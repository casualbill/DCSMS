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
            String sqlCommand = "insert into userinfo (UserName, Password, UserType) values (@UserName, @Password, @UserType)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@UserName", userName));
            paramList.Add(new MySqlParameter("@Password", password));
            paramList.Add(new MySqlParameter("@UserType", userType));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public String checkUserExist(String userName)
        {
            String sqlCommand = "select count(*) from userinfo where UserName = @UserName";
            MySqlParameter param = new MySqlParameter("@UserName", userName);
            return executeSqlCommandScalar(sqlCommand, param);
        }

        public String validateUserLogin(String userName, String password)
        {
            String sqlCommand = "select count(*) from userinfo where UserName = @UserName and Password = @Password";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@UserName", userName));
            paramList.Add(new MySqlParameter("@Password", password));

            return executeSqlCommandScalar(sqlCommand, paramList);
        }

        public int userUpdate(int id, String userName, int userType)
        {
            String sqlCommand = "update userinfo set UserName = @UserName, UserType = @UserType where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@UserName", userName));
            paramList.Add(new MySqlParameter("@UserType", userType));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet userQueryByUserId(int id)
        {
            String sqlCommand = "select * from userinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByUserName(String userName)
        {
            String sqlCommand = "select * from userinfo where UserName = @UserName";
            MySqlParameter param = new MySqlParameter("@UserName", userName);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByUserNameVaguely(String userName)
        {
            String sqlCommand = "select * from userinfo where UserName like '%" + userName + "%'";
            return executeSqlCommandDataSet(sqlCommand);
        }

    }
}