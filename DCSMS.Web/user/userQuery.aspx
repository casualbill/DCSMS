<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userQuery.aspx.cs" Inherits="DCSMS.Web.user.userQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:TextBox ID="tb_query_text" runat="server" MaxLength="50"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
    <table>
        <tr>
            <th>ID</th>
            <th>用户名</th>
            <th>用户组</th>
            <th>技术员姓名</th>
            <th>电话</th>
            <th>Email</th>
            <th>操作</th>
        </tr>
    <asp:Repeater ID="rpt_userinfo" runat="server">
        <ItemTemplate>

            <tr>
                <td><%# Eval("Id") %></td>
                <td><%# Eval("UserName") %></td>
                <td><%# Eval("UserTypeStr") %></td>
                <td><%# Eval("RealName") %></td>
                <td><%# Eval("Telephone") %></td>
                <td><%# Eval("Email") %></td>
                <td>
                    <a href="userUpdate.aspx?id=<%# Eval("Id") %>">编辑</a>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
