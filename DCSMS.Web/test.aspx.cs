using System;
using DCSMS.BLL;
using System.Collections.Generic;
using System.Web;

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

        protected void bt_upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile.FileName == "" && FileUpload2.PostedFile.FileName == "" && FileUpload3.PostedFile.FileName == "")
            {
                lb_info.Text = "请选择文件！";
            }
            else
            {
                HttpFileCollection myfiles = Request.Files;
                for (int i = 0; i < myfiles.Count; i++)
                {
                    HttpPostedFile mypost = myfiles[i];
                    try
                    {
                        if (mypost.ContentLength > 0)
                        {
                            string filepath = mypost.FileName;//C:\Documents and Settings\Administrator\My Documents\My Pictures\20022775_m.jpg 
                            string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//20022775_m.jpg 
                            string serverpath = Server.MapPath("/uploads/") + filename;//C:\Inetpub\wwwroot\WebSite2\images\20022775_m.jpg 
                            mypost.SaveAs(serverpath);
                            this.lb_info.Text = "上传成功！";
                        }
                    }
                    catch (Exception ex)
                    {
                        lb_info.Text = "上传发生错误！原因：" + ex.Message.ToString();
                    }
                }
            }
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