using System;
using System.Collections.Generic;
using DCSMS.DAL;
using System.Data;

namespace DCSMS.BLL
{
    public class UserLogic : Utility
    {
        protected UserDB userDb = new UserDB();

        //新建用户  返回： -1用户已存在，0失败，1成功
        public int userCreate(String userName, String password, int userType)
        {
            if (userDb.checkUserExist(userName) != "0")
            {
                return -1;
            }
            else
            {
                String encryptedPwd = getMD5HashCode(password);
                return userDb.userCreate(userName, encryptedPwd, userType);
            }
        }

        //新建技术员  返回： -1用户已存在，0失败，1成功
        public int engineerCreate(String userName, String password, String realName, String telephone, String email)
        {
            int retVal = userCreate(userName, password, 2);
            if (retVal != 1)
            {
                return retVal;
            }
            else
            {
                DataSet ds = userDb.userQueryByUserName(userName);
                int userId = Convert.ToInt16(ds.Tables[0].Rows[0]["Id"]);

                return userDb.engineerCreate(userId, realName, telephone, email);
            }
        }

        //技术员信息修改 返回：0失败，1成功
        public int engineerUpdate(int userId, String userName, String realName, String telephone, String email)
        {
            int retVal = userUpdate(userId, userName, 2);
            if (retVal != 1)
            {
                return retVal;
            }
            else
            {
                return userDb.engineerUpdate(userId, realName, telephone, email);
            }
        }

        //技术员查询 根据用户ID
        public List<String> engineerQueryByUserId(int userId)
        {
            DataRow dr = userDb.engineerQueryByUserId(userId).Tables[0].Rows[0];
            List<String> engineerInfo = new List<String>();
            foreach (Object obj in dr.ItemArray)
            {
                engineerInfo.Add(obj.ToString());
            }
            return engineerInfo;
        }

        //验证用户登录并返回用户信息
        public List<String> validateUserLogin(String userName, String password)
        {
            List<String> userInfoStr = new List<String>();
            String encryptedPwd = getMD5HashCode(password);
            if (userDb.validateUserLogin(userName, encryptedPwd) == "1")
            {
                DataRow dr = userDb.userQueryByUserName(userName).Tables[0].Rows[0];
                foreach (Object obj in dr.ItemArray)
                {
                    userInfoStr.Add(obj.ToString());
                }

            }
            return userInfoStr;
        }

        //用户查询 根据用户名模糊查询 （包含技术员信息）
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

        //用户信息修改 返回：0失败，1成功
        public int userUpdate(int id, String userName, int userType)
        {
            return userDb.userUpdate(id, userName, userType);
        }

        //用户查询 根据用户Id
        public List<String> userQueryByUserId(int id)
        {
            List<String> userInfoStr = new List<String>();
            DataRow dr = userDb.userQueryByUserId(id).Tables[0].Rows[0];
            foreach (Object obj in dr.ItemArray)
            {
                userInfoStr.Add(obj.ToString());
            }

            return userInfoStr;
        }

        //用户查询 根据用户名
        public List<String> userQueryByUserName(String userName)
        {
            List<String> userInfoStr = new List<String>();
            DataRow dr = userDb.userQueryByUserName(userName).Tables[0].Rows[0];
            foreach (Object obj in dr.ItemArray)
            {
                userInfoStr.Add(obj.ToString());
            }

            return userInfoStr;
        }
    }
}
