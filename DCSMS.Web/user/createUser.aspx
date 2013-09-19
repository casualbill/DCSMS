<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="createUser.aspx.cs" Inherits="DCSMS.Web.user.createUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        用户名：<asp:TextBox ID="tb_username" runat="server" MaxLength="50"></asp:TextBox><br />
        密码：<asp:TextBox ID="tb_password" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox><br />
        重复密码：<asp:TextBox ID="tb_password_repeat" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox><br />
        用户组：<asp:RadioButtonList ID="rbl_usertype" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
            <asp:ListItem Text="Guest" Value="1"></asp:ListItem>
            <asp:ListItem Text="Technician" Value="2"></asp:ListItem>
            <asp:ListItem Text="Admin" Value="3"></asp:ListItem>
            <asp:ListItem Text="Manager" Value="4"></asp:ListItem>
            <asp:ListItem Text="Super Manager" Value="5"></asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
        <asp:Label ID="lb_tips" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
