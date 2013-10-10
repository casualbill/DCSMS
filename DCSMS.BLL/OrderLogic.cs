﻿using System;
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
        public int createOrder(String remark, int workType, List<String> customerInfo, int customerId, List<String> productInfo, int createUserId, int technicianId, int stationId)
        {
            int orderStatus = 2;
            ProductDB productDb = new ProductDB();

            String year = DateTime.Now.ToString("yy");
            StationDB stationDb = new StationDB();
            String stationCode = stationDb.stationQueryByStationId(stationId).Tables[0].Rows[0]["StationCode"].ToString();
            int orderIdNum = Convert.ToInt16(orderDb.orderIdCount(stationCode, year)) + 1;
            String orderId = stationCode + year + orderIdNum.ToString("00000");

            //判读客户是否为新建的（需审核）
            if (customerId == -1)
            {
                orderStatus = 1;

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

            if (productDb.productCreate(productInfo, orderId) != 1)
            {
                return -2;
            }

            if (orderDb.orderCreate(orderId, remark, workType, createUserId, technicianId, customerId, stationId, orderStatus) != 1)
            {
                return -3;
            }

            return 1;
        }


        /*
        public int createOrder(String failureDescription, String imgUrl, List<String> productInfo, List<List<String>> sparePartInfoList, List<String> customerInfo, int customerId, int createUserId, int stationId, int taskUserId)
        {
            ProductDB productDb = new ProductDB();
            SparePartDB sparePartDb = new SparePartDB();
            String id = DateTime.Now.ToString("yyMMddHHmmss") + getRandomNumber(0, 1000).ToString("000");

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
         */

        
        //orderStatus状态说明：
        //1 收到工具 等待客户审核（随工单创建的客户）
        //2 客户审核完成 等待工单检查（技术员）
        //3 工单检查完成 等待报价
        //4 报价完成 等待客户确认
        //5 确认完成 等待备件到齐（技术员）
        //6 备件到齐 等待维修（技术员）
        //7 维修完成 等待发货
        //8 发货完成

        //工单完全修改（不包括备件）
        public int orderTotallyUpdate(String id, List<String> productInfo, String failureDescription, String imgUrl, String remark, int workType, int technicianId, int adminId, int customerId, int formerStatus, int newStatus, int operateUserId)
        {
            ProductDB productDb = new ProductDB();
            if (productDb.productUpdate(productInfo, id) != 1)
            {
                return -1;
            }

            if (orderDb.orderTotallyUpdate(id, failureDescription, imgUrl, remark, workType, technicianId, adminId, customerId, newStatus) != 1)
            {
                return -2;
            }

            if (formerStatus != newStatus)
            {
                if (orderDb.orderLogCreate(id, operateUserId, formerStatus, newStatus) != 1)
                {
                    return -3;
                }
            }

            return 1;
        }

        //工单修改：技术员完成工单检查
        public int orderCheckByTechnician(String id, String failureDescription, String imgUrl, String remark, List<String> productInfo, List<List<String>> sparePartInfoList, int operateUserId)
        {
            ProductDB productDb = new ProductDB();
            SparePartDB sparePartDb = new SparePartDB();

            if (productDb.productCreate(productInfo, id) != 1)
            {
                return -1;
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
                return -2;
            }

            if (orderDb.orderCheckUpdate(id, failureDescription, imgUrl, remark, 3) != 1)
            {
                return -3;
            }

            if (orderDb.orderLogCreate(id, operateUserId, 2, 3) != 1)
            {

                return -4;
            }

            return 1;
        }

        //工单修改：管理员添加备注
        public int orderRemarkUpdate(String id, String remark, int formerStatus, int newStatus, int operateUserId) {
            if (orderDb.orderRemarkUpdate(id, remark, newStatus) != 1)
            {
                return -1;
            }

            if (orderDb.orderLogCreate(id, operateUserId, formerStatus, newStatus) != 1)
            {
                return -2;
            }

            return 1;
        }

        //工单状态更新（完成一项任务）
        //public int orderStatusUpdate(String orderId, int orderStatus, int userId)
        //{
        //    if (orderDb.orderStatusUpdate(orderId, orderStatus) != 1)
        //    {
        //        return -1;
        //    }

        //    if (orderDb.orderTaskComplete(orderId, orderStatus) != 1) { return -2; }

        //    if (orderStatus < 8)
        //    {
        //        if (orderDb.orderTaskCreate(orderId, userId, orderStatus) != 1) { return -3; }
        //    }

        //    return 1;
        //}

        //工单查询 根据工单号 返回DataSet：tabel 0为工单 1客户 2工具 3备件 4维修站 5工单记录 6跟单技术员 7创建人 8管理者
        public DataSet orderQueryByOrderId(String orderId)
        {
            DataSet orderInfoDataSet = new DataSet();
            DataTable dt = orderDb.orderQueryByOrderId(orderId).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            dt.TableName = "OrderInfoTable";
            orderInfoDataSet.Tables.Add(addOrderStatusText(dt.Copy()));
            int customerId = Convert.ToInt16(dt.Rows[0]["CustomerId"]);
            int stationId = Convert.ToInt16(dt.Rows[0]["StationId"]);
            int createUserId = Convert.ToInt16(dt.Rows[0]["CreateUserId"]);
            int technicianId = Convert.ToInt16(dt.Rows[0]["TechnicianId"]);
            int adminId = Convert.ToInt16(dt.Rows[0]["AdminId"]);

            CustomerDB customerDb = new CustomerDB();
            dt = customerDb.customerQueryByCustomerId(customerId).Tables[0];
            dt.TableName = "CustomerTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            ProductDB productDb = new ProductDB();
            dt = productDb.productQuery(orderId).Tables[0];
            dt.TableName = "ProductTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            SparePartDB sparePartDb = new SparePartDB();
            dt = sparePartDb.sparePartQuery(orderId).Tables[0];
            dt.TableName = "SparePartTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            StationDB stationDb = new StationDB();
            dt = stationDb.stationQueryByStationId(stationId).Tables[0];
            dt.TableName = "StationTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            dt = orderDb.orderLogQuery(orderId).Tables[0];
            dt.TableName = "OrderLogTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            UserDB userDb = new UserDB();
            dt = userDb.userQueryByUserId(technicianId).Tables[0];
            dt.TableName = "TechnicianTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            dt = userDb.userQueryByUserId(createUserId).Tables[0];
            dt.TableName = "CreateUserTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            dt = userDb.userQueryByUserId(adminId).Tables[0];
            dt.TableName = "AdminTable";
            orderInfoDataSet.Tables.Add(dt.Copy());

            return orderInfoDataSet;
        }

        //工单任务查询
        public DataTable orderQueryByTask(int userId, int userType)
        {
            Boolean isAdmin;
            if (userType > 2)
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }

            DataSet ds = orderDb.orderQueryByTask(userId, isAdmin);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return addOrderStatusText(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        //工单模糊查询
        public DataTable orderListQueryVaguely(String orderId, int workType, int technicianId, int customerId, String productName, String serialNumber, int stationId, int orderStatus)
        {
            DataSet ds = orderDb.orderListQueryVaguely(orderId, workType, technicianId, customerId, productName, serialNumber, stationId, orderStatus);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return addOrderStatusText(ds.Tables[0]);
            }
            else
            {
                return null;
            }
        }

        //为工单表加入工单状态文字说明
        protected DataTable addOrderStatusText(DataTable orderTable)
        {
            orderTable.Columns.Add("OrderStatusStr", Type.GetType("System.String"));

            int index = 0;
            foreach (DataRow dr in orderTable.Rows)
            {
                switch (dr["OrderStatus"].ToString())
                {
                    case "1": orderTable.Rows[index]["OrderStatusStr"] = "等待客户审核"; break;
                    case "2": orderTable.Rows[index]["OrderStatusStr"] = "等待检查"; break;
                    case "3": orderTable.Rows[index]["OrderStatusStr"] = "等待报价"; break;
                    case "4": orderTable.Rows[index]["OrderStatusStr"] = "等待客户确认"; break;
                    case "5": orderTable.Rows[index]["OrderStatusStr"] = "等待备件到齐"; break;
                    case "6": orderTable.Rows[index]["OrderStatusStr"] = "等待维修"; break;
                    case "7": orderTable.Rows[index]["OrderStatusStr"] = "等待发货"; break;
                    case "8": orderTable.Rows[index]["OrderStatusStr"] = "完成"; break;
                }
                index++;
            }
            return orderTable;
        }
    }
}