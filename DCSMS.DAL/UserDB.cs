using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DCSMS.DAL
{
    public class UserDB : DBHelper
    {
        public int createUser(String userName, String password, int userType)
        {
            String sqlCommand = "insert into userinfo (UserName, Password, UserType) values ('" + userName + "' , '" + password + "' , " + userType + ")";
            return executeSqlCommandNoQuery(sqlCommand);
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

        public int updateUser(String userName, String password, int userType)
        {
            String sqlCommand = "update userinfo set Password = '" + password + "' , UserType = " + userType;
            return executeSqlCommandNoQuery(sqlCommand);
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