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
    public partial class myTaskDetail : System.Web.UI.Page
    {
        protected OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;
        protected int formerStatus;
        protected int adminId;
        protected int userId;
        protected int userType;
        protected int customerId;

        protected String failureDescription;
        protected String imgUrl;
        protected String remark;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = 13; //Session["userId"]   测试测试！！！！！！！！！！！！！！！
            userType = 3;    //Session["userType"]

            urlQueryId = Request.QueryString["id"];

            getOrderDetails();

            if (!IsPostBack)
            {
                fillOrderDetailsIntoTextBox();
            }

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (userType == 2) {
                if (orderLogic.orderTaskOperateByTechnician(urlQueryId, tb_failure_description.Text.Trim(), tb_imgurl.Text.Trim(), tb_remark.Text.Trim(), formerStatus, null, userId) != 1)
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"系统错误！\");</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"操作成功！\"); window.location.href=\"/order/orderDetail.aspx?id=" + urlQueryId + "\";</script>");
                }
            }

            if (userType > 2) {
                if (formerStatus == 1) {
                    CustomerLogic customerLogic = new CustomerLogic();
                    customerLogic.customerVerify(customerId, userType);
                }

                if (adminId == 0 && cb_manageorder.Checked == true)
                {
                    adminId = userId;
                }

                if (orderLogic.orderTaskOperateByAdmin(urlQueryId, tb_remark.Text.Trim(), formerStatus, userId, adminId) != 1)
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"系统错误！\");</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"操作成功！\"); window.location.href=\"/order/orderDetail.aspx?id=" + urlQueryId + "\";</script>");
                }
            }
        }

        protected void getOrderDetails()
        {
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"myTask.aspx\";</script>");
            }
            else
            {
                //tabel 0为工单 1客户 2工具 3备件 4维修站 5工单记录 6跟单技术员 7创建人 8管理者
                DataSet ds = orderLogic.orderQueryByOrderId(urlQueryId);
                if (ds != null)
                {
                    int technicianId = Convert.ToInt16(ds.Tables[0].Rows[0]["TechnicianId"]);
                    formerStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["OrderStatus"]);

                    if (formerStatus == 8) {
                        Response.Write("<script type=\"text/javascript\">alert (\"该工单已完成！\"); window.location.href=\"myTask.aspx\";</script>");
                    }
                    if (userType < 3 && userId != technicianId) { noPermission(); }
                    if (userType < 3 && (formerStatus != 2 && formerStatus != 5 && formerStatus != 6)) { noPermission(); }
                    if (userType > 2 && (formerStatus == 2 || formerStatus == 5 || formerStatus == 6)) { noPermission(); }


                    lb_orderid.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    lb_worktype.Text = ds.Tables[0].Rows[0]["WorkTypeStr"].ToString();
                    lb_stationname.Text = ds.Tables[4].Rows[0]["StationName"].ToString();

                    failureDescription = ds.Tables[0].Rows[0]["FailureDescription"].ToString();
                    imgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                    remark = ds.Tables[0].Rows[0]["Remark"].ToString();

                    lb_orderstatus.Text = ds.Tables[0].Rows[0]["OrderStatusStr"].ToString();
                    btn_submit.Text = ds.Tables[0].Rows[0]["TaskFinishText"].ToString();

                    adminId = Convert.ToInt16(ds.Tables[0].Rows[0]["AdminId"]);
                    if (adminId != 0)
                    {
                        cb_manageorder.Enabled = false;
                    }
                    if (adminId == userId)
                    {
                        cb_manageorder.Checked = true;
                    }

                    customerId = Convert.ToInt16(ds.Tables[1].Rows[0]["Id"]);

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

                    //lb_sparepartname.Text = ds.Tables[3].Rows[0]["SparePartName"].ToString();
                    //lb_sparepart_orderingnumber.Text = ds.Tables[3].Rows[0]["OrderingNumber"].ToString();
                    //lb_sparepart_amount.Text = ds.Tables[3].Rows[0]["Amount"].ToString();
                    //lb_sparepart_remark.Text = ds.Tables[3].Rows[0]["Remark"].ToString();

                    if (userType < 3) {
                        cb_manageorder.Visible = false;
                        cb_manageorder.Enabled = false;
                    }

                    if (formerStatus != 2 && formerStatus != 5 && formerStatus != 6)
                    {
                        tb_failure_description.Enabled = false;
                        tb_imgurl.Enabled = false;
                    }

                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"myTask.aspx\";</script>");
                }

            }
        }

        protected void fillOrderDetailsIntoTextBox()
        {
            tb_failure_description.Text = failureDescription;
            tb_imgurl.Text = imgUrl;
            tb_remark.Text = remark;
        }

        protected void noPermission()
        {
            Response.Write("<script type=\"text/javascript\">alert (\"您没有操作权限！\"); window.location.href=\"myTask.aspx\";</script>");
        }
        
    }
}