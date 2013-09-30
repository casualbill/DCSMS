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
        public int orderOperationInsert(String orderId, int userId, int formerStatus, int newStatus, DateTime operateTime)
        {
            String sqlCommand = "insert into orderlog values (null, @OrderId, @UserId, @FormerStatus, @NewStatus, @OperateTime)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));
            paramList.Add(new MySqlParameter("@UserId", userId));
            paramList.Add(new MySqlParameter("@FormerStatus", formerStatus));
            paramList.Add(new MySqlParameter("@NewStatus", newStatus));
            paramList.Add(new MySqlParameter("@OperateTime", operateTime));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet orderOperationQuery(String orderId)
        {
            String sqlCommand = "select * from orderlog where orderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
