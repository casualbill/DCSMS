<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderCreate.aspx.cs" Inherits="DCSMS.Web.order.orderCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    客户：
    <asp:RadioButtonList ID="rbl_customer" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbl_customer_change">
        <asp:ListItem Text="选择已有" Value="0" Selected="True"></asp:ListItem>
        <asp:ListItem Text="新建" Value="1"></asp:ListItem>
    </asp:RadioButtonList><br />

    <asp:DropDownList ID="ddl_customer" AutoPostBack="true" OnSelectedIndexChanged="ddl_customer_changed" runat="server"></asp:DropDownList>
    CustomerName：<asp:TextBox ID="tb_customername" runat="server" MaxLength="100" Enabled="false"></asp:TextBox><br />
    EndCustomerName：<asp:TextBox ID="tb_endcustomername" runat="server" MaxLength="100" Enabled="false"></asp:TextBox><br />
    ContactPerson：<asp:TextBox ID="tb_contactperson" runat="server" MaxLength="50" Enabled="false"></asp:TextBox><br />
    Telephone：<asp:TextBox ID="tb_telephone" runat="server" MaxLength="20" Enabled="false"></asp:TextBox><br />
    Mobile：<asp:TextBox ID="tb_mobile" runat="server" MaxLength="20" Enabled="false"></asp:TextBox><br />
    Address: <asp:TextBox ID="tb_address" runat="server" MaxLength="100" Enabled="false"></asp:TextBox><br />
    PostCode：<asp:TextBox ID="tb_postcode" runat="server" MaxLength="10" Enabled="false"></asp:TextBox><br />
    

    故障描述：<asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox><br />
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
</asp:Content>
