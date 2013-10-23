﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DCSMS.Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/global.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <table cellpadding="0" cellspacing="0" class="login-table">
            <tr>
                <td width="40%" class="login-item-text">用户名：</td>
                <td width="60%"><asp:TextBox ID="tb_username" runat="server" MaxLength="32"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="login-item-text">密码：</td>
                <td><asp:TextBox ID="tb_password" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="login-item-text"></td>
                <td><asp:Button ID="btn_submit" OnClick="btn_submit_Click" runat="server" Text="登录" /></td>
            </tr>
            <tr>
                <td class="login-item-text"></td>
                <td><asp:Label ID="lb_loginfo" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
