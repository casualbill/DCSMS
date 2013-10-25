using System;
using System.Data;
using System.Web;
using DCSMS.BLL;

namespace DCSMS.Web.user
{
    public partial class userQuery : System.Web.UI.Page
    {
        protected UserLogic userLogic = new UserLogic();
        protected String pageStr;
        protected int pageIndex;
        protected int pageAmount;
        protected String queryText;

        protected void Page_Load(object sender, EventArgs e)
        {
            permissionVerify pv = new permissionVerify(4);

            pageStr = Request.QueryString["page"];
            queryText = Request.QueryString["str"];
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

            DataTable dt;
            if (queryText == null || queryText.Length == 0)
            {
                dt = userLogic.userQuery(pageIndex, out pageAmount);
            }
            else
            {
                dt = userLogic.userQueryByUserNameVaguely(HttpUtility.UrlDecode(queryText), false, pageIndex, out pageAmount);
            }

            if (dt != null)
            {
                lb_tips.Text = "";
                lb_tips.Visible = false;
                rpt_userinfo.DataSource = dt;
                rpt_userinfo.DataBind();
                pn_table.Visible = true;
                pageController(pageIndex, pageAmount);

                hf_query_text.Value = HttpUtility.UrlDecode(queryText);
                hf_pageindex.Value = pageIndex.ToString();
            }
            else
            {
                lb_tips.Text = "没有符合条件的用户！";
                lb_tips.Visible = true;
                pn_table.Visible = false;
            }
        }

        protected void btn_turntopage_click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(hf_query_text.Value);
            Response.Redirect("userQuery.aspx?str=" + queryText + "&page=" + tb_pageindex.Text);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(tb_query_text.Text.Trim().ToLower());
            Response.Redirect("userQuery.aspx?str=" + queryText);
        }

        protected void link_pagination_prev_click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(hf_query_text.Value);
            Response.Redirect("userQuery.aspx?str=" + queryText + "&page=" + (Convert.ToInt16(hf_pageindex.Value) - 1).ToString());
        }

        protected void link_pagination_next_click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(hf_query_text.Value);
            Response.Redirect("userQuery.aspx?str=" + queryText + "&page=" + (Convert.ToInt16(hf_pageindex.Value) + 1).ToString());
        }
        

        protected void pageController(int pageIndex, int pageAmount)
        {
            lb_pageindex.Visible = true;
            lb_pageamount.Visible = true;
            lb_pageindex.Text = "第" + pageIndex + "页";
            lb_pageamount.Text = "共" + pageAmount + "页";

            if (pageAmount > 1)
            {
                pagination_frame.Visible = true;

                if (pageIndex == 1)
                {
                    link_pagination_prev.Visible = false;
                }
                if (pageIndex == pageAmount)
                {
                    link_pagination_next.Visible = false;
                }
            }
            else
            {
                pagination_frame.Visible = false;
            }
        }
    }
}