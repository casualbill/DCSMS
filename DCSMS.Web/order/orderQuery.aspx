<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderQuery.aspx.cs" Inherits="DCSMS.Web.order.orderQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        工单查询
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label>工单号：</label><asp:TextBox ID="tb_orderid" MaxLength="15" runat="server"></asp:TextBox></li>
            <li><label>客户名称：</label><asp:DropDownList ID="ddl_customer" AutoPostBack="true" OnSelectedIndexChanged="ddl_customer_changed" runat="server"></asp:DropDownList></li>
            <asp:HiddenField ID="hf_customerid" Value="0" runat="server" />
            <li><label>工具型号：</label><asp:TextBox ID="tb_productname" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>工具序列号：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>工作站：</label><asp:DropDownList ID="ddl_station" AutoPostBack="true" OnSelectedIndexChanged="ddl_station_changed" runat="server"></asp:DropDownList></li>
            <asp:HiddenField ID="hf_stationid" Value="0" runat="server" />
            <li><label>工作类型：</label><asp:DropDownList ID="ddl_worktype" AutoPostBack="true" OnSelectedIndexChanged="ddl_worktype_changed" runat="server">
                <asp:ListItem Text="请选择工作类型" Value="0"></asp:ListItem>
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList></li>
            <asp:HiddenField ID="hf_worktype" Value="0" runat="server" />
            <li><label>工单状态：</label><asp:DropDownList ID="ddl_orderstatus" AutoPostBack="true" OnSelectedIndexChanged="ddl_orderstatus_changed" runat="server">
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
            <li><label>跟单技术员：</label><asp:DropDownList ID="ddl_technician" AutoPostBack="true" OnSelectedIndexChanged="ddl_technician_changed" runat="server"></asp:DropDownList></li>
            <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" />

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" Visible="false" CssClass="content-tips"></asp:Label>

        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th>工单号</th>
                    <th>客户名</th>
                    <th>工具型号</th>
                    <th>工具序列号</th>
                    <th>维修站</th>
                    <th>故障描述</th>
                    <th>工单状态</th>
                    <th>操作</th>
                </tr>
            <asp:Repeater ID="rpt_orderinfo" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("OrderId")%></td>
                        <td><%# Eval("customerName")%></td>
                        <td><%# Eval("productName")%></td>
                        <td><%# Eval("SerialNumber")%></td>
                        <td><%# Eval("StationName")%></td>
                        <td><%# Eval("FailureDescription")%></td>
                        <td><%# Eval("OrderStatusStr")%></td>
                        <td>
                            <a href="orderDetail.aspx?id=<%# Eval("OrderId") %>">查看详情</a>
                        </td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
