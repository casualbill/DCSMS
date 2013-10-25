using System;
using System.Data;
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
                orderCfg.loadStationList(ddl_station);
            }
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

            if (orderId.Length < 3 && customerId == 0 && productName.Length < 3 && serialNumber.Length < 3 && stationId == 0 && orderStatuts == 0 && technicianId == 0)
            {
                lb_tips.Text = "请填写至少一项查询条件";
                lb_tips.Visible = true;
                return;
            }
            else
            {
                DataTable dt = orderLogic.orderListQueryVaguely(orderId, workType, technicianId, customerId, productName, serialNumber, stationId, orderStatuts);
                if (dt == null)
                {
                    pn_table.Visible = false;
                    lb_tips.Text = "没有符合条件的工单";
                    lb_tips.Visible = true;
                }
                else
                {
                    rpt_orderinfo.DataSource = dt;
                    rpt_orderinfo.DataBind();
                    pn_table.Visible = true;
                    lb_tips.Text = "";
                    lb_tips.Visible = false;
                }
            }
        }


    }
}