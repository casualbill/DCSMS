<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userCreate.aspx.cs" Inherits="DCSMS.Web.user.userCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        用户添加
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label>用户名：</label><asp:TextBox ID="tb_username" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>密码：</label><asp:TextBox ID="tb_password" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox></li>
            <li><label>重复密码：</label><asp:TextBox ID="tb_password_repeat" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox></li>
            <li><label>姓名：</label><asp:TextBox ID="tb_realname" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>工号：</label><asp:TextBox ID="tb_empcode" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label>电话：</label><asp:TextBox ID="tb_telephone" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label>Email：</label><asp:TextBox ID="tb_email" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>用户组：</label><asp:RadioButtonList ID="rbl_usertype" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical" CssClass="radiobox-vertical">
                <asp:ListItem Text="Guest" Value="1"></asp:ListItem>
                <asp:ListItem Text="Technician" Value="2"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="3"></asp:ListItem>
                <asp:ListItem Text="Manager" Value="4"></asp:ListItem>
                <asp:ListItem Text="Super Manager" Value="5"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
    </div>
</asp:Content>
