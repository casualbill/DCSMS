<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userCreate.aspx.cs" Inherits="DCSMS.Web.user.userCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    用户名：<asp:TextBox ID="tb_username" runat="server" MaxLength="50"></asp:TextBox><br />
    密码：<asp:TextBox ID="tb_password" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox><br />
    重复密码：<asp:TextBox ID="tb_password_repeat" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox><br />
    姓名：<asp:TextBox ID="tb_realname" runat="server" MaxLength="50"></asp:TextBox><br />
    工号：<asp:TextBox ID="tb_empcode" runat="server" MaxLength="20"></asp:TextBox><br />
    电话：<asp:TextBox ID="tb_telephone" runat="server" MaxLength="20"></asp:TextBox><br />
    Email：<asp:TextBox ID="tb_email" runat="server" MaxLength="50"></asp:TextBox><br />
    用户组：<asp:RadioButtonList ID="rbl_usertype" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
        <asp:ListItem Text="Guest" Value="1"></asp:ListItem>
        <asp:ListItem Text="Technician" Value="2"></asp:ListItem>
        <asp:ListItem Text="Admin" Value="3"></asp:ListItem>
        <asp:ListItem Text="Manager" Value="4"></asp:ListItem>
        <asp:ListItem Text="Super Manager" Value="5"></asp:ListItem>
    </asp:RadioButtonList><br /><br />
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
</asp:Content>
