using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web.order
{
    public partial class inspectionResult : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urlQueryId = Request.QueryString["id"];
                getInspectionResult();
            }
        }

        protected void getInspectionResult()
        {
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
            }
            else
            {
                int toolType;
                DataTable productDt = orderLogic.productQuery(urlQueryId);
                if (productDt == null)
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
                    return;
                }
                else
                {
                    toolType = Convert.ToInt16(productDt.Rows[0]["ToolType"]);
                }

                DataTable inspectionResultDt = orderLogic.inspectionResultQuery(urlQueryId);
                if (inspectionResultDt == null)
                {
                    orderLogic.inspectionResultCreate(urlQueryId);
                }

                showInspectionResultItemText(toolType);
            }
        }

        protected void showInspectionResultItemText(int toolType)
        {
            switch (toolType)
            {
                case 1:
                    lb_itemtext1.Text = "外观检查";
                    lb_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_itemtext3.Text = "行星齿轮装置";
                    lb_itemtext4.Text = "传感器";
                    lb_itemtext5.Text = "马达";
                    lb_itemtext6.Text = "手柄及主板";
                    tr_inspectionresult7.Visible = false;
                    tr_inspectionresult8.Visible = false;
                    break;
                case 2:
                    lb_itemtext1.Text = "外观检查";
                    lb_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_itemtext3.Text = "行星齿轮装置";
                    lb_itemtext4.Text = "离合器或脉冲单元";
                    lb_itemtext5.Text = "马达";
                    lb_itemtext6.Text = "开关系统";
                    lb_itemtext7.Text = "其他部件";
                    tr_inspectionresult8.Visible = false;
                    break;
                case 3:
                    lb_itemtext1.Text = "外观检查";
                    lb_itemtext2.Text = "伺服驱动";
                    lb_itemtext3.Text = "I/O及CPU";
                    lb_itemtext4.Text = "电源";
                    lb_itemtext5.Text = "前面板";
                    lb_itemtext6.Text = "显示";
                    lb_itemtext7.Text = "其他部件";
                    tr_inspectionresult8.Visible = false;
                    break;
                case 4:
                    lb_itemtext1.Text = "外观检查";
                    lb_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_itemtext3.Text = "行星齿轮装置";
                    lb_itemtext4.Text = "马达";
                    lb_itemtext5.Text = "开关系统";
                    lb_itemtext6.Text = "其他部件";
                    tr_inspectionresult7.Visible = false;
                    tr_inspectionresult8.Visible = false;
                    break;
                case 5:
                    lb_itemtext1.Text = "外观检查";
                    lb_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_itemtext3.Text = "行星齿轮装置";
                    lb_itemtext4.Text = "离合器";
                    lb_itemtext5.Text = "马达";
                    lb_itemtext6.Text = "记忆卡";
                    lb_itemtext7.Text = "开关系统";
                    lb_itemtext8.Text = "其他部件";
                    break;
                case 6:
                    lb_itemtext1.Text = "外观检查";
                    lb_itemtext2.Text = "物理连接";
                    lb_itemtext3.Text = "机械部件";
                    lb_itemtext4.Text = "其他部件";
                    tr_inspectionresult5.Visible = false;
                    tr_inspectionresult6.Visible = false;
                    tr_inspectionresult7.Visible = false;
                    tr_inspectionresult8.Visible = false;
                    break;
            }
        }
    }
}