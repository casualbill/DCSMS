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
            <div id="pagination_wrapper">
                <span id="pagination_pageindex" runat="server"></span>
                <span id="pagination_pageamount" runat="server"></span>
                <div id="pagination_frame" runat="server" visible="false" style="display:inline;">
                    <span id="pagination_prev" runat="server"></span>
                    <span id="pagination_next" runat="server"></span>
                    转到第<asp:TextBox ID="tb_pageindex" runat="server" Width="20"></asp:TextBox>页
                    <asp:Button ID="btn_turntopage" OnClick="btn_turntopage_click" runat="server" Text="确定" />
                </div>
            </div>

        </asp:Panel>

        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
    </div>
</asp:Content>
