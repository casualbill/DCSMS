using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCSMS.Web
{
    public class permissionVerify : System.Web.UI.Page
    {
        public permissionVerify(int allowUserType)
        {
            if (Session["userid"] == null)
            {
                System.Web.HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert (\"登录已超时，请重新登录！\"); window.location.href=\"/login.aspx\";</script>");
                return;
            }

            int userType = Convert.ToInt16(Session["userType"]);

            if (userType < allowUserType)
            {
                System.Web.HttpContext.Current.Response.Redirect("/error.html");
            }
        }
    }
}