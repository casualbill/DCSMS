using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class RegionDB : DBHelper
    {
        public DataSet provinceListQuery()
        {
            String sqlCommand = "select * from provincelist";
            return executeSqlCommandDataSet(sqlCommand);
        }

        public DataSet cityListQuery(int provinceId)
        {
            String sqlCommand = "select * from cityinfo where ProvinceId = @ProvinceId";
            MySqlParameter param = new MySqlParameter("@ProvinceId", provinceId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
