﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DCSMS.DAL
{
    public class ProductDB : DBHelper
    {
        public int productCreate(List<String> productInfo, String orderId)
        {
            String sqlCommand = "insert into productinfo values (null, @ProductName, @SerialNumber, @OrderingNumber, @CycleCounters, @FirmwareVersion, @Remark, @OrderId)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ProductName", productInfo[0]));
            paramList.Add(new MySqlParameter("@SerialNumber", productInfo[1]));
            paramList.Add(new MySqlParameter("@OrderingNumber", productInfo[2]));
            paramList.Add(new MySqlParameter("@CycleCounters", productInfo[3]));
            paramList.Add(new MySqlParameter("@FirmwareVersion", productInfo[4]));
            paramList.Add(new MySqlParameter("@Remark", productInfo[5]));
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int productUpdate(List<String> productInfo, int id)
        {
            String sqlCommand = "update productinfo set ProductName = @ProductName, SerialNumber = @SerialNumber, OrderingNumber = @OrderingNumber, CycleCounters = @CycleCounters, FirmwareVersion = @FirmwareVersion, Remark = @Remark where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@ProductName", productInfo[0]));
            paramList.Add(new MySqlParameter("@SerialNumber", productInfo[1]));
            paramList.Add(new MySqlParameter("@OrderingNumber", productInfo[2]));
            paramList.Add(new MySqlParameter("@CycleCounters", productInfo[3]));
            paramList.Add(new MySqlParameter("@FirmwareVersion", productInfo[4]));
            paramList.Add(new MySqlParameter("@Remark", productInfo[5]));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet productQuery(String orderId)
        {
            String sqlCommand = "select * from productinfo where orderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}