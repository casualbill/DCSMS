﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCSMS.BLL;
using System.Web.UI.WebControls;
using System.Data;

namespace DCSMS.Web
{
    public class orderConfig
    {
        public void loadCustomerList(DropDownList ddl_customer)
        {
            CustomerLogic customerLogic = new CustomerLogic();
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
                    ddl_station.Items.Add(new ListItem(dr["StationNameSimple"].ToString(), dr["Id"].ToString()));
                }
            }
        }

        public void loadUserList(DropDownList ddl_task_user)
        {
            UserLogic userLogic = new UserLogic();
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