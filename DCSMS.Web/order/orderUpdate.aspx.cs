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
    public partial class orderUpdate : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        protected String urlQueryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userid"] = "13";   //测试用，记得删除！！！！！！！！！！！！！

            if (!IsPostBack)
            {
                orderConfig orderCfg = new orderConfig();
                orderCfg.loadCustomerList(ddl_customer, false, false);
                orderCfg.loadUserList(ddl_technician, true, false);

                urlQueryId = Request.QueryString["id"];
                getOrderDetails();
            }
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int operateUserId;

            if (Session["userid"] == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"登录已超时，请重新登录！\");</script>");
                return;
            }
            else
            {
                operateUserId = Convert.ToInt16(Session["userid"]);
            }

            if (ddl_customer.SelectedValue == "0")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择客户！\");</script>");
                return;
            }

            if (tb_productname.Text.Trim().Length < 1 || tb_serialnumber.Text.Trim().Length < 1 || tb_product_orderingnumber.Text.Trim().Length < 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请完整输入工具信息\");</script>");
                return;
            }

            //if (tb_sparepartname.Text.Trim().Length < 1 || tb_sparepart_orderingnumber.Text.Trim().Length < 1 || tb_sparepart_amount.Text.Trim().Length < 1)
            //{
            //    Response.Write("<script type=\"text/javascript\">alert (\"请完整输入备件信息！\");</script>");
            //    return;
            //}

            int workType = Convert.ToInt16(ddl_worktype.SelectedValue);
            int newStatus = Convert.ToInt16(ddl_orderstatus.SelectedValue);
            int technicianId = Convert.ToInt16(ddl_technician.SelectedValue);
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
            int customerId = Convert.ToInt16(ddl_customer.SelectedValue);

            List<String> productInfo = new List<String>();
            productInfo.Add(tb_productname.Text.Trim());
            productInfo.Add(tb_serialnumber.Text.Trim());
            productInfo.Add(tb_product_orderingnumber.Text.Trim());
            productInfo.Add("");    //CycleCounters
            productInfo.Add(tb_product_firmware.Text.Trim());
            productInfo.Add(tb_product_remark.Text.Trim());

            //List<List<String>> sparePartInfoList = new List<List<String>>();
            //List<String> sparePartInfo = new List<String>();
            //sparePartInfo.Add(tb_sparepartname.Text.Trim());
            //sparePartInfo.Add(tb_sparepart_orderingnumber.Text.Trim());
            //sparePartInfo.Add(tb_sparepart_amount.Text.Trim());
            //sparePartInfo.Add(tb_sparepart_remark.Text.Trim());
            //sparePartInfoList.Add(sparePartInfo);



            if (orderLogic.orderTotallyUpdate(lb_orderid.Text, productInfo, tb_failure_description.Text.Trim(), tb_imgurl.Text.Trim(), tb_remark.Text.Trim(), workType, technicianId, adminId, customerId, formerStatus, newStatus, operateUserId) != 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"系统错误！\");</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert (\"工单修改成功！\");</script>");
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
                    tb_imgurl.Text = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                    tb_remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                    hd_formerstatus.Value = ds.Tables[0].Rows[0]["OrderStatus"].ToString();
                    if (hd_formerstatus.Value == "8")
                    {
                        ddl_orderstatus.Enabled = false;
                    }
                    lb_orderstatus.Text = ds.Tables[0].Rows[0]["OrderStatusStr"].ToString();

                    ddl_worktype.Items.FindByValue(ds.Tables[0].Rows[0]["WorkType"].ToString()).Selected = true;
                    ddl_orderstatus.Items.FindByValue(ds.Tables[0].Rows[0]["OrderStatus"].ToString()).Selected = true;
                    ddl_customer.Items.FindByValue(ds.Tables[1].Rows[0]["Id"].ToString()).Selected = true;
                    ddl_technician.Items.FindByValue(ds.Tables[6].Rows[0]["Id"].ToString()).Selected = true;

                    hf_adminid.Value = ds.Tables[0].Rows[0]["AdminId"].ToString();
                    int adminId = Convert.ToInt16(ds.Tables[0].Rows[0]["AdminId"]);
                    if (adminId != 0)
                    {
                        cb_manageorder.Enabled = false;
                    }
                    if (adminId.ToString() == Session["userid"].ToString())
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
                    Response.Write("<script type=\"text/javascript\">alert (\"该工单不存在！\"); window.location.href=\"orderQuery.aspx\";</script>");
                }

            }
        }
    }
}