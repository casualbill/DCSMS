using System.Data;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web
{
    public class orderConfig
    {
        //public void loadCustomerList(DropDownList ddl_customer, Boolean IsOnlyVerified, Boolean addDefaultItem)
        //{
        //    CustomerLogic customerLogic = new CustomerLogic();
        //    DataTable dt;
        //    if (IsOnlyVerified == true)
        //    {
        //        dt=customerLogic.verifiedCustomerQuery();
        //    }
        //    else
        //    {
        //        dt = customerLogic.customerQuery();
        //    }

        //    ddl_customer.Items.Clear();

        //    if (addDefaultItem == true)
        //    {
        //        ddl_customer.Items.Add(new ListItem("请选择客户", "0"));
        //    }
        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ddl_customer.Items.Add(new ListItem(dr["CustomerName"].ToString(), dr["Id"].ToString()));
        //        }
        //    }
        //}

        public void loadStationList(DropDownList ddl_station)
        {
            StationLogic stationLogic = new StationLogic();
            DataTable dt = stationLogic.stationQuery();

            ddl_station.Items.Clear();
            ddl_station.Items.Add(new ListItem("请选择维修站", "0"));
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddl_station.Items.Add(new ListItem(dr["StationCode"].ToString(), dr["Id"].ToString()));
                }
            }
        }

        //public void loadUserList(DropDownList ddl_task_user, Boolean isTechnician, Boolean addDefaultItem)
        //{
        //    UserLogic userLogic = new UserLogic();
        //    DataTable dt;
        //    if (isTechnician == true)
        //    {
        //        dt = userLogic.userQueryByUserType(2);
        //    }
        //    else
        //    {
        //        dt = userLogic.userQuery();
        //    }

        //    ddl_task_user.Items.Clear();

        //    if (addDefaultItem == true)
        //    {
        //        ddl_task_user.Items.Add(new ListItem("请选择用户", "0"));
        //    }

        //    if (dt != null)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ddl_task_user.Items.Add(new ListItem(dr["UserName"].ToString(), dr["Id"].ToString()));
        //        }
        //    }
        //}
    }
}