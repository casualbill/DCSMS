﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web.customer
{
    public partial class customerUpdate : System.Web.UI.Page
    {
        protected CustomerLogic customerLogic = new CustomerLogic();
        protected String urlQueryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                urlQueryId = Request.QueryString["id"];
                getCustomerDetails();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt16(lb_customerid.Text);
            List<String> customerInfo = new List<string>();
            customerInfo.Add(tb_customername.Text.Trim());
            customerInfo.Add(tb_endcustomername.Text.Trim());
            customerInfo.Add(tb_contactperson.Text.Trim());
            customerInfo.Add(tb_telephone.Text.Trim());
            customerInfo.Add(tb_mobile.Text.Trim());
            customerInfo.Add(tb_postcode.Text.Trim());
            customerInfo.Add(tb_remark.Text);

            if (customerInfo[0].Length < 1 || customerInfo[2].Length < 1)
            {
                lb_tips.Text = "error";
            }
            else
            {
                int retVal = customerLogic.customerUpdate(customerId, customerInfo);
                if (retVal == 1)
                {
                    lb_tips.Text = "success";
                }
                else
                {
                    lb_tips.Text = "fail";
                }
            }

        }

        protected void getCustomerDetails()
        {
            int customerId;
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该客户不存在！\"); window.location.href=\"customerQuery.aspx\";</script>");
            }
            else if (!int.TryParse(urlQueryId, out customerId))
            {
                Response.Write("<script type=\"text/javascript\">alert (\"非法ID！\"); window.location.href=\"customerQuery.aspx\";</script>");
            }
            else
            {
                List<String> customerInfo = customerLogic.customerQueryByCustomerId(customerId);
                if (customerInfo.Count > 0)
                {
                    lb_customerid.Text = customerInfo[0];
                    tb_customername.Text = customerInfo[1];
                    tb_endcustomername.Text = customerInfo[2];
                    tb_contactperson.Text = customerInfo[3];
                    tb_telephone.Text = customerInfo[4];
                    tb_mobile.Text = customerInfo[5];
                    tb_postcode.Text = customerInfo[6];
                    tb_remark.Text = customerInfo[7];
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该客户不存在！\"); window.location.href=\"customerQuery.aspx\";</script>");
                }

            }
        }
    }
}