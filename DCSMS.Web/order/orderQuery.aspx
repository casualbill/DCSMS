﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderQuery.aspx.cs" Inherits="DCSMS.Web.order.orderQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            userAjaxSelector($('#tb_technician'), true);
            customerAjaxSelector($('[title="customerName"]'), null, 1, true);
            customerAjaxSelector($('[title="endCustomerName"]'), null, 2, true);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_query %>"></asp:Literal>
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_id %>"></asp:Literal>：</label><asp:TextBox ID="tb_orderid" MaxLength="15" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_name %>"></asp:Literal>：</label><input type="text" title="customerName" />
            <asp:HiddenField ID="hf_customerid" Value="0" runat="server" /></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_customer_name %>"></asp:Literal>：</label><input type="text" title="endCustomerName" /></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, product_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_productname" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, serial_number %>"></asp:Literal>：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, station %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_station" AutoPostBack="true" OnSelectedIndexChanged="ddl_station_changed" runat="server"></asp:DropDownList></li>
            <asp:HiddenField ID="hf_stationid" Value="0" runat="server" />
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_type %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_worktype" AutoPostBack="true" OnSelectedIndexChanged="ddl_worktype_changed" runat="server">
                <asp:ListItem Text="请选择工作类型" Value="0"></asp:ListItem>
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList></li>
            <asp:HiddenField ID="hf_worktype" Value="0" runat="server" />
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_orderstatus" AutoPostBack="true" OnSelectedIndexChanged="ddl_orderstatus_changed" runat="server">
                <asp:ListItem Text="请选择状态" Value="0"></asp:ListItem>
                <asp:ListItem Text="等待客户审核" Value="1"></asp:ListItem>
                <asp:ListItem Text="等待检查" Value="2"></asp:ListItem>
                <asp:ListItem Text="等待报价" Value="3"></asp:ListItem>
                <asp:ListItem Text="等待客户确认" Value="4"></asp:ListItem>
                <asp:ListItem Text="等待备件到齐" Value="5"></asp:ListItem>
                <asp:ListItem Text="等待维修" Value="6"></asp:ListItem>
                <asp:ListItem Text="等待发货" Value="7"></asp:ListItem>
                <asp:ListItem Text="完成" Value="8"></asp:ListItem>
            </asp:DropDownList></li>
            <asp:HiddenField ID="hf_orderstatus" Value="0" runat="server" />
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, responsible_technician %>"></asp:Literal>：</label><input type="text" id="tb_technician" />
            <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" /></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" Visible="false" CssClass="content-tips"></asp:Label>

        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_id %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_customer_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, product_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, serial_number %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, create_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, operation %>"></asp:Literal></th>
                </tr>
            <asp:Repeater ID="rpt_orderinfo" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("OrderId")%></td>
                        <td><%# Eval("CustomerName")%></td>
                        <td><%# Eval("EndCustomerName")%></td>
                        <td><%# Eval("ProductName")%></td>
                        <td><%# Eval("SerialNumber")%></td>
                        <td><%# Eval("CreateTime")%></td>
                        <td><%# Eval("OrderStatusStr")%></td>
                        <td>
                            <a href="orderDetail.aspx?id=<%# Eval("OrderId") %>"><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, show_detail %>"></asp:Literal></a>
                        </td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
