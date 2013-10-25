<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderLog.aspx.cs" Inherits="DCSMS.Web.order.orderLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        工单<asp:Label ID="lb_orderid" runat="server"></asp:Label>操作记录
    </div>

    <div class="main-content">
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th>操作人</th>
                    <th>操作前状态</th>
                    <th>操作后状态</th>
                    <th>操作时间</th>
                </tr>
            <asp:Repeater ID="rpt_orderlog" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("UserName")%></td>
                        <td><%# Eval("FormerStatusStr")%></td>
                        <td><%# Eval("NewStatusStr")%></td>
                        <td><%# Eval("OperateTime")%></td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
