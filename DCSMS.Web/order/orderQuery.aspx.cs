using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web.order
{
    public partial class orderQuery : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String orderId=tb_orderid.Text.Trim();

            rpt_orderinfo.DataSource = orderLogic.orderListQueryVaguely(orderId, 0, null, null, 0, 0);
            rpt_orderinfo.DataBind();

        }
        
    }
}