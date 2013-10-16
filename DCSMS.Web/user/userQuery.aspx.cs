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
    public partial class userQuery : System.Web.UI.Page
    {
        protected UserLogic userLogic = new UserLogic();
        protected String pageStr;
        protected int pageIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            pageStr = Request.QueryString["page"];
            int pageInt;
            if (int.TryParse(pageStr, out pageInt))
            {
                if (pageInt > 0)
                {
                    pageIndex = pageInt;
                }
                else
                {
                    pageIndex = 1;
                }
            }
            else
            {
                pageIndex = 1;
            }

            int pageAmount;
            rpt_userinfo.DataSource = userLogic.userQuery(pageIndex, out pageAmount);
            rpt_userinfo.DataBind();
            pageController(pageIndex, pageAmount);
        }

        protected void btn_turntopage_click(object sender, EventArgs e)
        {
            Response.Redirect("userQuery.aspx?page=" + tb_pageindex.Text);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            String queryText = tb_query_text.Text.Trim().ToLower();
            DataTable dt = userLogic.userQueryByUserNameVaguely(queryText, false);
            if (dt != null)
            {
                lb_tips.Text = "";
                lb_tips.Visible = false;
                rpt_userinfo.DataSource = dt;
                rpt_userinfo.DataBind();
                pn_table.Visible = true;
            }
            else
            {
                lb_tips.Text = "没有符合条件的用户！";
                lb_tips.Visible = true;
                pn_table.Visible = false;
            }
        }

        protected void pageController(int pageIndex, int pageAmount)
        {
            pagination_pageindex.Visible = true;
            pagination_pageamount.Visible = true;
            pagination_pageindex.InnerHtml = "第" + pageIndex + "页";
            pagination_pageamount.InnerHtml = "共" + pageAmount + "页";

            if (pageAmount > 1)
            {
                pagination_frame.Visible = true;

                if (pageIndex == 1)
                {
                    pagination_prev.InnerHtml = "";
                    pagination_next.InnerHtml = "<a href=\"userQuery.aspx?page=" + (pageIndex + 1).ToString() + "\">下一页</a>";
                }
                if (pageIndex == pageAmount)
                {
                    pagination_prev.InnerHtml = "<a href=\"userQuery.aspx?page=" + (pageIndex - 1).ToString() + "\">上一页</a>";
                    pagination_next.InnerHtml = "";
                }
                if (pageIndex > 1 && pageIndex < pageAmount)
                {
                    pagination_prev.InnerHtml = "<a href=\"userQuery.aspx?page=" + (pageIndex - 1).ToString() + "\">上一页</a>";
                    pagination_next.InnerHtml = "<a href=\"userQuery.aspx?page=" + (pageIndex + 1).ToString() + "\">下一页</a>";
                }
            }
            else
            {
                pagination_frame.Visible = false;
            }
        }
    }
}