using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class StationDB : DBHelper
    {
        public int stationCreate(String stationName, String stationNameSimple)
        {
            String sqlCommand = "insert into stationinfo values (null, @StationName, @StationNameSimple)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@StationName", stationName));
            paramList.Add(new MySqlParameter("@StationNameSimple", stationNameSimple));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int stationUpdate(String stationName, String stationNameSimple, int id)
        {
            String sqlCommand = "update stationinfo set StationName = @StationName, StationNameSimple = @StationNameSimple where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@StationName", stationName));
            paramList.Add(new MySqlParameter("@StationNameSimple", stationNameSimple));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet stationQuery()
        {
            String sqlCommand = "select * from stationinfo";
            return executeSqlCommandDataSet(sqlCommand);
        }

        public DataSet stationQueryByStationId(int id)
        {
            String sqlCommand = "select * from stationinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
