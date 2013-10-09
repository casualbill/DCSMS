<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderUpdate.aspx.cs" Inherits="DCSMS.Web.order.orderUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    工单号：<asp:Label ID="lb_orderid" runat="server"></asp:Label><br />
    工作类型：<asp:DropDownList ID="ddl_worktype" runat="server">
        <asp:ListItem Text="质保" Value="1"></asp:ListItem>
        <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
        <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
        <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
    </asp:DropDownList><br />
    <br />

    <asp:DropDownList ID="ddl_customer" runat="server"></asp:DropDownList>

    
    <br /><br />

    工具型号：<asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox><br />
    序列号：<asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox><br />
    订货号：<asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox><br />
    固件版本：<asp:TextBox ID="tb_product_firmware" MaxLength="20" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox><br />

    <br /><br />

    备件名称：<asp:TextBox ID="tb_sparepartname" MaxLength="50" runat="server"></asp:TextBox><br />
    订货号：<asp:TextBox ID="tb_sparepart_orderingnumber" MaxLength="50" runat="server"></asp:TextBox><br />
    数量：<asp:TextBox ID="tb_sparepart_amount" MaxLength="50" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="tb_sparepart_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox><br />

    <br /><br />

    故障描述：<asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox><br />
    照片选择：<asp:TextBox ID="tb_imgurl" MaxLength="300" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox><br />

    <br /><br />

    跟单技术员：<asp:DropDownList ID="ddl_technician" runat="server"></asp:DropDownList><br />

    <br /><br />

    当前状态：<asp:Label ID="lb_orderstatus" runat="server"></asp:Label><br />
    更新状态：<asp:DropDownList ID="ddl_orderstatus" runat="server">
        <asp:ListItem Text="等待客户审核" Value="1"></asp:ListItem>
        <asp:ListItem Text="等待检查" Value="2"></asp:ListItem>
        <asp:ListItem Text="等待报价" Value="3"></asp:ListItem>
        <asp:ListItem Text="等待客户确认" Value="4"></asp:ListItem>
        <asp:ListItem Text="等待备件到齐" Value="5"></asp:ListItem>
        <asp:ListItem Text="等待维修" Value="6"></asp:ListItem>
        <asp:ListItem Text="等待发货" Value="7"></asp:ListItem>
        <asp:ListItem Text="完成" Value="8"></asp:ListItem>
    </asp:DropDownList><br />

    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
</asp:Content>
