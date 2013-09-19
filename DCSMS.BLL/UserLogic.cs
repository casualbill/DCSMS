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

        //加密密码 （MD5 Hash32位截取16）
        private String getMD5HashCode(String sourceStr)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(sourceStr, "MD5").ToLower().Substring(8, 16);
        }
    }
}
