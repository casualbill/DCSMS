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
    public partial class customerQuery : System.Web.UI.Page
    {
        protected CustomerLogic customerLogic = new CustomerLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String queryText = tb_query_text.Text.Trim().ToLower();
            DataTable dt = customerLogic.customerQueryByCustomerNameVaguely(queryText);
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
                lb_tips.Text = "没有符合条件的客户";
                lb_tips.Visible = true;
                pn_table.Visible = false;
            }
        }
    }
}