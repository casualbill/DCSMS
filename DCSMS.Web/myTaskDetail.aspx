<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTaskDetail.aspx.cs" Inherits="DCSMS.Web.myTaskDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    工单号：<asp:Label ID="lb_orderid" runat="server"></asp:Label><br />
    工作类型：<asp:Label ID="lb_worktype" runat="server"></asp:Label><br />
    维修站：<asp:Label ID="lb_stationname" runat="server"></asp:Label><br />
    <br />
    工具型号：<asp:Label ID="lb_productname" runat="server"></asp:Label><br />
    工具序列号：<asp:Label ID="lb_serialnumber" runat="server"></asp:Label><br />
    工具订货号：<asp:Label ID="lb_product_orderingnumber" runat="server"></asp:Label><br />
    固件版本：<asp:Label ID="lb_product_firmware" runat="server"></asp:Label><br />
    备注：<asp:Label ID="lb_product_remark" runat="server"></asp:Label><br />
    <br />
    故障描述：<asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox><br />
    照片选择：<asp:TextBox ID="tb_imgurl" MaxLength="300" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox><br />
    <br />
    当前状态：<asp:Label ID="lb_orderstatus" runat="server"></asp:Label><br />

    <asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" /><br />

    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />

</asp:Content>
