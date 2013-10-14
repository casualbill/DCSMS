using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCSMS.Web
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    //Response.Redirect("/login.aspx");
                }
            }
        }

        protected void lb_logout_click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/login.aspx");
        }
    }
}