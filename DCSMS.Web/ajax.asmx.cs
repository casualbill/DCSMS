﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web
{
    /// <summary>
    /// ajax 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class ajax : System.Web.Services.WebService
    {
        [WebMethod]
        public String userQuery(String queryStr, Boolean isTechnician)
        {
            UserLogic userLogic = new UserLogic();
            if (queryStr.Length < 1)
            {
                return "[]";
            }
            DataTable dt = userLogic.userQueryByUserNameVaguely(queryStr, isTechnician);
            String str = "[";
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str += "{";
                    str += "\"id\":" + dr["Id"] + ",";
                    str += "\"userName\":\"" + dr["UserName"] + "\"";
                    str += "},";
                }
                str = str.Substring(0, str.Length - 1);
            }
            str += "]";
            return str;
        }

        [WebMethod]
        public String customerQuery(String queryStr, Boolean isOnlyId)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            if (queryStr.Length < 1)
            {
                return "[]";
            }
            DataTable dt = customerLogic.customerQueryByCustomerNameVaguely(queryStr);
            String str = "[";
            if (dt != null)
            {
                if (isOnlyId == true)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        str += "{";
                        str += "\"id\":" + dr["Id"] + ",";
                        str += "\"customerName\":\"" + dr["CustomerName"] + "\"";
                        str += "},";
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        str += "{";
                        str += "\"id\":" + dr["Id"] + ",";
                        str += "\"customerName\":\"" + dr["CustomerName"] + "\",";
                        str += "\"endCustomerName\":\"" + dr["EndCustomerName"] + "\",";
                        str += "\"contactPerson\":\"" + dr["ContactPerson"] + "\",";
                        str += "\"telephone\":\"" + dr["Telephone"] + "\",";
                        str += "\"mobile\":\"" + dr["Mobile"] + "\",";
                        str += "\"address\":\"" + dr["Address"] + "\",";
                        str += "\"postcode\":\"" + dr["PostCode"] + "\"";
                        str += "},";
                    }
                }
                str = str.Substring(0, str.Length - 1);
            }
            str += "]";
            return str;
        }

        [WebMethod(EnableSession = true)]
        public int customerVerify(int id)
        {
            CustomerLogic customerLogic = new CustomerLogic();
            if (Session["userType"] == null) { return -2; }
            int userType = Convert.ToInt16(Session["userType"]);
            return customerLogic.customerVerify(id, userType);
        }

        [WebMethod]
        public String spraePartQuery(String orderId)
        {
            OrderLogic orderLogic = new OrderLogic();
            DataTable dt = orderLogic.sparePartQuery(orderId);
            String str = "[";
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str += "{";
                    str += "\"id\":" + dr["Id"] + ",";
                    str += "\"sparePartName\":\"" + dr["SparePartName"] + "\",";
                    str += "\"orderingNumber\":\"" + dr["OrderingNumber"] + "\",";
                    str += "\"amount\":\"" + dr["Amount"] + "\",";
                    str += "\"remark\":\"" + dr["Remark"] + "\"";
                    str += "},";
                }
                str = str.Substring(0, str.Length - 1);
            }
            str += "]";
            return str;
        }

        [WebMethod(EnableSession = true)]
        public int sparePartAdd(String sparePartName, String orderingNumber, int amount, String remark, String orderId)
        {
            OrderLogic orderLogic = new OrderLogic();
            int permissionFlag = orderLogic.orderOperatePermission(orderId, Convert.ToInt16(Session["userId"]), Convert.ToInt16(Session["userType"]));
            if (permissionFlag != 1) { return permissionFlag; }

            return orderLogic.sparePartAdd(sparePartName, orderingNumber, amount, remark, orderId);
        }

        [WebMethod(EnableSession = true)]
        public int sparePartUpdate(String sparePartName, String orderingNumber, int amount, String remark, String orderId, int id)
        {
            OrderLogic orderLogic = new OrderLogic();
            int permissionFlag = orderLogic.orderOperatePermission(orderId, Convert.ToInt16(Session["userId"]), Convert.ToInt16(Session["userType"]));
            if (permissionFlag != 1) { return permissionFlag; }

            return orderLogic.sparePartUpdate(sparePartName, orderingNumber, amount, remark, id);
        }

        [WebMethod(EnableSession = true)]
        public int sparePartRemove(String orderId, int id)
        {
            OrderLogic orderLogic = new OrderLogic();
            int permissionFlag = orderLogic.orderOperatePermission(orderId, Convert.ToInt16(Session["userId"]), Convert.ToInt16(Session["userType"]));
            if (permissionFlag != 1) { return permissionFlag; }

            return orderLogic.sparePartRemove(id);
        }
    }
}
