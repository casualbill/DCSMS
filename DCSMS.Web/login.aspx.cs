using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected UserLogic userLogic = new UserLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String userName = tb_username.Text.Trim().ToLower();
            String password = tb_password.Text.Trim().ToLower();

            List<String> userInfoStr = userLogic.validateUserLogin(userName, password);
            if (userInfoStr.Count > 0)
            {
                Session["userId"] = userInfoStr[0];
                Session["userName"] = userInfoStr[1];
                Session["userType"] = userInfoStr[3];

                //登录成功后跳转。。。
                lb_loginfo.Text = "ok！";
            }
            else
            {
                lb_loginfo.Text = "用户名或密码错误，请重新输入！";
            }
        }
    }
}