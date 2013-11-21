using System;
using System.Data;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using Resources;

namespace DCSMS.Web
{
    public class orderConfig
    {
        
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

        //为工具表加入工具类型文字说明
        public static DataTable addToolTypeText(DataTable productTable)
        {
            productTable.Columns.Add("ToolTypeStr", Type.GetType("System.String"));

            int index = 0;
            foreach (DataRow dr in productTable.Rows)
            {
                switch (dr["ToolType"].ToString())
                {
                    case "1": productTable.Rows[index]["ToolTypeStr"] = GlobalResource.tool_type_text1; break;
                    case "2": productTable.Rows[index]["ToolTypeStr"] = GlobalResource.tool_type_text2; break;
                    case "3": productTable.Rows[index]["ToolTypeStr"] = GlobalResource.tool_type_text3; break;
                    case "4": productTable.Rows[index]["ToolTypeStr"] = GlobalResource.tool_type_text4; break;
                    case "5": productTable.Rows[index]["ToolTypeStr"] = GlobalResource.tool_type_text5; break;
                    case "6": productTable.Rows[index]["ToolTypeStr"] = GlobalResource.tool_type_text6; break;
                }
                index++;
            }
            return productTable;
        }

        //为工单表加入工作类型文字说明
        public static DataTable addWorkTypeText(DataTable orderTable)
        {
            orderTable.Columns.Add("WorkTypeStr", Type.GetType("System.String"));

            int index = 0;
            foreach (DataRow dr in orderTable.Rows)
            {
                switch (dr["WorkType"].ToString())
                {
                    case "1": orderTable.Rows[index]["WorkTypeStr"] = "质保"; break;
                    case "2": orderTable.Rows[index]["WorkTypeStr"] = "客户付费"; break;
                    case "3": orderTable.Rows[index]["WorkTypeStr"] = "Demo工具维修"; break;
                    case "4": orderTable.Rows[index]["WorkTypeStr"] = "项目维修"; break;
                }
                index++;
            }
            return orderTable;
        }

        //为工单表加入工单状态文字说明
        public static DataTable addOrderStatusText(DataTable orderTable)
        {
            return addOrderStatusText(orderTable, false);
        }

        public static DataTable addOrderStatusText(DataTable orderTable, Boolean showFinishTask)
        {
            orderTable.Columns.Add("OrderStatusStr", Type.GetType("System.String"));
            if (showFinishTask == true)
            {
                orderTable.Columns.Add("TaskFinishText", Type.GetType("System.String"));
            }

            int index = 0;
            foreach (DataRow dr in orderTable.Rows)
            {
                switch (dr["OrderStatus"].ToString())
                {
                    case "1": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text1; break;
                    case "2": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text2; break;
                    case "3": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text3; break;
                    case "4": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text4; break;
                    case "5": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text5; break;
                    case "6": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text6; break;
                    case "7": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text7; break;
                    case "8": orderTable.Rows[index]["OrderStatusStr"] = GlobalResource.order_status_text8; break;
                }

                if (showFinishTask == true)
                {
                    switch (dr["OrderStatus"].ToString())
                    {
                        case "1": orderTable.Rows[index]["TaskFinishText"] = "客户审核完成"; break;
                        case "2": orderTable.Rows[index]["TaskFinishText"] = "工单检查完成"; break;
                        case "3": orderTable.Rows[index]["TaskFinishText"] = "报价完成"; break;
                        case "4": orderTable.Rows[index]["TaskFinishText"] = "客户已确认"; break;
                        case "5": orderTable.Rows[index]["TaskFinishText"] = "备件已到齐"; break;
                        case "6": orderTable.Rows[index]["TaskFinishText"] = "维修完成"; break;
                        case "7": orderTable.Rows[index]["TaskFinishText"] = "发货完成"; break;
                    }
                }
                index++;
            }
            return orderTable;
        }
    }
}