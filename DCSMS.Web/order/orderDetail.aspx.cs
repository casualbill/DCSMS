﻿using System;
using System.Data;
using DCSMS.BLL;

namespace DCSMS.Web.order
{
    public partial class orderDetail : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;
        protected int orderStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urlQueryId = Request.QueryString["id"];
                getOrderDetails();
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            Response.Redirect("orderUpdate.aspx?id=" + lb_orderid.Text);
        }

        protected void btn_orderlog_Click(object sender, EventArgs e)
        {
            Response.Redirect("orderLog.aspx?id=" + lb_orderid.Text);
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
                if (ds != null && ds.Tables.Count > 0)
                {
                    orderConfig.addWorkTypeText(orderConfig.addOrderStatusText(ds.Tables[0]));
                    orderConfig.addToolTypeText(ds.Tables[2]);

                    lb_orderid.Text = ds.Tables[0].Rows[0]["Id"].ToString();

                    if (Convert.ToInt16(Session["userType"]) == 1 && ds.Tables[0].Rows[0]["IsPublic"].ToString() == "0")
                    {
                        lb_failure_description.Visible = false;
                        lb_order_remark.Visible = false;
                        li_failure_description.Visible = false;
                        li_order_remark.Visible = false;
                    }
                    else
                    {
                        lb_failure_description.Text = ds.Tables[0].Rows[0]["FailureDescription"].ToString();
                        lb_order_remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    }

                    lb_worktype.Text = ds.Tables[0].Rows[0]["WorkTypeStr"].ToString();
                    lb_createtime.Text = ds.Tables[0].Rows[0]["CreateTime"].ToString();
                    lb_updatetime.Text = ds.Tables[0].Rows[0]["UpdateTime"].ToString();
                    lb_orderstatus.Text = ds.Tables[0].Rows[0]["OrderStatusStr"].ToString();
                    orderStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["OrderStatus"]);

                    lb_technician.Text = ds.Tables[6].Rows[0]["UserName"].ToString();
                    lb_createuser.Text = ds.Tables[7].Rows[0]["UserName"].ToString();

                    if (ds.Tables[8].Rows.Count > 0)
                    {
                        lb_admin.Text = ds.Tables[8].Rows[0]["UserName"].ToString();
                    }
                    else
                    {
                        lb_admin.Text = "无";
                    }

                    lb_customername.Text = ds.Tables[1].Rows[0]["CustomerName"].ToString();
                    lb_endcustomername.Text = ds.Tables[1].Rows[0]["EndCustomerName"].ToString();
                    lb_contactperson.Text = ds.Tables[1].Rows[0]["ContactPerson"].ToString();
                    lb_customer_telephone.Text = ds.Tables[1].Rows[0]["Telephone"].ToString();
                    lb_customer_mobile.Text = ds.Tables[1].Rows[0]["Mobile"].ToString();
                    lb_customer_address.Text = ds.Tables[1].Rows[0]["Address"].ToString();
                    lb_customer_postcode.Text = ds.Tables[1].Rows[0]["PostCode"].ToString();

                    lb_productname.Text = ds.Tables[2].Rows[0]["ProductName"].ToString();
                    lb_serialnumber.Text = ds.Tables[2].Rows[0]["SerialNumber"].ToString();
                    lb_product_orderingnumber.Text = ds.Tables[2].Rows[0]["OrderingNumber"].ToString();
                    lb_product_firmware.Text = ds.Tables[2].Rows[0]["FirmwareVersion"].ToString();
                    lb_product_remark.Text = ds.Tables[2].Rows[0]["Remark"].ToString();
                    lb_tooltype.Text = ds.Tables[2].Rows[0]["ToolTypeStr"].ToString();

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        rpt_sparepart.DataSource = ds.Tables[3];
                        rpt_sparepart.DataBind();
                        pn_sparepart.Visible = true;
                    }
                    else
                    {
                        pn_sparepart.Visible = false;
                    }

                    if (ds.Tables[9].Rows.Count > 0)
                    {
                        rpt_repairlog.DataSource = ds.Tables[9];
                        rpt_repairlog.DataBind();
                        pn_repairlog.Visible = true;
                    }
                    else
                    {
                        pn_repairlog.Visible = false;
                    }

                    lb_stationname.Text = ds.Tables[4].Rows[0]["StationName"].ToString();

                    if (Convert.ToInt16(Session["userType"]) < 3)
                    {
                        btn_update.Enabled = false;
                        btn_orderlog.Visible = false;
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
                }

            }
        }
    }
}