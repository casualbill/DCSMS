using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DCSMS.Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Session["userType"]) == 1)
            {
                Response.Redirect("/order/orderQuery.aspx");
            }
            else
            {
                Response.Redirect("/myTask.aspx");
            }
        }
    }
}