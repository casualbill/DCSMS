using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DCSMS.DAL
{
    public class CustomerDB : DBHelper
    {
        public int customerCreate(List<String> customerInfo, Boolean verify, int cityId)
        {
            String sqlCommand = "insert into customerinfo values (null, @CustomerName, @EndCustomerName, @ContactPerson, @Telephone, @Mobile, @Address, @PostCode, @Remark, @Verified, @CityId)";

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
            paramList.Add(new MySqlParameter("@CityId", cityId));

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

        public DataSet customerQuery(int offset, int rows, out int amount)
        {
            String sqlCommand = "select * from customerinfo limit @Offset, @Rows";
            String sqlCount = "select count(*) from customerinfo";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@Offset", offset));
            paramList.Add(new MySqlParameter("@Rows", rows));
            amount = Convert.ToInt16(executeSqlCommandScalar(sqlCount));
            return executeSqlCommandDataSet(sqlCommand, paramList);
        }

        public DataSet verifiedCustomerQuery()
        {
            String sqlCommand = "select * from customerinfo where Verified = 1";
            return executeSqlCommandDataSet(sqlCommand);
        }

        public DataSet customerQueryByCustomerId(int id)
        {
            String sqlCommand = "select * from customerinfo where Id = @Id";
            MySqlParameter param = new MySqlParameter("@Id", id);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public DataSet customerQueryByCustomerName(String customerName)
        {
            String sqlCommand = "select * from customerinfo where CustomerName = @CustomerName";
            MySqlParameter param = new MySqlParameter("@CustomerName", customerName);
            return executeSqlCommandDataSet(sqlCommand, param);
        }

        public String customerIdQueryByEndCustomerName(String endCustomerName)
        {
            String sqlCommand = "select Id from customerinfo where EndCustomerName = @EndCustomerName order by Id desc";
            MySqlParameter param = new MySqlParameter("@EndCustomerName", endCustomerName);
            return executeSqlCommandScalar(sqlCommand, param);
        }


        public DataSet customerQueryByCustomerNameVaguely(String customerName)
        {
            String sqlCommand = "select * from customerinfo where CustomerName like @CustomerName limit 10";
            MySqlParameter param = new MySqlParameter("@CustomerName", customerName + "%");
            return executeSqlCommandDataSet(sqlCommand, param);
        }
        public DataSet customerQueryByCustomerNameVaguely(String customerName, int cityId)
        {
            String sqlCommand = "select * from customerinfo where CityId = @CityId and CustomerName like @CustomerName limit 10";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@CustomerName", customerName + "%"));
            paramList.Add(new MySqlParameter("@CityId", cityId));
            return executeSqlCommandDataSet(sqlCommand, paramList);
        }
        public DataSet customerQueryByCustomerNameVaguely(String customerName, int offset, int rows, out int amount)
        {
            String sqlCommand = "select * from customerinfo where CustomerName like @customerName limit @Offset, @Rows";
            String sqlCount = "select count(*) from customerinfo where CustomerName like @CustomerName";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@CustomerName", customerName + "%"));
            paramList.Add(new MySqlParameter("@Offset", offset));
            paramList.Add(new MySqlParameter("@Rows", rows));
            amount = Convert.ToInt16(executeSqlCommandScalar(sqlCount, paramList));
            return executeSqlCommandDataSet(sqlCommand, paramList);
        }


        public DataSet customerQueryByEndCustomerNameVaguely(String endCustomerName)
        {
            String sqlCommand = "select * from customerinfo where EndCustomerName like @EndCustomerName limit 10";
            MySqlParameter param = new MySqlParameter("@EndCustomerName", endCustomerName + "%");
            return executeSqlCommandDataSet(sqlCommand, param);
        }
        public DataSet customerQueryByEndCustomerNameVaguely(String endCustomerName, int cityId)
        {
            String sqlCommand = "select * from customerinfo where CityId = @CityId and EndCustomerName like @EndCustomerName limit 10";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@EndCustomerName", endCustomerName + "%"));
            paramList.Add(new MySqlParameter("@CityId", cityId));
            return executeSqlCommandDataSet(sqlCommand, paramList);
        }
        public DataSet customerQueryByEndCustomerNameVaguely(String endCustomerName, int offset, int rows, out int amount)
        {
            String sqlCommand = "select * from customerinfo where EndCustomerName like @EndCustomerName limit @Offset, @Rows";
            String sqlCount = "select count(*) from customerinfo where EndCustomerName like @EndCustomerName";
            List<MySqlParameter> paramList = new List<MySqlParameter>();
            paramList.Add(new MySqlParameter("@EndCustomerName", endCustomerName + "%"));
            paramList.Add(new MySqlParameter("@Offset", offset));
            paramList.Add(new MySqlParameter("@Rows", rows));
            amount = Convert.ToInt16(executeSqlCommandScalar(sqlCount, paramList));
            return executeSqlCommandDataSet(sqlCommand, paramList);
        }

        public DataSet customerQueryByVerified(Boolean verify)
        {
            String sqlCommand = "select * from customerinfo where Verified = @Verified";
            MySqlParameter param = new MySqlParameter("@Verified", verify);
            return executeSqlCommandDataSet(sqlCommand, param);
        }
    }
}
