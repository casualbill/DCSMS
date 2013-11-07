using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class RepairLogDB : DBHelper
    {
        public int repairLogCreate(DateTime startTime, DateTime endTime, String workDetail, String defaultCharacter, String workTime, String orderId)
        {
            String sqlCommand = "insert into repairlog values (null, @StartTime, @EndTime, @WorkDetail, @DefaultCharacter, @WorkTime, @OrderId)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@StartTime", startTime));
            paramList.Add(new MySqlParameter("@EndTime", endTime));
            paramList.Add(new MySqlParameter("@WorkDetail", workDetail));
            paramList.Add(new MySqlParameter("@DefaultCharacter", defaultCharacter));
            paramList.Add(new MySqlParameter("@WorkTime", workTime));
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int repairLogUpdate(DateTime startTime, DateTime endTime, String workDetail, String defaultCharacter, String workTime, int id)
        {
            String sqlCommand = "update repairlog set StartTime = @StartTime, EndTime = @EndTime, WorkDetail = @WorkDetail, DefaultCharacter = @DefaultCharacter, WorkTime = @WorkTime where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@StartTime", startTime));
            paramList.Add(new MySqlParameter("@EndTime", endTime));
            paramList.Add(new MySqlParameter("@WorkDetail", workDetail));
            paramList.Add(new MySqlParameter("@DefaultCharacter", defaultCharacter));
            paramList.Add(new MySqlParameter("@WorkTime", workTime));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet repairLogQuery(String orderId)
        {
            String sqlCommand = "select * from repairlog where orderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
