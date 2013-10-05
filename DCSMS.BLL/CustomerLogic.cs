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
        public int customerCreate(List<String> customerInfo, Boolean verify)
        {
            return customerDb.customerCreate(customerInfo, verify);
        }

        //客户信息修改 返回：0失败，1成功
        public int customerUpdate(int id, List<String> customerInfo)
        {
            return customerDb.customerUpdate(id, customerInfo);
        }

        //客户审核通过
        public int customerVerify(int id)
        {
            return customerDb.customerVerify(id);
        }


        //客户查询（所有）
        public DataTable customerQuery() {
            DataSet ds = customerDb.customerQuery();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //客户查询 根据客户Id
        public List<String> customerQueryByCustomerId(int id)
        {
            List<String> customerInfoStr = new List<string>();
            DataRow dr = customerDb.customerQueryByCustomerId(id).Tables[0].Rows[0];
            foreach (Object obj in dr.ItemArray)
            {
                customerInfoStr.Add(obj.ToString());
            }

            return customerInfoStr;
        }

        //客户查询 根据客户名称
        public List<String> customerQueryByCustomerName(String customerName)
        {
            List<String> customerInfoStr = new List<string>();
            DataRow dr = customerDb.customerQueryByCustomerName(customerName).Tables[0].Rows[0];
            foreach (Object obj in dr.ItemArray)
            {
                customerInfoStr.Add(obj.ToString());
            }

            return customerInfoStr;
        }

        //客户查询 根据客户名模糊查询
        public DataTable customerQueryByCustomerNameVaguely(String queryStr)
        {
            DataSet ds = customerDb.customerQueryByCustomerNameVaguely(queryStr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //未审核客户查询
        public DataTable unverifiedCustomerQuery()
        {
            DataSet ds = customerDb.customerQueryByVerified(false);
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
