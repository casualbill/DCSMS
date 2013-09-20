<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userQuery.aspx.cs" Inherits="DCSMS.Web.user.userQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="tb_query_text" runat="server" MaxLength="50"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
    <table>
        <tr>
            <th>ID</th>
            <th>用户名</th>
            <th>用户组</th>
            <th>操作</th>
        </tr>
    <asp:Repeater ID="rpt_userinfo" runat="server">
        <ItemTemplate>

            <tr>
                <td><%# Eval("Id") %></td>
                <td><%# Eval("UserName") %></td>
                <td><%# Eval("UserTypeStr") %></td>
                <td>
                    <a href="userUpdate.aspx?id=<%# Eval("Id") %>">编辑</a>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:Repeater>
    </table>

    </form>
</body>
</html>
