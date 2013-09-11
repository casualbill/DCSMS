using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DCSMS.DAL
{
    public class TestDB
    {
        DBHelper _dbHelper = new DBHelper();

        public DataSet testDbQuery()
        {
            String sqlCommandStr = "select * from test";
            return _dbHelper.executeSqlCommandDataSet(sqlCommandStr);
        }
    }
}
