<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerUpdate.aspx.cs" Inherits="DCSMS.Web.customer.customerUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        客户查询
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label>客户ID：</label><asp:Label ID="lb_customerid" runat="server"></asp:Label></li>
            <li><label>客户名称：</label><asp:TextBox ID="tb_customername" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label>终客户名称：</label><asp:TextBox ID="tb_endcustomername" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label>联系人：</label><asp:TextBox ID="tb_contactperson" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>电话：</label><asp:TextBox ID="tb_telephone" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label>手机：</label><asp:TextBox ID="tb_mobile" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label>地址：</label><asp:TextBox ID="tb_address" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label>邮编：</label><asp:TextBox ID="tb_postcode" runat="server" MaxLength="10"></asp:TextBox></li>
            <li><label>备注：</label><asp:TextBox ID="tb_remark" runat="server" MaxLength="300"></asp:TextBox></li>
            <li><label></label><asp:Button ID="Button1" runat="server" Text="确定" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
    </div>
</asp:Content>
