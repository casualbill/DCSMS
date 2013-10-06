using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCSMS.DAL;
using System.Data;

namespace DCSMS.BLL
{
    public class OrderLogic : Utility
    {
        protected OrderDB orderDb = new OrderDB();

        //新建工单
        public int createOrder(String failureDescription, String imgUrl, List<String> productInfo, List<List<String>> sparePartInfoList, List<String> customerInfo, int customerId, int createUserId, int stationId, int taskUserId)
        {
            ProductDB productDb = new ProductDB();
            SparePartDB sparePartDb = new SparePartDB();
            String id = DateTime.Now.ToString("yyMMddhhmmss") + getRandomNumber(0, 1000).ToString("000");

            //判读客户是否为新建的（需审核）
            if (customerId == -1)
            {
                CustomerDB customerDb = new CustomerDB();
                if (customerDb.customerCreate(customerInfo, false) == 1)
                {
                    DataSet ds = customerDb.customerQueryByCustomerName(customerInfo[0]);
                    customerId = Convert.ToInt16(ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    return -1;
                }
            }

            if (productDb.productCreate(productInfo, id) != 1)
            {
                return -2;
            }

            int sparePartCreateCount = 0;
            foreach (List<String> sparePartInfo in sparePartInfoList)
            {
                if (sparePartDb.sparePartCreate(sparePartInfo, id) == 1)
                {
                    sparePartCreateCount++;
                }
            }
            if (sparePartCreateCount < sparePartInfoList.Count)
            {
                return -3;
            }

            if (orderDb.orderCreate(id, failureDescription, imgUrl, createUserId, customerId, stationId) != 1)
            {
                return -4;
            }

            if (orderDb.orderTaskCreate(id, taskUserId, 1) != 1) { return -5; }

            return 1;
        }

        //工单状态更新（完成一项任务）
        //orderStatus状态说明：
        //1 收到工具 等待检查
        //2 检查完成 等待报价
        //3 报价完成 等待客户确认
        //4 确认完成 等待备件到齐
        //5 备件到齐 等待维修
        //6 维修完成 等待发货
        //7 发货完成
        public int orderStatusUpdate(String orderId, int orderStatus, int userId)
        {
            if (orderDb.orderStatusUpdate(orderId, orderStatus) != 1)
            {
                return -1;
            }

            if (orderDb.orderTaskComplete(orderId, orderStatus) != 1) { return -2; }

            if (orderStatus < 7)
            {
                if (orderDb.orderTaskCreate(orderId, userId, orderStatus) != 1) { return -3; }
            }

            return 1;
        }

        //工单模糊查询
        public DataTable orderListQueryVaguely(String orderId, int customerId, String productName, String serialNumber, int stationId, int orderStatus)
        {
            DataSet ds = orderDb.orderListQueryVaguely(orderId, customerId, productName, serialNumber, stationId, orderStatus);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.Tables[0].Columns.Add("OrderStatusStr", Type.GetType("System.String"));

                int index = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    switch (dr["OrderStatus"].ToString())
                    {
                        case "1": ds.Tables[0].Rows[index]["OrderStatusStr"] = "等待检查"; break;
                        case "2": ds.Tables[0].Rows[index]["OrderStatusStr"] = "等待报价"; break;
                        case "3": ds.Tables[0].Rows[index]["OrderStatusStr"] = "等待客户确认"; break;
                        case "4": ds.Tables[0].Rows[index]["OrderStatusStr"] = "等待备件到齐"; break;
                        case "5": ds.Tables[0].Rows[index]["OrderStatusStr"] = "等待维修"; break;
                        case "6": ds.Tables[0].Rows[index]["OrderStatusStr"] = "等待发货"; break;
                        case "7": ds.Tables[0].Rows[index]["OrderStatusStr"] = "完成"; break;
                    }
                    index++;
                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

    }
}