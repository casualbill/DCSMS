using System;
using System.Collections.Generic;
using System.Data;
using DCSMS.DAL;

namespace DCSMS.BLL
{
    public class CustomerLogic
    {
        protected CustomerDB customerDb = new CustomerDB();
        protected const int pageSize = 50;

        //新建客户 返回：0失败，1成功
        public int customerCreate(List<String> customerInfo, Boolean verify, int cityId)
        {
            return customerDb.customerCreate(customerInfo, verify, cityId);
        }

        //客户信息修改 返回：0失败，1成功
        public int customerUpdate(int id, List<String> customerInfo)
        {
            return customerDb.customerUpdate(id, customerInfo);
        }

        //客户审核通过
        public int customerVerify(int id, int userType)
        {
            if (userType < 3) { return -1; }
            else
            {
                return customerDb.customerVerify(id);
            }
        }

        //所有客户查询
        public DataTable customerQuery(int page, out int pageAmount)
        {
            int offset = (page - 1) * pageSize;
            int amount;
            DataSet ds = customerDb.customerQuery(offset, pageSize, out amount);
            pageAmount = amount / pageSize + 1;

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //已审核客户查询
        public DataTable verifiedCustomerQuery()
        {
            DataSet ds = customerDb.verifiedCustomerQuery();
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
        //客户查询 根据城市ID及客户名模糊查询
        public DataTable customerQueryByCustomerNameVaguely(String queryStr, int cityId)
        {
            DataSet ds = customerDb.customerQueryByCustomerNameVaguely(queryStr, cityId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        //客户查询 根据客户名模糊查询 （包含技术员信息） 分页
        public DataTable customerQueryByCustomerNameVaguely(String queryStr, int page, out int pageAmount)
        {
            int offset = (page - 1) * pageSize;
            int amount;
            DataSet ds = customerDb.customerQueryByCustomerNameVaguely(queryStr, offset, pageSize, out amount);
            pageAmount = amount / pageSize + 1;

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        //客户查询 根据 终客户名模糊查询
        public DataTable customerQueryByEndCustomerNameVaguely(String queryStr)
        {
            DataSet ds = customerDb.customerQueryByEndCustomerNameVaguely(queryStr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        //客户查询 根据城市ID及 终客户名模糊查询
        public DataTable customerQueryByEndCustomerNameVaguely(String queryStr, int cityId)
        {
            DataSet ds = customerDb.customerQueryByEndCustomerNameVaguely(queryStr, cityId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
        //客户查询 根据 终客户名模糊查询 （包含技术员信息） 分页
        public DataTable customerQueryByEndCustomerNameVaguely(String queryStr, int page, out int pageAmount)
        {
            int offset = (page - 1) * pageSize;
            int amount;
            DataSet ds = customerDb.customerQueryByEndCustomerNameVaguely(queryStr, offset, pageSize, out amount);
            pageAmount = amount / pageSize + 1;

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

        //获取省份列表
        public DataTable provinceListQuery()
        {
            RegionDB regionDb = new RegionDB();
            return regionDb.provinceListQuery().Tables[0];
        }

        //获取城市列表
        public DataTable cityListQuery(int provinceId)
        {
            RegionDB regionDb = new RegionDB();
            return regionDb.cityListQuery(provinceId).Tables[0];
        }
    }
}
