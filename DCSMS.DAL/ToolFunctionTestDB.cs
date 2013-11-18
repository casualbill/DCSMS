using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class ToolFunctionTestDB : DBHelper
    {
        public int toolFunctionTestCreate(String orderId)
        {
            String sqlCommand = "insert into toolfunctiontest values (@OrderId, 0, 0, 0, 0, 0, 0, null, null, null, null, null, null)";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandNoQuery(sqlCommand, param);
        }

        public int toolFunctionTestUpdate(List<int> toolFunctionTestStatus, List<String> toolFunctionTestComment, String orderId)
        {
            String sqlCommand = "update toolfunctiontest set Item1 = @Item1, Item2 = @Item2, Item3 = @Item3, Item4 = @Item4, Item5 = @Item5, Item6 = @Item6, Comment1 = @Comment1, Comment2 = @Comment2, Comment3 = @Comment3, Comment4 = @Comment4, Comment5 = @Comment5, Comment6 = @Comment6 where OrderId = @OrderId";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            for (int i = 0; i < toolFunctionTestStatus.Count; i++)
            {
                paramList.Add(new MySqlParameter("@Item" + (i + 1).ToString(), toolFunctionTestStatus[i]));
                paramList.Add(new MySqlParameter("@Comment" + (i + 1).ToString(), toolFunctionTestComment[i]));
            }

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet toolFunctionTestQuery(String orderId)
        {
            String sqlCommand = "select * from toolfunctiontest where OrderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
