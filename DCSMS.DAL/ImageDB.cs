using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DCSMS.DAL
{
    public class ImageDB:DBHelper
    {
        public int imageCreate(String imgUrl, String orderId)
        {
            String sqlCommand = "insert into imageinfo values (null, @FileUrl, @OrderId)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@FileUrl", imgUrl));
            paramList.Add(new MySqlParameter("@OrderId", orderId));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int imageDelete(int id)
        {
            String sqlCommand = "delete from imageinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandNoQuery(sqlCommand, param);
        }

        public DataSet imageQueryByOrderId(String orderId)
        {
            String sqlCommand = "select * from imageinfo where orderId = @OrderId order by Id";
            MySqlParameter param = new MySqlParameter("@OrderId", orderId);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public String imageUrlQueryById(int id)
        {
            String sqlCommand = "select FileUrl from imageinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandScalar(sqlCommand, param);
        }
    }
}
