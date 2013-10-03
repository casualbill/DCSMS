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
        public int orderCreate(String id, String failureDescription, String imgUrl, int stationId)
        {
            String sqlCommand = "insert into orderinfo values (@Id, @FailureDescription, @ImgUrl, now(), null, @StationId, 1)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@Id", id));
            paramList.Add(new MySqlParameter("@FailureDescription", failureDescription));
            paramList.Add(new MySqlParameter("@ImgUrl", imgUrl));
            paramList.Add(new MySqlParameter("@StationId", stationId));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderStatusUpdate(int orderStatus, String id)
        {
            String sqlCommand = "update orderinfo set OrderStatus = @OrderStatus, UpdateTime = now() where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet orderQuery(String id)
        {
            String sqlCommand = "select * from orderinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
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

        public DataSet orderLogQuery(String orderId)
        {
            String sqlCommand = "select * from orderlog where orderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
