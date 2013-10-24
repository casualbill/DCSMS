using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCSMS.Web
{
    public class permissionVerify : System.Web.UI.Page
    {
        public void permissionVerify(int allowUserType)
        {
            if (Session["userid"] == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"登录已超时，请重新登录！\"); window.location.href=\"/login.aspx\";</script>");
                return;
            }

            int userType = Convert.ToInt16(Session["userType"]);

            if (userType < allowUserType)
            {
                Response.Redirect("/error.aspx");
            }
        }
    }
}