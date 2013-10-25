using System;
using System.Data;
using DCSMS.BLL;

namespace DCSMS.Web.order
{
    public partial class orderLog : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            permissionVerify pv = new permissionVerify(3);

            urlQueryId = Request.QueryString["id"];
            getOrderLog();
        }

        protected void getOrderLog()
        {
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
            }
            else
            {
                lb_orderid.Text = urlQueryId;

                DataTable dt = orderLogic.orderLogQuery(urlQueryId);
                if (dt != null)
                {
                    rpt_orderlog.DataSource = dt;
                    rpt_orderlog.DataBind();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
                }
            }
        }
    }
}