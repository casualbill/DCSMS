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
        CustomerLogic customerLogic = new CustomerLogic();
        DataTable customerDataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadCustomerList();
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
            }
        }

        protected void ddl_customer_changed(object sender, EventArgs e)
        {
            String customerId = ddl_customer.SelectedValue;

            foreach (DataRow dr in customerDataTable.Rows) {
                if (dr["id"].ToString() == customerId) {
                    tb_customername.Text = dr["CustomerName"].ToString();
                    tb_endcustomername.Text = dr["EndCustomerName"].ToString();
                    tb_contactperson.Text = dr["ContactPerson"].ToString();
                    tb_telephone.Text = dr["Telephone"].ToString();
                    tb_mobile.Text = dr["Mobile"].ToString();
                    tb_address.Text = dr["Address"].ToString();
                    tb_postcode.Text = dr["PostCode"].ToString();
                    break;
                }

            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

        }

        protected void loadCustomerList() {
            customerDataTable = customerLogic.customerQuery();

            ddl_customer.Items.Add(new ListItem("请选择客户", "0"));
            if (customerDataTable != null)
            {
                foreach (DataRow dr in customerDataTable.Rows)
                {
                    ddl_customer.Items.Add(new ListItem(dr["customerName"].ToString(), dr["id"].ToString()));
                }
            }
        }
    }
}