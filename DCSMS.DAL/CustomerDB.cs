using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DCSMS.DAL
{
    public class CustomerDB : DBHelper
    {
        public int customerCreate(List<String> customerInfo, Boolean verify)
        {
            String sqlCommand = "insert into customerinfo values (null, @CustomerName, @EndCustomerName, @ContactPerson, @Telephone, @Mobile, @Address, @PostCode, @Remark, @Verified)";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@CustomerName", customerInfo[0]));
            paramList.Add(new MySqlParameter("@EndCustomerName", customerInfo[1]));
            paramList.Add(new MySqlParameter("@ContactPerson", customerInfo[2]));
            paramList.Add(new MySqlParameter("@Telephone", customerInfo[3]));
            paramList.Add(new MySqlParameter("@Mobile", customerInfo[4]));
            paramList.Add(new MySqlParameter("@Address", customerInfo[5]));
            paramList.Add(new MySqlParameter("@PostCode", customerInfo[6]));
            paramList.Add(new MySqlParameter("@Remark", customerInfo[7]));
            paramList.Add(new MySqlParameter("@Verified", verify));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int customerUpdate(int id, List<String> customerInfo)
        {
            String sqlCommand = "update customerinfo set CustomerName = @CustomerName, EndCustomerName = @EndCustomerName, ContactPerson = @ContactPerson, Telephone = @Telephone, Mobile = @Mobile, Address = @Address, PostCode = @PostCode, Remark = @Remark where Id = @Id";

            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@CustomerName", customerInfo[0]));
            paramList.Add(new MySqlParameter("@EndCustomerName", customerInfo[1]));
            paramList.Add(new MySqlParameter("@ContactPerson", customerInfo[2]));
            paramList.Add(new MySqlParameter("@Telephone", customerInfo[3]));
            paramList.Add(new MySqlParameter("@Mobile", customerInfo[4]));
            paramList.Add(new MySqlParameter("@Address", customerInfo[5]));
            paramList.Add(new MySqlParameter("@PostCode", customerInfo[6]));
            paramList.Add(new MySqlParameter("@Remark", customerInfo[7]));
            paramList.Add(new MySqlParameter("@Id", id));

            return executeSqlCommandNoQuery(sqlCommand, paramList);
        }

        public int customerVerify(int id)
        {
            String sqlCommand = "update customerinfo set Verified = 1 where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandNoQuery(sqlCommand, param);
        }

        public DataSet userQueryByCustomerId(int id)
        {
            String sqlCommand = "select * from customerinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByCustomerName(String customerName)
        {
            String sqlCommand = "select * from customerinfo where CustomerName = @CustomerName";
            MySqlParameter param = new MySqlParameter("@CustomerName", customerName);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByCustomerNameVaguely(String customerName)
        {
            String sqlCommand = "select * from customerinfo where CustomerName like @customerName";
            MySqlParameter param = new MySqlParameter("@customerName", customerName + "%");
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet userQueryByVerified(Boolean verify)
        {
            String sqlCommand = "select * from customerinfo where Verified = @Verified";
            MySqlParameter param = new MySqlParameter("@Verified", verify);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
