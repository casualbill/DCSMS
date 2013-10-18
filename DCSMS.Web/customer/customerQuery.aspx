<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerQuery.aspx.cs" Inherits="DCSMS.Web.customer.customerQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        客户查询
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li>
                <label>客户名称：</label>
                <asp:TextBox ID="tb_query_text" runat="server" MaxLength="50"></asp:TextBox>
                <asp:HiddenField ID="hf_query_text" runat="server" />
                <asp:Button ID="btn_submit" runat="server" Text="确定" OnClick="btn_submit_Click" CssClass="small-button" />
            </li>
        </ul></div>
    
        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th>客户ID</th>
                    <th>客户名称</th>
                    <th>终客户名称</th>
                    <th>联系人</th>
                    <th>电话</th>
                    <th>手机</th>
                    <th>地址</th>
                    <th>邮编</th>
                    <th>备注</th>
                    <th>操作</th>
                </tr>
            <asp:Repeater ID="rpt_customerinfo" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("CustomerName")%></td>
                        <td><%# Eval("EndCustomerName")%></td>
                        <td><%# Eval("ContactPerson")%></td>
                        <td><%# Eval("Telephone")%></td>
                        <td><%# Eval("Mobile")%></td>
                        <td><%# Eval("Address")%></td>
                        <td><%# Eval("PostCode")%></td>
                        <td><%# Eval("Remark")%></td>
                        <td>
                            <a href="customerUpdate.aspx?id=<%# Eval("Id") %>">编辑</a>
                        </td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>

            <asp:Label ID="lb_totalamount" runat="server" Visible="false"></asp:Label>
            <div class="pagination-wrapper">
                <asp:Label id="lb_pageindex" runat="server"></asp:Label>
                <asp:Label id="lb_pageamount" runat="server"></asp:Label>
                <asp:HiddenField ID="hf_pageindex" runat="server" />
                <div id="pagination_frame" runat="server" visible="false" style="display:inline;">
                    <asp:LinkButton ID="link_pagination_prev" runat="server" OnClick="link_pagination_prev_click" Text="上一页"></asp:LinkButton>
                    <asp:LinkButton ID="link_pagination_next" runat="server" OnClick="link_pagination_next_click" Text="下一页"></asp:LinkButton>
                    转到第<asp:TextBox ID="tb_pageindex" runat="server" MaxLength="3"></asp:TextBox>页
                    <asp:Button ID="btn_turntopage" OnClick="btn_turntopage_click" runat="server" Text="确定" />
                </div>
            </div>
        </asp:Panel>

        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
    </div>
</asp:Content>
