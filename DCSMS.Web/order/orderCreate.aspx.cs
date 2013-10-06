﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web.order
{
    public partial class orderCreate : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();
        UserLogic userLogic = new UserLogic();
        CustomerLogic customerLogic = new CustomerLogic();
        StationLogic stationLogic = new StationLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userid"] = "13";   //测试用，记得删除！！！！！！！！！！！！！

            if (!IsPostBack)
            {
                loadCustomerList();
                loadStationList();
                loadUserList();
            }
        }

        protected void rbl_customer_change(object sender, EventArgs e)
        {
            if (rbl_customer.SelectedValue == "0")
            {
                tb_customername.Enabled = false;
                tb_endcustomername.Enabled = false;
                tb_contactperson.Enabled = false;
                tb_telephone.Enabled = false;
                tb_mobile.Enabled = false;
                tb_address.Enabled = false;
                tb_postcode.Enabled = false;
            }
            else
            {
                tb_customername.Enabled = true;
                tb_endcustomername.Enabled = true;
                tb_contactperson.Enabled = true;
                tb_telephone.Enabled = true;
                tb_mobile.Enabled = true;
                tb_address.Enabled = true;
                tb_postcode.Enabled = true;

                tb_customername.Text = "";
                tb_endcustomername.Text = "";
                tb_contactperson.Text = "";
                tb_telephone.Text = "";
                tb_mobile.Text = "";
                tb_address.Text = "";
                tb_postcode.Text = "";

                hf_customerid.Value = "";
            }
        }

        protected void ddl_customer_changed(object sender, EventArgs e)
        {
            String customerId = ddl_customer.SelectedValue;

            if (customerId == "0")
            {
                hf_stationid.Value = "";
            }
            else
            {
                List<String> customerInfo = customerLogic.customerQueryByCustomerId(Convert.ToInt16(customerId));
                hf_customerid.Value = customerInfo[0];
                tb_customername.Text = customerInfo[1];
                tb_endcustomername.Text = customerInfo[2];
                tb_contactperson.Text = customerInfo[3];
                tb_telephone.Text = customerInfo[4];
                tb_mobile.Text = customerInfo[5];
                tb_address.Text = customerInfo[6];
                tb_postcode.Text = customerInfo[7];
            }
        }

        protected void ddl_station_changed(object sender, EventArgs e)
        {
            String stationId = ddl_station.SelectedValue;

            if (stationId == "0")
            {
                hf_stationid.Value = "";
            }
            else
            {
                List<String> stationInfo = stationLogic.stationQueryByStaionId(Convert.ToInt16(stationId));
                hf_stationid.Value = stationInfo[0];
            }
        }

        protected void ddl_task_user_changed(object sender, EventArgs e)
        {
            String userId = ddl_task_user.SelectedValue;

            if (userId == "0")
            {
                hf_taskuserid.Value = "";
            }
            else
            {
                List<String> userInfo = userLogic.userQueryByUserId(Convert.ToInt16(userId));
                hf_taskuserid.Value = userInfo[0];
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int customerId;
            int createUserId;
            int stationId;
            int taskUserId;

            if (Session["userid"] == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"登录已超时，请重新登录！\");</script>");
                return;
            }
            else
            {
                createUserId = Convert.ToInt16(Session["userid"]);
            }

            if (rbl_customer.SelectedValue == "0" && ddl_customer.SelectedValue == "0")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择客户！\");</script>");
                return;
            }

            if (rbl_customer.SelectedValue == "1" && (tb_customername.Text.Trim().Length < 1 || tb_contactperson.Text.Trim().Length < 1))
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请完整输入客户信息！\");</script>");
                return;
            }

            if (tb_productname.Text.Trim().Length < 1 || tb_serialnumber.Text.Trim().Length < 1 || tb_product_orderingnumber.Text.Trim().Length < 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请完整输入工具信息\");</script>");
                return;
            }

            if (tb_sparepartname.Text.Trim().Length < 1 || tb_sparepart_orderingnumber.Text.Trim().Length < 1 || tb_sparepart_amount.Text.Trim().Length < 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请完整输入备件信息！\");</script>");
                return;
            }

            //前端验证tb_sparepart_amount为数字

            if (hf_stationid.Value == "")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择工作站！\");</script>");
                return;
            }
            else
            {
                stationId = Convert.ToInt16(hf_stationid.Value);
            }

            if (hf_taskuserid.Value == "")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择检查用户！\");</script>");
                return;
            }
            else
            {
                taskUserId = Convert.ToInt16(hf_taskuserid.Value);
            }


            List<String> customerInfo = new List<String>();
            //HiddenField客户ID值为空时新建客户（需审核）
            if (hf_customerid.Value == "")
            {
                customerInfo.Add(tb_customername.Text.Trim());
                customerInfo.Add(tb_endcustomername.Text.Trim());
                customerInfo.Add(tb_contactperson.Text.Trim());
                customerInfo.Add(tb_telephone.Text.Trim());
                customerInfo.Add(tb_mobile.Text.Trim());
                customerInfo.Add(tb_address.Text.Trim());
                customerInfo.Add(tb_postcode.Text.Trim());

                customerId = -1;
            }
            else
            {
                customerId = Convert.ToInt16(hf_customerid.Value);
            }

            List<String> productInfo = new List<String>();
            productInfo.Add(tb_productname.Text.Trim());
            productInfo.Add(tb_serialnumber.Text.Trim());
            productInfo.Add(tb_product_orderingnumber.Text.Trim());
            productInfo.Add("");    //CycleCounters
            productInfo.Add(tb_firmwareversion.Text.Trim());
            productInfo.Add(tb_product_remark.Text.Trim());

            List<List<String>> sparePartInfoList = new List<List<String>>();
            List<String> sparePartInfo = new List<String>();
            sparePartInfo.Add(tb_sparepartname.Text.Trim());
            sparePartInfo.Add(tb_sparepart_orderingnumber.Text.Trim());
            sparePartInfo.Add(tb_sparepart_amount.Text.Trim());
            sparePartInfo.Add(tb_sparepart_remark.Text.Trim());
            sparePartInfoList.Add(sparePartInfo);

            if (orderLogic.createOrder(tb_failure_description.Text.Trim(), tb_imgurl.Text.Trim(), productInfo, sparePartInfoList, customerInfo, customerId, createUserId, stationId, taskUserId) != 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"系统错误！\");</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert (\"工单创建成功！\");</script>");
            }
        }

        protected void loadCustomerList()
        {
            DataTable dt = customerLogic.verifiedCustomerQuery();

            ddl_customer.Items.Clear();
            ddl_customer.Items.Add(new ListItem("请选择客户", "0"));
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddl_customer.Items.Add(new ListItem(dr["CustomerName"].ToString(), dr["Id"].ToString()));
                }
            }
        }

        protected void loadStationList()
        {
            DataTable dt = stationLogic.stationQuery();

            ddl_station.Items.Clear();
            ddl_station.Items.Add(new ListItem("请选择维修站", "0"));
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddl_station.Items.Add(new ListItem(dr["StationNameSimple"].ToString(), dr["Id"].ToString()));
                }
            }
        }

        protected void loadUserList() {
            DataTable dt = userLogic.userQuery();

            ddl_task_user.Items.Clear();
            ddl_task_user.Items.Add(new ListItem("请选择用户", "0"));
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddl_task_user.Items.Add(new ListItem(dr["UserName"].ToString(), dr["Id"].ToString()));
                }
            }
        }
    }
}