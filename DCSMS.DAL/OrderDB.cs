﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DCSMS.DAL
{
    public class OrderDB : DBHelper
    {
        public int orderCreate(String id, String failureDescription, String imgUrl, DateTime createTime, int stationId)
        {
            String sqlCommand = "insert into orderinfo values (@Id, @FailureDescription, @ImgUrl, @CreateTime, null, @StationId, 1)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@Id", id));
            paramList.Add(new MySqlParameter("@FailureDescription", failureDescription));
            paramList.Add(new MySqlParameter("@ImgUrl", imgUrl));
            paramList.Add(new MySqlParameter("@CreateTime", createTime));
            paramList.Add(new MySqlParameter("@StationId", stationId));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int orderStatusUpdate(int orderStatus, DateTime updateTime, String id)
        {
            String sqlCommand = "update orderinfo set OrderStatus = @OrderStatus, UpdateTime = @UpdateTime where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderStatus", orderStatus));
            paramList.Add(new MySqlParameter("@UpdateTime", updateTime));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet orderQuery(String id)
        {
            String sqlCommand = "select * from orderinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public int orderLogInsert(String orderId, int userId, int formerStatus, int newStatus, DateTime operateTime)
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

        public DataSet orderLogQuery(String orderId)
        {
            String sqlCommand = "select * from orderlog where orderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
