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
                lb_tips.Text = "error";
            }
            else
            {
                int retVal;
                if (userType == 2)
                {
                    String telephone = tb_telephone.Text.Trim();
                    String email = tb_email.Text.Trim();
                    retVal = userLogic.engineerUpdate(userId, userName, telephone, email);
                }
                else
                {
                    retVal = userLogic.userUpdate(userId, userName, userType);
                }

                if (retVal == 1)
                {
                    lb_tips.Text = "success";
                }
                else
                {
                    lb_tips.Text = "fail";
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
                    rbl_usertype.Items.FindByValue(userInfoStr[3]).Selected = true;
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert (\"该用户不存在！\"); window.location.href=\"userQuery.aspx\";</script>");
                }

            }
        }
    }
}