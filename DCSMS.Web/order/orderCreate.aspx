<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderCreate.aspx.cs" Inherits="DCSMS.Web.order.orderCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    工作类型：<asp:DropDownList ID="ddl_worktype" AutoPostBack="true" OnSelectedIndexChanged="ddl_worktype_changed" runat="server">
        <asp:ListItem Text="请选择工作类型" Value=""></asp:ListItem>
        <asp:ListItem Text="质保" Value="1"></asp:ListItem>
        <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
        <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
        <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
    </asp:DropDownList><br />
    <asp:HiddenField ID="hf_worktype" Value="" runat="server" /><br />
    <br />

    客户：
    <asp:RadioButtonList ID="rbl_customer" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbl_customer_change">
        <asp:ListItem Text="选择已有" Value="0" Selected="True"></asp:ListItem>
        <asp:ListItem Text="新建" Value="1"></asp:ListItem>
    </asp:RadioButtonList><br />

    <asp:DropDownList ID="ddl_customer" AutoPostBack="true" OnSelectedIndexChanged="ddl_customer_changed" runat="server"></asp:DropDownList>
    <asp:HiddenField ID="hf_customerid" Value="" runat="server" />
    CustomerName：<asp:TextBox ID="tb_customername" runat="server" MaxLength="100" Enabled="false"></asp:TextBox><br />
    EndCustomerName：<asp:TextBox ID="tb_endcustomername" runat="server" MaxLength="100" Enabled="false"></asp:TextBox><br />
    ContactPerson：<asp:TextBox ID="tb_contactperson" runat="server" MaxLength="50" Enabled="false"></asp:TextBox><br />
    Telephone：<asp:TextBox ID="tb_telephone" runat="server" MaxLength="20" Enabled="false"></asp:TextBox><br />
    Mobile：<asp:TextBox ID="tb_mobile" runat="server" MaxLength="20" Enabled="false"></asp:TextBox><br />
    Address：<asp:TextBox ID="tb_address" runat="server" MaxLength="100" Enabled="false"></asp:TextBox><br />
    PostCode：<asp:TextBox ID="tb_postcode" runat="server" MaxLength="10" Enabled="false"></asp:TextBox><br />
    
    <br /><br />

    工具型号：<asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox><br />
    序列号：<asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox><br />
    订货号：<asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox><br />
    固件版本：<asp:TextBox ID="tb_firmwareversion" MaxLength="20" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox><br />

    <br /><br />

    工作站：<asp:DropDownList ID="ddl_station" AutoPostBack="true" OnSelectedIndexChanged="ddl_station_changed" runat="server"></asp:DropDownList>
    <asp:HiddenField ID="hf_stationid" Value="" runat="server" /><br />

    <br /><br />

    跟单技术员：<asp:DropDownList ID="ddl_technician" AutoPostBack="true" OnSelectedIndexChanged="ddl_technician_changed" runat="server"></asp:DropDownList><br />
    <asp:HiddenField ID="hf_technicianid" Value="" runat="server" /><br />

    备注：<asp:TextBox ID="tb_remark" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox><br />

    <br /><br />

    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
</asp:Content>
