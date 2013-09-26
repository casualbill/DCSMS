<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userUpdate.aspx.cs" Inherits="DCSMS.Web.user.userUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    用户ID：<asp:Label ID="lb_userid" runat="server"></asp:Label><br />
    用户名：<asp:TextBox ID="tb_username" runat="server" MaxLength="50"></asp:TextBox><br />
    用户组：<asp:RadioButtonList ID="rbl_usertype" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
        <asp:ListItem Text="Guest" Value="1"></asp:ListItem>
        <asp:ListItem Text="Technician" Value="2"></asp:ListItem>
        <asp:ListItem Text="Admin" Value="3"></asp:ListItem>
        <asp:ListItem Text="Manager" Value="4"></asp:ListItem>
        <asp:ListItem Text="Super Manager" Value="5"></asp:ListItem>
    </asp:RadioButtonList><br />
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
</asp:Content>
