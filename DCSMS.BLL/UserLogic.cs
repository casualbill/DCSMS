using System;
using System.Collections.Generic;
using System.Data;
using DCSMS.DAL;

namespace DCSMS.BLL
{
    public class UserLogic : Utility
    {
        protected UserDB userDb = new UserDB();
        protected const int pageSize = 50;

        //新建用户  返回： -1用户已存在，0失败，1成功
        public int userCreate(List<String> userInfo, int userType)
        {
            if (userDb.checkUserExist(userInfo[0]) != "0")
            {
                return -1;
            }
            else
            {
                userInfo[1] = getMD5HashCode(userInfo[1]);
                return userDb.userCreate(userInfo, userType);
            }
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

        //用户查询（所有）
        public DataTable userQuery(int page, out int pageAmount)
        {
            int offset = (page - 1) * pageSize;
            int amount;
            DataSet ds = userDb.userQuery(offset, pageSize, out amount);
            pageAmount = amount / pageSize + 1;
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                return addUserStatusText(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        //用户查询 根据用户类别
        public DataTable userQueryByUserType(int userType)
        {
            DataSet ds = userDb.userQueryByUserType(userType);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //用户查询 根据用户名模糊查询 （包含技术员信息）
        public DataTable userQueryByUserNameVaguely(String queryStr, Boolean isTechnician)
        {
            DataSet ds = userDb.userQueryByUserNameVaguely(queryStr, isTechnician);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return addUserStatusText(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        //用户查询 根据用户名模糊查询 （包含技术员信息） 分页
        public DataTable userQueryByUserNameVaguely(String queryStr, Boolean isTechnician, int page, out int pageAmount)
        {
            int offset = (page - 1) * pageSize;
            int amount;
            DataSet ds = userDb.userQueryByUserNameVaguely(queryStr, isTechnician, offset, pageSize, out amount);
            pageAmount = amount / pageSize + 1;

            if (ds.Tables[0].Rows.Count > 0)
            {
                return addUserStatusText(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        //用户信息修改 返回：0失败，1成功
        public int userUpdate(List<String> userInfo, int id, int userType)
        {
            return userDb.userUpdate(userInfo, id, userType);
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


        //为用户表加入用户类型文字说明
        protected DataTable addUserStatusText(DataTable userTable)
        {
            userTable.Columns.Add("UserTypeStr", Type.GetType("System.String"));

            int index = 0;
            foreach (DataRow dr in userTable.Rows)
            {
                switch (dr["UserTypeStr"].ToString())
                {
                    case "1": userTable.Rows[index]["UserTypeStr"] = "Guest"; break;
                    case "2": userTable.Rows[index]["UserTypeStr"] = "Technician"; break;
                    case "3": userTable.Rows[index]["UserTypeStr"] = "Admin"; break;
                    case "4": userTable.Rows[index]["UserTypeStr"] = "Manager"; break;
                    case "5": userTable.Rows[index]["UserTypeStr"] = "Super Manager"; break;
                }
                index++;
            }
            return userTable;
        }
    }
}
