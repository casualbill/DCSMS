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
        public int orderCreate(String id, String failureDescription, String imgUrl, int createUserId, int customerId, int stationId)
        {
            String sqlCommand = "insert into orderinfo values (@Id, @FailureDescription, @ImgUrl, now(), null, @CreateUserId, @CustomerId, @StationId, 1)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@Id", id));
            paramList.Add(new MySqlParameter("@FailureDescription", failureDescription));
            paramList.Add(new MySqlParameter("@ImgUrl", imgUrl));
            paramList.Add(new MySqlParameter("@CreateUserId", createUserId));
            paramList.Add(new MySqlParameter("@CustomerId", customerId));
            paramList.Add(new MySqlParameter("@StationId", stationId));

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

        public DataSet orderQueryByOrderId(String id)
        {
            String sqlCommand = "select * from orderinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet orderListQueryVaguely(String orderId, int customerId, String productName, String serialNumber, int stationId, int orderStatus)
        {
            String sqlCommand = "select orderinfo.Id as OrderId, CustomerName, ProductName, SerialNumber, FailureDescription, OrderStatus from orderinfo " +
    "inner join customerinfo on orderinfo.customerId = customerinfo.Id " +
    "inner join productinfo on orderinfo.Id = productinfo.OrderId " +
    "inner join stationinfo on orderinfo.stationId = stationinfo.Id " +
    "where ";

            List<MySqlParameter> paramList = new List<MySqlParameter>();

            if (orderId != null && orderId.Length > 3) {
                sqlCommand += "orderinfo.Id like @OrderId ";
                paramList.Add(new MySqlParameter("@OrderId", orderId + "%"));
            }

            if (customerId != 0) {
                sqlCommand += "CustomerId = @CustomerId ";
                paramList.Add(new MySqlParameter("@CustomerId", customerId));
            }

            if (productName != null && productName.Length > 1) {
                sqlCommand += "ProductName like @ProductName ";
                paramList.Add(new MySqlParameter("@ProductName", productName + "%"));
            }

            if (serialNumber != null && serialNumber.Length > 1)
            {
                sqlCommand += "SerialNumber like @SerialNumber ";
                paramList.Add(new MySqlParameter("@SerialNumber", serialNumber + "%"));
            }

            if (stationId != 0)
            {
                sqlCommand += "StationId = @StationId ";
                paramList.Add(new MySqlParameter("@StationId", stationId));
            }

            if (orderStatus != 0)
            {
                sqlCommand += "OrderStatus = @OrderStatus ";
                paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            }

            return executeSqlCommandDataSet(sqlCommand, paramList);
        }


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

        //如果需要取消工单，使用修改UserId的update

        public DataSet orderTaskQuery(int userId)
        {
            String sqlCommand = "select * from orderlog where UserId = @UserId and NewStatus is null";
            MySqlParameter param = new MySqlParameter("@UserId", userId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet orderLogQuery(String orderId)
        {
            String sqlCommand = "select * from orderlog where OrderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
