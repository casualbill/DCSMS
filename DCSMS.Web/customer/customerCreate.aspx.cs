using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web.customer
{
    public partial class customerCreate : System.Web.UI.Page
    {
        protected CustomerLogic customerLogic = new CustomerLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
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
                int retVal = customerLogic.customerCreate(customerInfo);
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
    }
}