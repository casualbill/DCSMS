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
    public partial class orderDetailQuery : System.Web.UI.Page
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


        protected void getOrderDetails()
        {
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该订单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
            }
            else
            {
                //tabel 0为工单 1客户 2工具 3备件 4维修站 5工单记录 6当前任务人 7创建人
                DataSet ds = orderLogic.orderQueryByOrderId(urlQueryId);
                if (ds.Tables.Count > 0)
                {
                    lb_orderid.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    lb_failure_description.Text = ds.Tables[0].Rows[0]["FailureDescription"].ToString();
                    lb_imgurl.Text = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                    lb_createtime.Text = ds.Tables[0].Rows[0]["CreateTime"].ToString();
                    lb_updatetime.Text = ds.Tables[0].Rows[0]["UpdateTime"].ToString();
                    lb_orderstatus.Text = ds.Tables[0].Rows[0]["OrderStatusStr"].ToString();

                    lb_createuser.Text = ds.Tables[7].Rows[0]["UserName"].ToString();
                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        lb_taskuser.Text = ds.Tables[6].Rows[0]["UserName"].ToString();
                    }
                    else
                    {
                        lb_taskuser.Text = "无";
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

                    lb_sparepartname.Text = ds.Tables[3].Rows[0]["SparePartName"].ToString();
                    lb_sparepart_orderingnumber.Text = ds.Tables[3].Rows[0]["OrderingNumber"].ToString();
                    lb_sparepart_amount.Text = ds.Tables[3].Rows[0]["Amount"].ToString();
                    lb_sparepart_remark.Text = ds.Tables[3].Rows[0]["Remark"].ToString();

                    lb_stationname.Text = ds.Tables[4].Rows[0]["StationName"].ToString();
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该订单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
                }

            }
        }
    }
}