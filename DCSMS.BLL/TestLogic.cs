using System.Data;
using DCSMS.DAL;

namespace DCSMS.BLL
{
    public class TestLogic
    {
        TestDB testDb = new TestDB();

        public DataTable testQueryList()
        {
            return testDb.testDbQuery().Tables[0];
        }

        public string testQueryCount()
        {
            return testDb.testDbCount();
        }
    }
}
