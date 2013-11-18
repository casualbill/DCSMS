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
            urlQueryId = Request.QueryString["id"];
            if (!IsPostBack)
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
                        getInspectionResult(toolType);
                    }
                }
            }
        }

        protected void getInspectionResult(int toolType)
        {
            DataTable dt = orderLogic.inspectionResultQuery(urlQueryId);
            if (dt == null)
            {
                orderLogic.inspectionResultCreate(urlQueryId);
            }
            else
            {
                ddl_ir_item1.SelectedValue = dt.Rows[0]["Item1"].ToString();
                ddl_ir_item2.SelectedValue = dt.Rows[0]["Item2"].ToString();
                ddl_ir_item3.SelectedValue = dt.Rows[0]["Item3"].ToString();
                ddl_ir_item4.SelectedValue = dt.Rows[0]["Item4"].ToString();
                ddl_ir_item5.SelectedValue = dt.Rows[0]["Item5"].ToString();
                ddl_ir_item6.SelectedValue = dt.Rows[0]["Item6"].ToString();
                ddl_ir_item7.SelectedValue = dt.Rows[0]["Item7"].ToString();
                ddl_ir_item8.SelectedValue = dt.Rows[0]["Item8"].ToString();

                tb_ir_comment1.Text = dt.Rows[0]["Comment1"].ToString();
                tb_ir_comment2.Text = dt.Rows[0]["Comment2"].ToString();
                tb_ir_comment3.Text = dt.Rows[0]["Comment3"].ToString();
                tb_ir_comment4.Text = dt.Rows[0]["Comment4"].ToString();
                tb_ir_comment5.Text = dt.Rows[0]["Comment5"].ToString();
                tb_ir_comment6.Text = dt.Rows[0]["Comment6"].ToString();
                tb_ir_comment7.Text = dt.Rows[0]["Comment7"].ToString();
                tb_ir_comment8.Text = dt.Rows[0]["Comment8"].ToString();

            }

            switch (toolType)
            {
                case 1:
                    lb_ir_itemtext1.Text = "外观检查";
                    lb_ir_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_ir_itemtext3.Text = "行星齿轮装置";
                    lb_ir_itemtext4.Text = "传感器";
                    lb_ir_itemtext5.Text = "马达";
                    lb_ir_itemtext6.Text = "手柄及主板";
                    tr_ir7.Visible = false;
                    tr_ir8.Visible = false;
                    break;
                case 2:
                    lb_ir_itemtext1.Text = "外观检查";
                    lb_ir_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_ir_itemtext3.Text = "行星齿轮装置";
                    lb_ir_itemtext4.Text = "离合器或脉冲单元";
                    lb_ir_itemtext5.Text = "马达";
                    lb_ir_itemtext6.Text = "开关系统";
                    lb_ir_itemtext7.Text = "其他部件";
                    tr_ir8.Visible = false;
                    break;
                case 3:
                    lb_ir_itemtext1.Text = "外观检查";
                    lb_ir_itemtext2.Text = "伺服驱动";
                    lb_ir_itemtext3.Text = "I/O及CPU";
                    lb_ir_itemtext4.Text = "电源";
                    lb_ir_itemtext5.Text = "前面板";
                    lb_ir_itemtext6.Text = "显示";
                    lb_ir_itemtext7.Text = "其他部件";
                    tr_ir8.Visible = false;
                    break;
                case 4:
                    lb_ir_itemtext1.Text = "外观检查";
                    lb_ir_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_ir_itemtext3.Text = "行星齿轮装置";
                    lb_ir_itemtext4.Text = "马达";
                    lb_ir_itemtext5.Text = "开关系统";
                    lb_ir_itemtext6.Text = "其他部件";
                    tr_ir7.Visible = false;
                    tr_ir8.Visible = false;
                    break;
                case 5:
                    lb_ir_itemtext1.Text = "外观检查";
                    lb_ir_itemtext2.Text = "弯头总成或输出轴组件";
                    lb_ir_itemtext3.Text = "行星齿轮装置";
                    lb_ir_itemtext4.Text = "离合器";
                    lb_ir_itemtext5.Text = "马达";
                    lb_ir_itemtext6.Text = "记忆卡";
                    lb_ir_itemtext7.Text = "开关系统";
                    lb_ir_itemtext8.Text = "其他部件";
                    break;
                case 6:
                    lb_ir_itemtext1.Text = "外观检查";
                    lb_ir_itemtext2.Text = "物理连接";
                    lb_ir_itemtext3.Text = "机械部件";
                    lb_ir_itemtext4.Text = "其他部件";
                    tr_ir5.Visible = false;
                    tr_ir6.Visible = false;
                    tr_ir7.Visible = false;
                    tr_ir8.Visible = false;
                    break;
            }
        }


    }
}