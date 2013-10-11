using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DCSMS.DAL
{
    public class SparePartDB : DBHelper
    {
        public int sparePartCreate(List<String> sparePartInfo, String orderId)
        {
            String sqlCommand = "insert into sparepartinfo values (null, @SparePartName, @OrderingNumber, @Amount, @Remark, @OrderId)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@SparePartName", sparePartInfo[0]));
            paramList.Add(new MySqlParameter("@OrderingNumber", sparePartInfo[1]));
            paramList.Add(new MySqlParameter("@Amount", Convert.ToInt16(sparePartInfo[2])));
            paramList.Add(new MySqlParameter("@Remark", sparePartInfo[3]));
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int sparePartUpdate(List<String> sparePartInfo, int id)
        {
            String sqlCommand = "update sparepartinfo set SparePartName = @SparePartName, OrderingNumber = @OrderingNumber, Amount = @Amount, Remark = @Remark where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@SparePartName", sparePartInfo[0]));
            paramList.Add(new MySqlParameter("@OrderingNumber", sparePartInfo[1]));
            paramList.Add(new MySqlParameter("@Amount", Convert.ToInt16(sparePartInfo[2])));
            paramList.Add(new MySqlParameter("@Remark", sparePartInfo[3]));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public DataSet sparePartQuery(String orderId) {
            String sqlCommand = "select * from sparepartinfo where orderId = @OrderId";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}