using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web.user
{
    public partial class userUpdate : System.Web.UI.Page
    {
        protected UserLogic userLogic = new UserLogic();
        protected String urlQueryId;

        protected void Page_Load(object sender, EventArgs e)
        {
            permissionVerify pv = new permissionVerify(4);

            if (!IsPostBack)
            {
                urlQueryId = Request.QueryString["id"];
                getUserDetails();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt16(lb_userid.Text);
            String userName = tb_username.Text.Trim().ToLower();
            int userType = Convert.ToInt16(rbl_usertype.SelectedValue);

            if (userName.Length < 4)
            {
                lb_tips.Text = "请完整填写用户信息！";
            }
            else
            {
                List<String> userInfo = new List<String>();
                userInfo.Add(userName);
                userInfo.Add(tb_realname.Text.Trim());
                userInfo.Add(tb_empcode.Text.Trim());
                userInfo.Add(tb_telephone.Text.Trim());
                userInfo.Add(tb_email.Text.Trim());

                if (userLogic.userUpdate(userInfo, userId, userType) == 1)
                {
                    lb_tips.Text = "修改成功！";
                }
                else
                {
                    lb_tips.Text = "系统错误！";
                }
            }
        }

        protected void getUserDetails()
        {
            int userId;
            if (urlQueryId == null)
            {
                Response.Write("<script type=\"text/javascript\">alert (\"该用户不存在！\"); window.location.href=\"userQuery.aspx\";</script>");
            }
            else if (!int.TryParse(urlQueryId, out userId))
            {
                Response.Write("<script type=\"text/javascript\">alert (\"非法用户ID！\"); window.location.href=\"userQuery.aspx\";</script>");
            }
            else
            {
                List<String> userInfoStr = userLogic.userQueryByUserId(userId);
                if (userInfoStr.Count > 0)
                {
                    lb_userid.Text = userInfoStr[0];
                    tb_username.Text = userInfoStr[1];
                    tb_realname.Text = userInfoStr[3];
                    tb_empcode.Text = userInfoStr[4];
                    tb_telephone.Text = userInfoStr[5];
                    tb_email.Text = userInfoStr[6];
                    rbl_usertype.Items.FindByValue(userInfoStr[7]).Selected = true;
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该用户不存在！\"); window.location.href=\"userQuery.aspx\";</script>");
                }

            }
        }
    }
}