using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web.customer
{
    public partial class customerVerify : System.Web.UI.Page
    {
        protected CustomerLogic customerLogic = new CustomerLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = customerLogic.unverifiedCustomerQuery();
            if (dt != null)
            {
                lb_tips.Text = "";
                rpt_customerinfo.DataSource = dt;
                rpt_customerinfo.DataBind();
            }
            else
            {
                lb_tips.Text = "Empty";
            }
        }
    }
}