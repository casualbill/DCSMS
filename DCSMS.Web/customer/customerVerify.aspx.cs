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
            Session["userType"] = "3";
            DataTable dt = customerLogic.unverifiedCustomerQuery();
            if (dt != null)
            {
                lb_tips.Text = "";
                lb_tips.Visible = false;
                rpt_customerinfo.DataSource = dt;
                rpt_customerinfo.DataBind();
                pn_table.Visible = true;
            }
            else
            {
                lb_tips.Text = "没有待审核客户！";
                lb_tips.Visible = true;
                pn_table.Visible = false;
            }
        }
    }
}