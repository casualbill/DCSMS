﻿using System;
using System.Data;
using DCSMS.BLL;


namespace DCSMS.Web
{
    public partial class myTask : System.Web.UI.Page
    {
        protected OrderLogic orderLogic = new OrderLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            permissionVerify pv = new permissionVerify(2);

            int userId = Convert.ToInt16(Session["userId"]);
            int userType = Convert.ToInt16(Session["userType"]);

            DataTable dt = orderConfig.addOrderStatusText(orderLogic.orderQueryByTask(userId, userType));

            if (dt != null)
            {
                lb_tips.Text = "";
                lb_tips.Visible = false;
                rpt_orderinfo.DataSource = dt;
                rpt_orderinfo.DataBind();
                pn_table.Visible = true;
            }
            else
            {
                lb_tips.Text = "当前没有任务";
                lb_tips.Visible = true;
                pn_table.Visible = false;
            }
        }
    }
}