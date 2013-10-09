<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="DCSMS.Web.order.orderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    工单号：<asp:Label ID="lb_orderid" runat="server"></asp:Label><br />
    工作类型：<asp:Label ID="lb_worktype" runat="server"></asp:Label><br />
    故障描述：<asp:Label ID="lb_failure_description" runat="server"></asp:Label><br />
    图片：<asp:Label ID="lb_imgurl" runat="server"></asp:Label><br />
    备注：<asp:Label ID="lb_reamrk" runat="server"></asp:Label><br />
    创建时间：<asp:Label ID="lb_createtime" runat="server"></asp:Label><br />
    状态更新时间：<asp:Label ID="lb_updatetime" runat="server"></asp:Label><br />
    当前状态：<asp:Label ID="lb_orderstatus" runat="server"></asp:Label><br />
    创建者：<asp:Label ID="lb_createuser" runat="server"></asp:Label><br />
    跟单技术员：<asp:Label ID="lb_technician" runat="server"></asp:Label><br />
    管理者：<asp:Label ID="lb_admin" runat="server"></asp:Label><br />
    <br />
    CustomerName：<asp:Label ID="lb_customername" runat="server"></asp:Label><br />
    EndCustomerName：<asp:Label ID="lb_endcustomername" runat="server"></asp:Label><br />
    ContactPerson：<asp:Label ID="lb_contactperson" runat="server"></asp:Label><br />
    Telephone：<asp:Label ID="lb_customer_telephone" runat="server"></asp:Label><br />
    Mobile：<asp:Label ID="lb_customer_mobile" runat="server"></asp:Label><br />
    Address：<asp:Label ID="lb_customer_address" runat="server"></asp:Label><br />
    PostCode：<asp:Label ID="lb_customer_postcode" runat="server"></asp:Label><br />
    <br />
    工具型号：<asp:Label ID="lb_productname" runat="server"></asp:Label><br />
    工具序列号：<asp:Label ID="lb_serialnumber" runat="server"></asp:Label><br />
    工具订货号：<asp:Label ID="lb_product_orderingnumber" runat="server"></asp:Label><br />
    固件版本：<asp:Label ID="lb_product_firmware" runat="server"></asp:Label><br />
    备注：<asp:Label ID="lb_product_remark" runat="server"></asp:Label><br />
    <br />
    备件名：<asp:Label ID="lb_sparepartname" runat="server"></asp:Label><br />
    备件订单号：<asp:Label ID="lb_sparepart_orderingnumber" runat="server"></asp:Label><br />
    备件数量：<asp:Label ID="lb_sparepart_amount" runat="server"></asp:Label><br />
    备注：<asp:Label ID="lb_sparepart_remark" runat="server"></asp:Label><br />
    <br />
    维修站：<asp:Label ID="lb_stationname" runat="server"></asp:Label><br />

</asp:Content>
