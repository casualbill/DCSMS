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
    public partial class orderDetail : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;

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
                if (ds.Tables.Count > 0)
                {
                    lb_orderid.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    lb_failure_description.Text = ds.Tables[0].Rows[0]["FailureDescription"].ToString();
                    lb_order_remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                    lb_worktype.Text = ds.Tables[0].Rows[0]["WorkTypeStr"].ToString();
                    lb_createtime.Text = ds.Tables[0].Rows[0]["CreateTime"].ToString();
                    lb_updatetime.Text = ds.Tables[0].Rows[0]["UpdateTime"].ToString();
                    lb_orderstatus.Text = ds.Tables[0].Rows[0]["OrderStatusStr"].ToString();

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

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        rpt_sparepart.DataSource = ds.Tables[3];
                        rpt_sparepart.DataBind();
                        pn_table.Visible = true;
                    }
                    else {
                        pn_table.Visible = false;
                    }

                    lb_stationname.Text = ds.Tables[4].Rows[0]["StationName"].ToString();

                    if (Convert.ToInt16(Session["userType"]) < 3)
                    {
                        btn_update.Enabled = false;
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