using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DCSMS.DAL
{
    public class TestDB : DBHelper
    {
        public DataSet testDbQuery()
        {
            String sqlCommandStr = "select * from test";
            return executeSqlCommandDataSet(sqlCommandStr);
        }

        public String testDbCount()
        {
            String sqlCommandStr = "select count(*) from test";
            return executeSqlCommandScalar(sqlCommandStr);
        }
    }
}
