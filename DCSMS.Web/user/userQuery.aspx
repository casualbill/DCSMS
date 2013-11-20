<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userQuery.aspx.cs" Inherits="DCSMS.Web.user.userQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, user_query %>"></asp:Literal>
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li>
                <label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, username %>"></asp:Literal>：</label>
                <asp:TextBox ID="tb_query_text" runat="server" MaxLength="50"></asp:TextBox>
                <asp:HiddenField ID="hf_query_text" runat="server" />
                <asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClick="btn_submit_Click" CssClass="small-button" />
            </li>
        </ul></div>
    
        <asp:Panel ID="pn_table" runat="server">
            <table>
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, userid %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, username %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, real_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, emp_code %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, telephone %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, email %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, user_type %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, operation %>"></asp:Literal></th>
                </tr>
            <asp:Repeater ID="rpt_userinfo" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("RealName") %></td>
                        <td><%# Eval("EmpCode") %></td>
                        <td><%# Eval("Telephone") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("UserTypeStr") %></td>
                        <td>
                            <a href="userUpdate.aspx?id=<%# Eval("Id") %>"><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, edit %>"></asp:Literal></a>
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
