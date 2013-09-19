using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web.user
{
    public partial class userQuery : System.Web.UI.Page
    {
        protected UserLogic userLogic = new UserLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String queryText = tb_query_text.Text.Trim().ToLower();
            DataTable dt = userLogic.userQueryByUserNameVaguely(queryText);
            if (dt != null)
            {
                lb_tips.Text = "";
                rpt_userinfo.DataSource = dt;
                rpt_userinfo.DataBind();
            }
            else {
                lb_tips.Text = "Empty";
            }
        }

        
    }
}