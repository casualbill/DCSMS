<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTask.aspx.cs" Inherits="DCSMS.Web.myTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
    <table>
        <tr>
            <th>工单号</th>
            <th>故障描述</th>
            <th>备注</th>
            <th>工单状态</th>
            <th>操作</th>
        </tr>
    <asp:Repeater ID="rpt_orderinfo" runat="server">
        <ItemTemplate>

            <tr>
                <td><%# Eval("Id")%></td>
                <td><%# Eval("FailureDescription")%></td>
                <td><%# Eval("Remark")%></td>
                <td><%# Eval("OrderStatusStr")%></td>
                <td>
                    <a href="mayTaskDetail.aspx?id=<%# Eval("Id") %>">查看详情</a>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
