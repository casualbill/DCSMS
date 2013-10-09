using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DCSMS.DAL
{
    public class OrderDB : DBHelper
    {
        public int orderCreate(String id, String remark, int workType, int createUserId, int technicianId, int customerId, int stationId, int orderStatus)
        {
            String sqlCommand = "insert into orderinfo values (@Id, null, null, @Remark, @WorkType, now(), null, @CreateUserId, @TechnicianId, 0, @CustomerId, @StationId, @OrderStatus)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@Id", id));
            paramList.Add(new MySqlParameter("@Remark", remark));
            paramList.Add(new MySqlParameter("@WorkType", workType));
            paramList.Add(new MySqlParameter("@CreateUserId", createUserId));
            paramList.Add(new MySqlParameter("@TechnicianId", technicianId));
            paramList.Add(new MySqlParameter("@CustomerId", customerId));
            paramList.Add(new MySqlParameter("@StationId", stationId));
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        //public int orderCreate(String id, String failureDescription, String imgUrl, int createUserId, int customerId, int stationId)
        //{
        //    String sqlCommand = "insert into orderinfo values (@Id, @FailureDescription, @ImgUrl, now(), null, @CreateUserId, @CustomerId, @StationId, 1)";

        //    List<MySqlParameter> paramList = new List<MySqlParameter>();
        //    paramList.Add(new MySqlParameter("@Id", id));
        //    paramList.Add(new MySqlParameter("@FailureDescription", failureDescription));
        //    paramList.Add(new MySqlParameter("@ImgUrl", imgUrl));
        //    paramList.Add(new MySqlParameter("@CreateUserId", createUserId));
        //    paramList.Add(new MySqlParameter("@CustomerId", customerId));
        //    paramList.Add(new MySqlParameter("@StationId", stationId));

        //    return executeSqlCommandNoQuery(sqlCommand, paramList);
        //}

        public int orderTotallyUpdate(String id, String failureDescription, String imgUrl, String remark, int workType, int technicianId, int adminId, int customerId, int orderStatus)
        {
            String sqlCommand = "update orderinfo set FailureDescription = @FailureDescription, ImgUrl = @ImgUrl, Remark = @Remark, WorkType = @WorkType, TechnicianId = @TechnicianId, AdminId = @AdminId, CustomerId = @CustomerId, OrderStatus = @OrderStatus, UpdateTime = now() where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@FailureDescription", failureDescription));
            paramList.Add(new MySqlParameter("@ImgUrl", imgUrl));
            paramList.Add(new MySqlParameter("@Remark", remark));
            paramList.Add(new MySqlParameter("@WorkType", workType));
            paramList.Add(new MySqlParameter("@TechnicianId", technicianId));
            paramList.Add(new MySqlParameter("@AdminId", adminId));
            paramList.Add(new MySqlParameter("@CustomerId", customerId));
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderCheckUpdate(String id, String failureDescription, String imgUrl, String remark, int orderStatus)
        {
            String sqlCommand = "update orderinfo set FailureDescription = @FailureDescription, ImgUrl = @ImgUrl, Remark = @Remark, OrderStatus = @OrderStatus, UpdateTime = now() where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@FailureDescription", failureDescription));
            paramList.Add(new MySqlParameter("@ImgUrl", imgUrl));
            paramList.Add(new MySqlParameter("@Remark", remark));
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderRemarkUpdate(String id, String remark, int orderStatus)
        {
            String sqlCommand = "update orderinfo set Remark = @Remark, OrderStatus = @OrderStatus, UpdateTime = now() where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@Remark", remark));
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderStatusUpdate(String id, int orderStatus)
        {
            String sqlCommand = "update orderinfo set OrderStatus = @OrderStatus, UpdateTime = now() where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderAdminUpdate(String id, int adminId)
        {
            String sqlCommand = "update orderinfo set AdminId = @AdminId where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@AdminId", adminId));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet orderQueryByOrderId(String id)
        {
            String sqlCommand = "select * from orderinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet orderQueryByTask(int userId, Boolean isAdmin)
        {
            String sqlCommand = "select * from orderinfo ";
            if (isAdmin)
            {
                sqlCommand += "where AdminId in (0, @UserId) and orderStatus in (1, 3, 4, 7)";
            }
            else
            {
                sqlCommand += "where TechnicianId = @UserId and orderStatus in (2, 5, 6)";
            }

            MySqlParameter param = new MySqlParameter("@UserId", userId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet orderListQueryVaguely(String orderId, int workType, int technicianId, int customerId, String productName, String serialNumber, int stationId, int orderStatus)
        {
            String sqlCommand = "select orderinfo.Id as OrderId, WorkType, UserName, CustomerName, ProductName, SerialNumber, StationName, FailureDescription, OrderStatus from orderinfo " +
    "inner join userinfo on orderinfo.technicianId = userinfo.Id " +
    "inner join customerinfo on orderinfo.customerId = customerinfo.Id " +
    "inner join productinfo on orderinfo.Id = productinfo.OrderId " +
    "inner join stationinfo on orderinfo.stationId = stationinfo.Id " +
    "where ";

            List<MySqlParameter> paramList = new List<MySqlParameter>();

            if (orderId != null && orderId.Length > 2)
            {
                sqlCommand += "orderinfo.Id like @OrderId ";
                paramList.Add(new MySqlParameter("@OrderId", orderId + "%"));
            }

            if (workType != 0)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "WorkType = @WorkType ";
                paramList.Add(new MySqlParameter("@WorkType", workType));
            }

            if (technicianId != 0)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "TechnicianId = @TechnicianId ";
                paramList.Add(new MySqlParameter("@TechnicianId", technicianId));
            }

            if (customerId != 0)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "CustomerId = @CustomerId ";
                paramList.Add(new MySqlParameter("@CustomerId", customerId));
            }

            if (productName != null && productName.Length > 2)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "ProductName like @ProductName ";
                paramList.Add(new MySqlParameter("@ProductName", productName + "%"));
            }

            if (serialNumber != null && serialNumber.Length > 2)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "SerialNumber like @SerialNumber ";
                paramList.Add(new MySqlParameter("@SerialNumber", serialNumber + "%"));
            }

            if (stationId != 0)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "StationId = @StationId ";
                paramList.Add(new MySqlParameter("@StationId", stationId));
            }

            if (orderStatus != 0)
            {
                if (paramList.Count > 0)
                {
                    sqlCommand += "and ";
                }
                sqlCommand += "OrderStatus = @OrderStatus ";
                paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            }

            return executeSqlCommandDataSet(sqlCommand, paramList);
        }

        public String orderIdCount(String stationCode, String year)
        {
            String sqlCommand = "select count(*) from orderinfo where Id like @Type";
            MySqlParameter param = new MySqlParameter("@Type", stationCode + year + "%");
            return executeSqlCommandScalar(sqlCommand, param);
        }

        /*
        public int orderTaskCreate(String orderId, int userId, int formerStatus)
        {
            String sqlCommand = "insert into orderlog values (null, @OrderId, @UserId, @FormerStatus, null, now(), null)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));
            paramList.Add(new MySqlParameter("@UserId", userId));
            paramList.Add(new MySqlParameter("@FormerStatus", formerStatus));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderTaskComplete(String orderId, int newStatus)
        {
            String sqlCommand = "update orderlog set NewStatus = @NewStatus, OperateTime = now() where OrderId = @OrderId and NewStatus is null";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));
            paramList.Add(new MySqlParameter("@NewStatus", newStatus));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }
         */

        public int orderLogCreate(String orderId, int userId, int formerStatus, int newStatus) {
            String sqlCommand = "insert into orderlog values (null, @OrderId, @UserId, @FormerStatus, @NewStatus, now())";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));
            paramList.Add(new MySqlParameter("@UserId", userId));
            paramList.Add(new MySqlParameter("@FormerStatus", formerStatus));
            paramList.Add(new MySqlParameter("@NewStatus", newStatus));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        //public DataSet orderTaskQuery(int userId)
        //{
        //    String sqlCommand = "select * from orderlog where UserId = @UserId and NewStatus is null";
        //    MySqlParameter param = new MySqlParameter("@UserId", userId);
        //    return executeSqlCommandDataSet(sqlCommand, param);
        //}

        public DataSet orderLogQuery(String orderId)
        {
            String sqlCommand = "select * from orderlog where OrderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
