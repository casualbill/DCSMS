using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;

namespace DCSMS.Web.user
{
    public partial class userCreate : System.Web.UI.Page
    {
        protected UserLogic userLogic = new UserLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String userName = tb_username.Text.Trim().ToLower();
            String password = tb_password.Text;
            String passwordRepeat = tb_password_repeat.Text;
            int userType = Convert.ToInt16(rbl_usertype.SelectedValue);

            if (userName.Length < 4 || password.Length < 6 || password != passwordRepeat)
            {
                lb_tips.Text = "error";
            }
            else
            {
                int retVal;

                List<String> userInfo = new List<String>();
                userInfo.Add(userName);
                userInfo.Add(password);
                userInfo.Add(tb_realname.Text.Trim());
                userInfo.Add(tb_empcode.Text.Trim());
                userInfo.Add(tb_telephone.Text.Trim());
                userInfo.Add(tb_email.Text.Trim());

                retVal = userLogic.userCreate(userInfo, userType);
                
                if (retVal == 1)
                {
                    lb_tips.Text = "success";
                }
                else if (retVal == -1)
                {
                    lb_tips.Text = "user exist";
                }
                else
                {
                    lb_tips.Text = "fail";
                }
            }
        }
    }
}