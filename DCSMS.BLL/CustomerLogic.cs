using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DCSMS.DAL;
using System.Data;

namespace DCSMS.BLL
{
    public class CustomerLogic
    {
        protected CustomerDB customerDb = new CustomerDB();

        //新建客户 返回：0失败，1成功
        public int customerCreate(List<String> customerInfo)
        {
            return customerDb.customerCreate(customerInfo);
        }

        //客户信息修改 返回：0失败，1成功
        public int customerUpdate(int id, List<String> customerInfo)
        {
            return customerDb.customerUpdate(id, customerInfo);
        }

        //客户查询 根据客户Id
        public List<String> customerQueryByCustomerId(int id)
        {
            List<String> customerInfoStr = new List<string>();
            DataRow dr = customerDb.userQueryByCustomerId(id).Tables[0].Rows[0];
            foreach (Object obj in dr.ItemArray)
            {
                customerInfoStr.Add(obj.ToString());
            }

            return customerInfoStr;
        }

        //客户查询 根据客户名模糊查询
        public DataTable customerQueryByCustomerNameVaguely(String queryStr)
        {
            DataSet ds = customerDb.userQueryByCustomerNameVaguely(queryStr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}
