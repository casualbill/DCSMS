﻿using System;
using System.Collections.Generic;
using DCSMS.BLL;

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

            if (!IsPostBack)
            {
                orderConfig orderCfg = new orderConfig();
                orderCfg.loadStationList(ddl_station);
            }
        }

        protected void rbl_customer_change(object sender, EventArgs e)
        {
            if (rbl_customer.SelectedValue == "0")
            {
                tb_contactperson.Enabled = false;
                tb_telephone.Enabled = false;
                tb_mobile.Enabled = false;
                tb_address.Enabled = false;
                tb_postcode.Enabled = false;
            }
            else
            {
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

                hf_customerid.Value = "0";
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int workType;
            int customerId;
            int createUserId;
            int stationId;
            int technicianId;
            String toolType;
            Boolean isPublic;

            if (Session["userId"] == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"登录已超时，请重新登录！\");</script>");
                return;
            }
            else
            {
                createUserId = Convert.ToInt16(Session["userId"]);
            }

            if (rbl_customer.SelectedValue == "0" && hf_customerid.Value == "0")
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

            if (ddl_worktype.SelectedValue == "0")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择工作类型！\");</script>");
                return;
            }
            else
            {
                workType = Convert.ToInt16(ddl_worktype.SelectedValue);
            }

            if (ddl_tooltype.SelectedValue == "0")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择工具类型！\");</script>");
                return;
            }
            else
            {
                toolType = ddl_tooltype.SelectedValue;
            }

            if (ddl_station.SelectedValue == "0")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择工作站！\");</script>");
                return;
            }
            else
            {
                stationId = Convert.ToInt16(ddl_station.SelectedValue);
            }

            if (hf_technicianid.Value == "0")
            {
                Response.Write("<script type=\"text/javascript\">alert (\"请选择跟单技术员！\");</script>");
                return;
            }
            else
            {
                technicianId = Convert.ToInt16(hf_technicianid.Value);
            }


            List<String> customerInfo = new List<String>();
            int cityId = 0;
            if (rbl_customer.SelectedValue == "1")
            {
                customerInfo.Add(tb_customername.Text.Trim());
                customerInfo.Add(tb_endcustomername.Text.Trim());
                customerInfo.Add(tb_contactperson.Text.Trim());
                customerInfo.Add(tb_telephone.Text.Trim());
                customerInfo.Add(tb_mobile.Text.Trim());
                customerInfo.Add(tb_address.Text.Trim());
                customerInfo.Add(tb_postcode.Text.Trim());
                customerInfo.Add("");   //Remark
                cityId = Convert.ToInt16(hf_cityid.Value);

                customerId = 0;
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
            productInfo.Add(toolType);

            if (rbl_ispublic.SelectedValue == "0")
            {
                isPublic = false;
            }
            else
            {
                isPublic = true;
            }

            if (orderLogic.createOrder(tb_remark.Text.Trim(), workType, isPublic, customerInfo, cityId, customerId, productInfo, createUserId, technicianId, stationId) != 1)
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