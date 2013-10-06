<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderQuery.aspx.cs" Inherits="DCSMS.Web.order.orderQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    工单号：<asp:TextBox ID="tb_orderid" MaxLength="15" runat="server"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>

    <table>
        <tr>
            <th>工单号</th>
            <th>客户名</th>
            <th>工具型号</th>
            <th>工具序列号</th>
            <th>故障描述</th>
            <th>订单状态</th>
            <th>操作</th>
        </tr>
    <asp:Repeater ID="rpt_orderinfo" runat="server">
        <ItemTemplate>

            <tr>
                <td><%# Eval("OrderId")%></td>
                <td><%# Eval("customerName")%></td>
                <td><%# Eval("productName")%></td>
                <td><%# Eval("SerialNumber")%></td>
                <td><%# Eval("FailureDescription")%></td>
                <td><%# Eval("OrderStatusStr")%></td>
                <td>
                    <a href="#?id=<%# Eval("OrderId") %>">查看详情</a>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
