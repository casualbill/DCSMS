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
                orderConfig orderCfg = new orderConfig();
                orderCfg.loadCustomerList(ddl_customer);
                orderCfg.loadStationList(ddl_station);
                orderCfg.loadUserList(ddl_technician, true);
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

                ddl_customer.Enabled = true;
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

                ddl_customer.Enabled = false;

                hf_customerid.Value = "";
            }
        }

        protected void ddl_customer_changed(object sender, EventArgs e)
        {
            String customerId = ddl_customer.SelectedValue;

            if (customerId == "0")
            {
                hf_customerid.Value = "";
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

        protected void ddl_worktype_changed(object sender, EventArgs e)
        {
            String workType = ddl_worktype.SelectedValue;

            if (workType == "0")
            {
                hf_worktype.Value = "";
            }
            else
            {
                hf_worktype.Value = workType;
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
                hf_stationid.Value = stationId;
            }
        }

        protected void ddl_technician_changed(object sender, EventArgs e)
        {
            String userId = ddl_technician.SelectedValue;

            if (userId == "0")
            {
                hf_technicianid.Value = "";
            }
            else
            {
                hf_technicianid.Value = userId;
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int workType;
            int customerId;
            int createUserId;
            int stationId;
            int technicianId;

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

            //前端验证tb_sparepart_amount为数字

            if (hf_worktype.Value == "")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择工作类型！\");</script>");
                return;
            }
            else
            {
                workType = Convert.ToInt16(hf_worktype.Value);
            }

            if (hf_stationid.Value == "")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择工作站！\");</script>");
                return;
            }
            else
            {
                stationId = Convert.ToInt16(hf_stationid.Value);
            }

            if (hf_technicianid.Value == "")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择检查用户！\");</script>");
                return;
            }
            else
            {
                technicianId = Convert.ToInt16(hf_technicianid.Value);
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
                customerInfo.Add("");   //Remark

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

            if (orderLogic.createOrder(tb_remark.Text.Trim(), workType, customerInfo, customerId, productInfo, createUserId, technicianId, stationId) != 1)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"系统错误！\");</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert (\"工单创建成功！\");</script>");
            }
        }
    }
}