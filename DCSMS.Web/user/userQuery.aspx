<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userQuery.aspx.cs" Inherits="DCSMS.Web.user.userQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        用户查询
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li>
                <label>用户名称：</label>
                <asp:TextBox ID="tb_query_text" runat="server" MaxLength="50"></asp:TextBox>
                <asp:HiddenField ID="hf_query_text" runat="server" />
                <asp:Button ID="btn_submit" runat="server" Text="确定" OnClick="btn_submit_Click" CssClass="small-button" />
            </li>
        </ul></div>
    
        <asp:Panel ID="pn_table" runat="server">
            <table>
                <tr>
                    <th>用户ID</th>
                    <th>用户名</th>
                    <th>姓名</th>
                    <th>工号</th>
                    <th>电话</th>
                    <th>Email</th>
                    <th>用户组</th>
                    <th>操作</th>
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
                            <a href="userUpdate.aspx?id=<%# Eval("Id") %>">编辑</a>
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
