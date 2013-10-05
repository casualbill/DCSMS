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
        public int userCreate(List<String> userInfo, int userType)
        {
            String sqlCommand = "insert into userinfo  values (null, @UserName, @Password, @RealName, @EmpCode, @Telephone, @Email, @UserType)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@UserName", userInfo[0]));
            paramList.Add(new MySqlParameter("@Password", userInfo[1]));
            paramList.Add(new MySqlParameter("@RealName", userInfo[2]));
            paramList.Add(new MySqlParameter("@EmpCode", userInfo[3]));
            paramList.Add(new MySqlParameter("@Telephone", userInfo[4]));
            paramList.Add(new MySqlParameter("@Email", userInfo[5]));
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

        public int userUpdate(List<String> userInfo, int id, int userType)
        {
            String sqlCommand = "update userinfo set UserName = @UserName, RealName = @RealName, EmpCode = @EmpCode, Telephone = @Telephone, Email = @Email, UserType = @UserType where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@UserName", userInfo[0]));
            paramList.Add(new MySqlParameter("@RealName", userInfo[1]));
            paramList.Add(new MySqlParameter("@EmpCode", userInfo[2]));
            paramList.Add(new MySqlParameter("@Telephone", userInfo[3]));
            paramList.Add(new MySqlParameter("@Email", userInfo[4]));
            paramList.Add(new MySqlParameter("@UserType", userType));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet userQuery()
        {
            String sqlCommand = "select * from userinfo";
            return executeSqlCommandDataSet(sqlCommand);
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
            String sqlCommand = "select * from userinfo where UserName like @userName";
            MySqlParameter param = new MySqlParameter("@UserName", userName + "%");
            return executeSqlCommandDataSet(sqlCommand, param);
        }

    }
}