<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTask.aspx.cs" Inherits="DCSMS.Web.myTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, mytask %>"></asp:Literal>
    </div>

    <div class="main-content">
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_id %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, create_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_customer_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, product_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, serial_number %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, failure_description %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, operation %>"></asp:Literal></th>
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
