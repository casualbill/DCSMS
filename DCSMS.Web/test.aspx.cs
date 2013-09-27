using System;
using DCSMS.BLL;

namespace DCSMS.Web
{
    public partial class test : System.Web.UI.Page
    {
        TestLogic testLogic = new TestLogic();
        UserLogic userLogic = new UserLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            //dataGrid.DataSource = testLogic.testQueryList();
            //dataGrid.DataBind();
            //label.Text = testLogic.testQueryCount();
        }

        protected void onButtonClick(object sender, EventArgs e)
        {
            label.Text = userLogic.getMD5HashCode(textBox.Text);
        }
    }
}