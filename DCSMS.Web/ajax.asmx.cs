using System;
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
        public String customerQuery(String queryStr)
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
                foreach (DataRow dr in dt.Rows)
                {
                    str += "{";
                    str += "\"id\":" + dr["Id"] + ",";
                    str += "\"customerName\":\"" + dr["CustomerName"] + "\"";
                    str += "},";
                }
                str = str.Substring(0, str.Length - 1);
            }
            str += "]";
            return str;
        }

        [WebMethod]
        public int customerVerify(int id) {
            CustomerLogic customerLogic = new CustomerLogic();
            return customerLogic.customerVerify(id);
        }

    }
}
