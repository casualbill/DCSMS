using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCSMS.BLL;
using System.Data;

namespace DCSMS.Web.customer
{
    public partial class customerQuery : System.Web.UI.Page
    {
        protected CustomerLogic customerLogic = new CustomerLogic();
        protected String pageStr;
        protected int pageIndex;
        protected int pageAmount;
        protected String queryText;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                dt = customerLogic.customerQuery(pageIndex, out pageAmount);
            }
            else
            {
                dt = customerLogic.customerQueryByCustomerNameVaguely(HttpUtility.UrlDecode(queryText), pageIndex, out pageAmount);
            }

            if (dt != null)
            {
                lb_tips.Text = "";
                lb_tips.Visible = false;
                rpt_customerinfo.DataSource = dt;
                rpt_customerinfo.DataBind();
                pn_table.Visible = true;
                pageController(pageIndex, pageAmount);

                hf_query_text.Value = HttpUtility.UrlDecode(queryText);
                hf_pageindex.Value = pageIndex.ToString();
            }
            else
            {
                lb_tips.Text = "没有符合条件的客户！";
                lb_tips.Visible = true;
                pn_table.Visible = false;
            }
        }

        protected void btn_turntopage_click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(hf_query_text.Value);
            Response.Redirect("customerQuery.aspx?str=" + queryText + "&page=" + tb_pageindex.Text);
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(tb_query_text.Text.Trim().ToLower());
            Response.Redirect("customerQuery.aspx?str=" + queryText);
        }

        protected void link_pagination_prev_click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(hf_query_text.Value);
            Response.Redirect("customerQuery.aspx?str=" + queryText + "&page=" + (Convert.ToInt16(hf_pageindex.Value) - 1).ToString());
        }

        protected void link_pagination_next_click(object sender, EventArgs e)
        {
            queryText = HttpUtility.HtmlEncode(hf_query_text.Value);
            Response.Redirect("customerQuery.aspx?str=" + queryText + "&page=" + (Convert.ToInt16(hf_pageindex.Value) + 1).ToString());
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