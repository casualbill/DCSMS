using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class InspectionResultDB : DBHelper
    {
        public int inspectionResultCreate(List<int> inspectionResultStatus, List<String> inspectionResultComment, String orderId)
        {
            String sqlCommand = "insert into inspectionresult values (@OrderId, @Item1, @Item2, @Item3, @Item4, @Item5, @Item6, @Item7, @Item8, @Comment1, @Comment2, @Comment3, @Comment4, @Comment5, @Comment6, @Comment7, @Comment8)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            for (int i = 0; i < inspectionResultStatus.Count; i++)
            {
                paramList.Add(new MySqlParameter("@Item" + (i + 1).ToString(), inspectionResultStatus[i]));
                paramList.Add(new MySqlParameter("@Comment" + (i + 1).ToString(), inspectionResultComment[i]));
            }

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int inspectionResultUpdate(List<int> inspectionResultStatus, List<String> inspectionResultComment, String orderId)
        {
            String sqlCommand = "update inspectionresult set Item1 = @Item1, Item2 = @Item2, Item3 = @Item3, Item4 = @Item4, Item5 = @Item5, Item6 = @Item6, Item7 = @Item7, Item8 = @Item8, Comment1 = @Comment1, Comment2 = @Comment2, Comment3 = @Comment3, Comment4 = @Comment4, Comment5 = @Comment5, Comment6 = @Comment6, Comment7 = @Comment7, Comment8 = @Comment8 where OrderId = @OrderId";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            for (int i = 0; i < inspectionResultStatus.Count; i++)
            {
                paramList.Add(new MySqlParameter("@Item" + (i + 1).ToString(), inspectionResultStatus[i]));
                paramList.Add(new MySqlParameter("@Comment" + (i + 1).ToString(), inspectionResultComment[i]));
            }

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet inspectionResultQuery(String orderId)
        {
            String sqlCommand = "select * from inspectionresult where OrderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
