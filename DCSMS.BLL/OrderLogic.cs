using System;
using System.Collections.Generic;
using System.Data;
using DCSMS.DAL;

namespace DCSMS.BLL
{
    public class OrderLogic : Utility
    {
        protected OrderDB orderDb = new OrderDB();

        #region 工单

        //新建工单
        public int createOrder(String remark, int workType, Boolean isPublic, List<String> customerInfo, int cityId, int customerId, List<String> productInfo, int createUserId, int technicianId, int stationId)
        {
            int orderStatus = 2;
            ProductDB productDb = new ProductDB();

            String year = DateTime.Now.ToString("yy");
            StationDB stationDb = new StationDB();
            String stationCode = stationDb.stationQueryByStationId(stationId).Tables[0].Rows[0]["StationCode"].ToString();
            int orderIdNum = Convert.ToInt16(orderDb.orderIdCount(stationCode, year)) + 1;
            String orderId = stationCode + year + orderIdNum.ToString("00000");

            //判读客户是否为新建的（需审核）
            if (customerId == 0)
            {
                orderStatus = 1;

                CustomerDB customerDb = new CustomerDB();
                if (customerDb.customerCreate(customerInfo, false, cityId) == 1)
                {
                    customerId = Convert.ToInt16(customerDb.customerIdQueryByEndCustomerName(customerInfo[1]));
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

            if (orderDb.orderCreate(orderId, remark, workType, createUserId, technicianId, customerId, stationId, orderStatus, isPublic) != 1)
            {
                return -3;
            }

            if (orderDb.orderLogCreate(orderId, createUserId, 0, orderStatus) != 1)
            {
                return -4;
            }

            return 1;
        }


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
        public int orderTotallyUpdate(String id, List<String> productInfo, String failureDescription, String remark, int workType, int technicianId, int adminId, int customerId, int formerStatus, int newStatus, Boolean isPublic, int operateUserId)
        {
            ProductDB productDb = new ProductDB();
            if (productDb.productUpdate(productInfo, id) != 1)
            {
                return -1;
            }

            if (orderDb.orderTotallyUpdate(id, failureDescription, remark, workType, technicianId, adminId, customerId, newStatus, isPublic) != 1)
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

        //工单修改：技术员操作
        public int orderTaskOperateByTechnician(String id, String failureDescription, String remark, int formerStatus, List<List<String>> sparePartInfoList, int operateUserId)
        {
            ProductDB productDb = new ProductDB();
            SparePartDB sparePartDb = new SparePartDB();

            if (orderDb.orderCheckUpdate(id, failureDescription, remark, formerStatus + 1) != 1)
            {
                return -2;
            }

            if (orderDb.orderLogCreate(id, operateUserId, formerStatus, formerStatus + 1) != 1)
            {

                return -3;
            }

            return 1;
        }

        //工单修改：管理员操作
        public int orderTaskOperateByAdmin(String id, String remark, int formerStatus, int operateUserId, int adminId)
        {
            if (orderDb.orderRemarkUpdate(id, remark, adminId, formerStatus + 1) != 1)
            {
                return -1;
            }

            if (orderDb.orderLogCreate(id, operateUserId, formerStatus, formerStatus + 1) != 1)
            {
                return -2;
            }

            return 1;
        }


        //工单查询 根据工单号 返回DataSet：tabel 0为工单 1客户 2工具 3备件 4维修站 5工单记录 6跟单技术员 7创建人 8管理者 9维修记录
        public DataSet orderQueryByOrderId(String orderId)
        {
            return orderQueryByOrderId(orderId, false);
        }
        public DataSet orderQueryByOrderId(String orderId, Boolean isOnlyOrderInfo)
        {
            DataSet orderInfoDataSet = new DataSet();
            DataTable dt = orderDb.orderQueryByOrderId(orderId).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            dt.TableName = "OrderInfoTable";
            orderInfoDataSet.Tables.Add(addWorkTypeText(addOrderStatusText(dt.Copy(), true)));

            if (isOnlyOrderInfo == true) { return orderInfoDataSet; }

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
            dt = addToolTypeText(productDb.productQuery(orderId).Tables[0]);
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

            RepairLogDB repairLogDb = new RepairLogDB();
            dt = repairLogDb.repairLogQuery(orderId).Tables[0];
            dt.TableName = "RepairLogTable";
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

        //工单操作权限 适用于Ajax备件操作  返回：1可操作 -1无可操作订单 -2无权限
        public int orderOperatePermission(String orderId, int userId, int userType)
        {
            DataSet ds = orderQueryByOrderId(orderId, true);
            if (ds == null) { return -1; }

            int orderStatus = Convert.ToInt16(ds.Tables[0].Rows[0]["OrderStatus"]);
            if (orderStatus == 8) { return -1; }

            int technicianId = Convert.ToInt16(ds.Tables[0].Rows[0]["TechnicianId"]);
            if (userType < 2) { return -2; }
            else if (userType == 2)
            {
                if (userId != technicianId) { return -2; }
                if (orderStatus != 2 && orderStatus != 5 && orderStatus != 6) { return -2; }
            }
            return 1;
        }
        #endregion


        #region 备件

        //备件查询 根据工单号
        public DataTable sparePartQuery(String orderId)
        {
            SparePartDB sparePartDb = new SparePartDB();
            DataSet ds = sparePartDb.sparePartQuery(orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //添加备件
        public int sparePartAdd(String sparePartName, String orderingNumber, int amount, String remark, String orderId)
        {
            if (sparePartName == "" || sparePartName == null) { return -1; }
            if (orderingNumber == "" || orderingNumber == null) { return -1; }
            if (amount < 1) { return -1; }

            SparePartDB sparePartDb = new SparePartDB();
            List<String> sparePartInfo = new List<String>();
            sparePartInfo.Add(sparePartName);
            sparePartInfo.Add(orderingNumber);
            sparePartInfo.Add(amount.ToString());
            sparePartInfo.Add(remark);

            return sparePartDb.sparePartCreate(sparePartInfo, orderId);
        }

        //修改备件
        public int sparePartUpdate(String sparePartName, String orderingNumber, int amount, String remark, int id)
        {
            if (sparePartName == "" || sparePartName == null) { return -1; }
            if (orderingNumber == "" || orderingNumber == null) { return -1; }
            if (amount < 1) { return -1; }

            SparePartDB sparePartDb = new SparePartDB();
            List<String> sparePartInfo = new List<String>();
            sparePartInfo.Add(sparePartName);
            sparePartInfo.Add(orderingNumber);
            sparePartInfo.Add(amount.ToString());
            sparePartInfo.Add(remark);

            return sparePartDb.sparePartUpdate(sparePartInfo, id);
        }

        //删除备件
        public int sparePartRemove(int id)
        {
            SparePartDB sparePartDb = new SparePartDB();
            return sparePartDb.sparePartDelete(id);
        }
        #endregion


        #region 图片

        //图片查询 根据工单号
        public DataTable imageQuery(String orderId)
        {
            ImageDB imageDb = new ImageDB();
            DataSet ds = imageDb.imageQueryByOrderId(orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //图片URL查询 根据图片ID
        public String imageUrlQuery(int id)
        {
            ImageDB imageDb = new ImageDB();
            return imageDb.imageUrlQueryById(id);
        }

        //添加图片
        public int imageAdd(String imgUrl, String orderId)
        {
            ImageDB imageDb = new ImageDB();
            return imageDb.imageCreate(imgUrl, orderId);
        }

        //删除图片
        public int imageRemove(int id)
        {
            ImageDB imageDb = new ImageDB();
            return imageDb.imageDelete(id);
        }
        #endregion


        #region 维修记录

        //维修记录查询 根据工单号
        public DataTable repairLogQuery(String orderId)
        {
            RepairLogDB repairLogDb = new RepairLogDB();
            DataSet ds = repairLogDb.repairLogQuery(orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //添加维修记录
        public int repairLogAdd(DateTime? startTime, DateTime? endTime, String workDetail, String defaultCharacter, String workTime, String orderId)
        {
            RepairLogDB repairLogDb = new RepairLogDB();
            return repairLogDb.repairLogCreate(startTime, endTime, workDetail, defaultCharacter, workTime, orderId);
        }

        //删除维修记录
        public int repairLogRemove(int id)
        {
            RepairLogDB repairLogDb = new RepairLogDB();
            return repairLogDb.repairLogDelete(id);
        }

        #endregion


        #region 检查结果及工具功能测试

        //创建检查结果
        public int inspectionResultCreate(String orderId)
        {
            InspectionResultDB inspectionResultDb = new InspectionResultDB();
            return inspectionResultDb.inspectionResultCreate(orderId);
        }

        //修改检查结果
        public int inspectionResultUpdate(List<int> inspectionResultStatue, List<String> inspectionResultComment, String orderId)
        {
            InspectionResultDB inspectionResultDb = new InspectionResultDB();

            if (inspectionResultStatue.Count < 8)
            {
                for (int i = inspectionResultStatue.Count; i < 8; i++)
                {
                    inspectionResultStatue.Add(0);
                    inspectionResultComment.Add(null);
                }
            }

            return inspectionResultDb.inspectionResultUpdate(inspectionResultStatue, inspectionResultComment, orderId);
        }

        //查询检查结果
        public DataTable inspectionResultQuery(String orderId)
        {
            InspectionResultDB inspectionResultDb = new InspectionResultDB();
            DataSet ds = inspectionResultDb.inspectionResultQuery(orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //创建工具功能测试
        public int toolFunctionTestCreate(String orderId)
        {
            ToolFunctionTestDB toolFunctionTestDb = new ToolFunctionTestDB();
            return toolFunctionTestDb.toolFunctionTestCreate(orderId);
        }

        //修改工具功能测试
        public int toolFunctionTestUpdate(List<int> toolFunctionTestStatue, List<String> toolFunctionTestComment, String orderId)
        {
            ToolFunctionTestDB toolFunctionTestDb = new ToolFunctionTestDB();

            if (toolFunctionTestStatue.Count < 6)
            {
                for (int i = toolFunctionTestStatue.Count; i < 6; i++)
                {
                    toolFunctionTestStatue.Add(0);
                    toolFunctionTestComment.Add(null);
                }
            }

            return toolFunctionTestDb.toolFunctionTestUpdate(toolFunctionTestStatue, toolFunctionTestComment, orderId);
        }

        //查询工具功能测试
        public DataTable toolFunctionTestQuery(String orderId)
        {
            ToolFunctionTestDB toolFunctionTestDb = new ToolFunctionTestDB();
            DataSet ds = toolFunctionTestDb.toolFunctionTestQuery(orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        #endregion


        #region 工单操作记录

        //工单操作记录查询
        public DataTable orderLogQuery(String orderId)
        {
            DataTable dt = orderDb.orderLogQuery(orderId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("FormerStatusStr", Type.GetType("System.String"));
                dt.Columns.Add("NewStatusStr", Type.GetType("System.String"));

                int index = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr["FormerStatus"].ToString())
                    {
                        case "1": dt.Rows[index]["FormerStatusStr"] = "等待客户审核"; break;
                        case "2": dt.Rows[index]["FormerStatusStr"] = "等待检查"; break;
                        case "3": dt.Rows[index]["FormerStatusStr"] = "等待报价"; break;
                        case "4": dt.Rows[index]["FormerStatusStr"] = "等待客户确认"; break;
                        case "5": dt.Rows[index]["FormerStatusStr"] = "等待备件到齐"; break;
                        case "6": dt.Rows[index]["FormerStatusStr"] = "等待维修"; break;
                        case "7": dt.Rows[index]["FormerStatusStr"] = "等待发货"; break;
                        case "8": dt.Rows[index]["FormerStatusStr"] = "完成"; break;
                    }

                    switch (dr["NewStatus"].ToString())
                    {
                        case "1": dt.Rows[index]["NewStatusStr"] = "等待客户审核"; break;
                        case "2": dt.Rows[index]["NewStatusStr"] = "等待检查"; break;
                        case "3": dt.Rows[index]["NewStatusStr"] = "等待报价"; break;
                        case "4": dt.Rows[index]["NewStatusStr"] = "等待客户确认"; break;
                        case "5": dt.Rows[index]["NewStatusStr"] = "等待备件到齐"; break;
                        case "6": dt.Rows[index]["NewStatusStr"] = "等待维修"; break;
                        case "7": dt.Rows[index]["NewStatusStr"] = "等待发货"; break;
                        case "8": dt.Rows[index]["NewStatusStr"] = "完成"; break;
                    }

                    index++;
                }

                return dt;
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region 在表中加入状态对应文字

        //为工具表加入工具类型文字说明
        protected DataTable addToolTypeText(DataTable productTable)
        {
            productTable.Columns.Add("ToolTypeStr", Type.GetType("System.String"));

            int index = 0;
            foreach (DataRow dr in productTable.Rows)
            {
                switch (dr["ToolType"].ToString())
                {
                    case "1": productTable.Rows[index]["ToolTypeStr"] = "电动装配工具"; break;
                    case "2": productTable.Rows[index]["ToolTypeStr"] = "气动装配工具"; break;
                    case "3": productTable.Rows[index]["ToolTypeStr"] = "控制器"; break;
                    case "4": productTable.Rows[index]["ToolTypeStr"] = "气动打磨工具"; break;
                    case "5": productTable.Rows[index]["ToolTypeStr"] = "电池式工具"; break;
                    case "6": productTable.Rows[index]["ToolTypeStr"] = "附件"; break;
                }
                index++;
            }
            return productTable;
        }

        //为工单表加入工作类型文字说明
        protected DataTable addWorkTypeText(DataTable orderTable)
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
        protected DataTable addOrderStatusText(DataTable orderTable)
        {
            return addOrderStatusText(orderTable, false);
        }

        protected DataTable addOrderStatusText(DataTable orderTable, Boolean showFinishTask)
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
                    case "1": orderTable.Rows[index]["OrderStatusStr"] = "等待客户审核"; break;
                    case "2": orderTable.Rows[index]["OrderStatusStr"] = "等待检查"; break;
                    case "3": orderTable.Rows[index]["OrderStatusStr"] = "等待报价"; break;
                    case "4": orderTable.Rows[index]["OrderStatusStr"] = "等待客户确认"; break;
                    case "5": orderTable.Rows[index]["OrderStatusStr"] = "等待备件到齐"; break;
                    case "6": orderTable.Rows[index]["OrderStatusStr"] = "等待维修"; break;
                    case "7": orderTable.Rows[index]["OrderStatusStr"] = "等待发货"; break;
                    case "8": orderTable.Rows[index]["OrderStatusStr"] = "完成"; break;
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
        #endregion
    }
}