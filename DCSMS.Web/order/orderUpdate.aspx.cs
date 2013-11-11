using System;
using System.Collections.Generic;
using System.Data;
using DCSMS.BLL;

namespace DCSMS.Web.order
{
    public partial class orderUpdate : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;
        protected int orderStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            permissionVerify pv = new permissionVerify(3);

            urlQueryId = Request.QueryString["id"];

            if (!IsPostBack)
            {
                getOrderDetails();
            }
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int operateUserId;
            Boolean isPublic;

            int customerId = Convert.ToInt16(hf_customerid.Value);
            int technicianId = Convert.ToInt16(hf_technicianid.Value);

            if (Session["userId"] == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"登录已超时，请重新登录！\");</script>");
                return;
            }
            else
            {
                operateUserId = Convert.ToInt16(Session["userId"]);
            }

            if (customerId == 0)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择客户！\");</script>");
                return;
            }

            if (technicianId == 0) {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择跟单技术员！\");</script>");
                return;
            }

            if (tb_productname.Text.Trim().Length < 1 || tb_serialnumber.Text.Trim().Length < 1 || tb_product_orderingnumber.Text.Trim().Length < 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请完整输入工具信息\");</script>");
                return;
            }

            int workType = Convert.ToInt16(ddl_worktype.SelectedValue);
            int newStatus = Convert.ToInt16(ddl_orderstatus.SelectedValue);
            int formerStatus = Convert.ToInt16(hd_formerstatus.Value);
            int adminId;
            if (hf_adminid.Value == "0" && cb_manageorder.Checked == true)
            {
                adminId = operateUserId;
            }
            else
            {
                adminId = Convert.ToInt16(hf_adminid.Value);
            }

            List<String> customerInfo = new List<String>();

            List<String> productInfo = new List<String>();
            productInfo.Add(tb_productname.Text.Trim());
            productInfo.Add(tb_serialnumber.Text.Trim());
            productInfo.Add(tb_product_orderingnumber.Text.Trim());
            productInfo.Add("");    //CycleCounters
            productInfo.Add(tb_product_firmware.Text.Trim());
            productInfo.Add(tb_product_remark.Text.Trim());
            productInfo.Add(ddl_tooltype.SelectedValue);

            if (rbl_ispublic.SelectedValue == "0")
            {
                isPublic = false;
            }
            else
            {
                isPublic = true;
            }

            if (orderLogic.orderTotallyUpdate(lb_orderid.Text, productInfo, tb_failure_description.Text.Trim(), tb_remark.Text.Trim(), workType, technicianId, adminId, customerId, formerStatus, newStatus, isPublic, operateUserId) != 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"系统错误！\");</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert (\"工单修改成功！\"); window.location.href=\"orderDetail.aspx?id=" + urlQueryId + "\";</script>");
            }
        }



        protected void getOrderDetails()
        {
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
            }
            else
            {
                //tabel 0为工单 1客户 2工具 3备件 4维修站 5工单记录 6跟单技术员 7创建人 8管理者
                DataSet ds = orderLogic.orderQueryByOrderId(urlQueryId);
                if (ds != null)
                {
                    lb_orderid.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    tb_failure_description.Text = ds.Tables[0].Rows[0]["FailureDescription"].ToString();
                    tb_remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                    orderStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["OrderStatus"]);
                    hd_formerstatus.Value = ds.Tables[0].Rows[0]["OrderStatus"].ToString();
                    if (hd_formerstatus.Value == "8")
                    {
                        ddl_orderstatus.Enabled = false;
                    }
                    lb_orderstatus.Text = ds.Tables[0].Rows[0]["OrderStatusStr"].ToString();

                    ddl_worktype.Items.FindByValue(ds.Tables[0].Rows[0]["WorkType"].ToString()).Selected = true;
                    ddl_orderstatus.Items.FindByValue(ds.Tables[0].Rows[0]["OrderStatus"].ToString()).Selected = true;

                    if (ds.Tables[0].Rows[0]["IsPublic"].ToString() == "1")
                    {
                        rbl_ispublic.SelectedValue = "1";
                    }
                    else
                    {
                        rbl_ispublic.SelectedValue = "0";
                    }

                    tb_technician.Text = ds.Tables[6].Rows[0]["UserName"].ToString();
                    hf_technicianid.Value = ds.Tables[6].Rows[0]["Id"].ToString();
                    tb_customer.Text = ds.Tables[1].Rows[0]["CustomerName"].ToString();
                    hf_customerid.Value = ds.Tables[1].Rows[0]["Id"].ToString();

                    hf_adminid.Value = ds.Tables[0].Rows[0]["AdminId"].ToString();
                    int adminId = Convert.ToInt16(ds.Tables[0].Rows[0]["AdminId"]);
                    if (adminId != 0)
                    {
                        cb_manageorder.Enabled = false;
                    }
                    if (adminId.ToString() == Session["userId"].ToString())
                    {
                        cb_manageorder.Checked = true;
                    }

                    tb_productname.Text = ds.Tables[2].Rows[0]["ProductName"].ToString();
                    tb_serialnumber.Text = ds.Tables[2].Rows[0]["SerialNumber"].ToString();
                    tb_product_orderingnumber.Text = ds.Tables[2].Rows[0]["OrderingNumber"].ToString();
                    tb_product_firmware.Text = ds.Tables[2].Rows[0]["FirmwareVersion"].ToString();
                    tb_product_remark.Text = ds.Tables[2].Rows[0]["Remark"].ToString();
                    ddl_tooltype.SelectedValue = ds.Tables[2].Rows[0]["ToolType"].ToString();

                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
                }

            }
        }
    }
}