using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web.order
{
    public partial class orderQuery : System.Web.UI.Page
    {
        OrderLogic orderLogic = new OrderLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                orderConfig orderCfg = new orderConfig();
                orderCfg.loadCustomerList(ddl_customer);
                orderCfg.loadStationList(ddl_station);
                orderCfg.loadUserList(ddl_technician, true);
            }
        }

        protected void ddl_customer_changed(object sender, EventArgs e)
        {
            hf_customerid.Value = ddl_customer.SelectedValue;
        }

        protected void ddl_technician_changed(object sender, EventArgs e)
        {
            hf_technicianid.Value = ddl_technician.SelectedValue;
        }

        protected void ddl_station_changed(object sender, EventArgs e)
        {
            hf_stationid.Value = ddl_station.SelectedValue;
        }

        protected void ddl_orderstatus_changed(object sender, EventArgs e)
        {
            hf_orderstatus.Value = ddl_orderstatus.SelectedValue;
        }

        protected void ddl_worktype_changed(object sender, EventArgs e)
        {
            hf_worktype.Value = ddl_worktype.SelectedValue;
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String orderId = tb_orderid.Text.Trim();
            int customerId = Convert.ToInt16(hf_customerid.Value);
            String productName = tb_productname.Text.Trim();
            String serialNumber = tb_serialnumber.Text.Trim();
            int stationId = Convert.ToInt16(hf_stationid.Value);
            int orderStatuts = Convert.ToInt16(hf_orderstatus.Value);
            int workType = Convert.ToInt16(hf_worktype.Value);
            int technicianId = Convert.ToInt16(hf_technicianid.Value);

            if (orderId.Length < 3 && customerId == 0 && productName.Length < 3 && serialNumber.Length < 3 && stationId == 0 && orderStatuts == 0)
            {
                lb_tips.Text = "请填写至少一项";
                return;
            }
            else
            {
                rpt_orderinfo.DataSource = orderLogic.orderListQueryVaguely(orderId, workType, technicianId, customerId, productName, serialNumber, stationId, orderStatuts);
                rpt_orderinfo.DataBind();
            }
        }


    }
}