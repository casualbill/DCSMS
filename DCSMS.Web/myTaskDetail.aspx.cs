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

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = 13; //Session["userId"]   测试测试！！！！！！！！！！！！！！！
            userType = 3;    //Session["userType"]

            urlQueryId = Request.QueryString["id"];
            getOrderDetails();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

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
                    lb_orderid.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    lb_worktype.Text = ds.Tables[0].Rows[0]["WorkTypeStr"].ToString();
                    lb_stationname.Text = ds.Tables[4].Rows[0]["StationName"].ToString();

                    tb_failure_description.Text = ds.Tables[0].Rows[0]["FailureDescription"].ToString();
                    tb_imgurl.Text = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                    tb_remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                    formerStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["OrderStatus"]);
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

                    tb_productname.Text = ds.Tables[2].Rows[0]["ProductName"].ToString();
                    tb_serialnumber.Text = ds.Tables[2].Rows[0]["SerialNumber"].ToString();
                    tb_product_orderingnumber.Text = ds.Tables[2].Rows[0]["OrderingNumber"].ToString();
                    tb_product_firmware.Text = ds.Tables[2].Rows[0]["FirmwareVersion"].ToString();
                    tb_product_remark.Text = ds.Tables[2].Rows[0]["Remark"].ToString();

                    //lb_sparepartname.Text = ds.Tables[3].Rows[0]["SparePartName"].ToString();
                    //lb_sparepart_orderingnumber.Text = ds.Tables[3].Rows[0]["OrderingNumber"].ToString();
                    //lb_sparepart_amount.Text = ds.Tables[3].Rows[0]["Amount"].ToString();
                    //lb_sparepart_remark.Text = ds.Tables[3].Rows[0]["Remark"].ToString();


                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"myTask.aspx\";</script>");
                }

            }
        }
        
    }
}