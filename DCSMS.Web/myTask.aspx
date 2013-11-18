<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTask.aspx.cs" Inherits="DCSMS.Web.myTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        我的任务
    </div>

    <div class="main-content">
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th>工单号</th>
                    <th>创建时间</th>
                    <th>客户名称</th>
                    <th>终客户名称</th>
                    <th>工具型号</th>
                    <th>工具序列号</th>
                    <th>故障描述</th>
                    <th>备注</th>
                    <th>工单状态</th>
                    <th>操作</th>
                </tr>
            <asp:Repeater ID="rpt_orderinfo" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("OrderId")%></td>
                        <td><%# Eval("CreateTime")%></td>
                        <td><%# Eval("CustomerName")%></td>
                        <td><%# Eval("EndCustomerName")%></td>
                        <td><%# Eval("ProductName")%></td>
                        <td><%# Eval("SerialNumber")%></td>
                        <td><%# Eval("FailureDescription")%></td>
                        <td><%# Eval("Remark")%></td>
                        <td><%# Eval("OrderStatusStr")%></td>
                        <td>
                            <a href="myTaskDetail.aspx?id=<%# Eval("OrderId") %>">查看详情</a>
                        </td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
