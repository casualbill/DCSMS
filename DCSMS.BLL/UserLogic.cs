using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using DCSMS.DAL;
using System.Data;

namespace DCSMS.BLL
{
    public class UserLogic
    {
        protected UserDB userDb = new UserDB();

        //新建用户  返回： -1用户已存在，0失败，1成功
        public int createUser(String userName, String password, int userType)
        {
            if (userDb.checkUserExist(userName) != "0")
            {
                return -1;
            }
            else
            {
                String encryptedPwd = getMD5HashCode(password);
                return userDb.createUser(userName, encryptedPwd, userType);
            }
        }

        //验证用户登录并返回用户信息
        public String[] validateUserLogin(String userName, String password)
        {
            String[] userInfoStr = new String[5];
            String encryptedPwd = getMD5HashCode(password);
            if (userDb.validateUserLogin(userName, encryptedPwd) == "1")
            {
                DataRow dr = userDb.userQueryByUserName(userName).Tables[0].Rows[0];
                for (int i = 0; i < 4; i++)
                {
                    userInfoStr[i] = dr[i].ToString();
                }

            }
            return userInfoStr;
        }

        //用户查询
        public DataTable userQueryByUserNameVaguely(String queryStr)
        {
            DataSet ds = userDb.userQueryByUserNameVaguely(queryStr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("UserTypeStr", Type.GetType("System.String"));

                int index = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    switch (dr["UserType"].ToString())
                    {
                        case "1": ds.Tables[0].Rows[index]["UserTypeStr"] = "Guest"; break;
                        case "2": ds.Tables[0].Rows[index]["UserTypeStr"] = "Technician"; break;
                        case "3": ds.Tables[0].Rows[index]["UserTypeStr"] = "Admin"; break;
                        case "4": ds.Tables[0].Rows[index]["UserTypeStr"] = "Manager"; break;
                        case "5": ds.Tables[0].Rows[index]["UserTypeStr"] = "Super Manager"; break;
                    }
                    index++;
                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //加密密码 （MD5 Hash32位截取16）
        //test删除后改为private！！！！！！
        public String getMD5HashCode(String sourceStr)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(sourceStr, "MD5").ToLower().Substring(8, 16);
        }
    }
}
