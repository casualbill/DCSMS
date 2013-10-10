using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;


namespace DCSMS.Web
{
    public partial class myTask : System.Web.UI.Page
    {
        protected OrderLogic orderLogic = new OrderLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = 13;    //测试用，记得用Session代替！！！！！！！！
            int userType = 3;

            DataTable dt = orderLogic.orderQueryByTask(userId, userType);

            if (dt != null)
            {
                lb_tips.Text = "";
                rpt_orderinfo.DataSource = dt;
                rpt_orderinfo.DataBind();
            }
            else
            {
                lb_tips.Text = "Empty";
            }
        }
    }
}