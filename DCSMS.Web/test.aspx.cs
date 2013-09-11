using System;
using DCSMS.BLL;

namespace DCSMS.Web
{
    public partial class test : System.Web.UI.Page
    {
        TestLogic testLogic = new TestLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            dataGrid.DataSource = testLogic.testQueryList();
            dataGrid.DataBind();
        }
    }
}