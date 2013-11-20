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
            // test!!!
            Session["userId"] = "9";
            Session["userName"] = "admin";
            Session["userType"] = "5";





            if (!IsPostBack)
            {
                if (Session["userId"] == null)
                {
                    Response.Redirect("/login.aspx");
                }

                lb_username.Text = Session["userName"].ToString();
            }
        }

        protected void lbtn_logout_click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/login.aspx");
        }
    }
}