using System;
using DCSMS.BLL;
using System.Collections.Generic;

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

            Object[] objArray = new Object[5] { "a", 1, 5, "b", "x" };
            objTest(objArray);

            List<List<String>> listArray = new List<List<String>>();

            for (int i = 1; i < 5; i++) {
                List<String> subList = new List<string>();
                for (int j = 1; j < 7; j++)
                {
                    subList.Add((i * 10 + j).ToString());
                }
                listArray.Add(subList);
            }

            doubleListTest(listArray);
            
        }

        protected void onButtonClick(object sender, EventArgs e)
        {
            label.Text = userLogic.getMD5HashCode(textBox.Text);
        }

        protected void objTest(Object[] objA)
        {
            foreach (Object obj in objA)
            {
                Response.Write(obj.ToString());
            }
        }

        protected void doubleListTest(List<List<String>> listArray)
        {
            foreach (List<String> subList in listArray)
            {
                foreach (String str in subList)
                {
                    Response.Write(str + " ");
                }
                Response.Write("<br />");
            }
        }
    }
}