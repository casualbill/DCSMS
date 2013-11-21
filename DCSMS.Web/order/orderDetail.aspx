<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderDetail.aspx.cs" Inherits="DCSMS.Web.order.orderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/js/order.js"></script>
    <script type="text/javascript">
        $(function () {
            imageHandler();
            orderProgressBar(<% =orderStatus %>);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        工单<asp:Label ID="lb_orderid" runat="server"></asp:Label>详情
    </div>

    <div class="main-content">
        <div class="order-progress-bar clearfix"><ul>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_1 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_2 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_3 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_4 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_5 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_6 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_7 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_8 %>"></asp:Literal></li>
        </ul></div>

        <div class="content-list"><ul>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_type %>"></asp:Literal>：</label><asp:Label ID="lb_worktype" runat="server"></asp:Label></li>
            <li id="li_failure_description" runat="server"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, failure_description %>"></asp:Literal>：</label><asp:Label ID="lb_failure_description" runat="server"></asp:Label></li>
            <li id="li_order_remark" runat="server"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:Label ID="lb_order_remark" runat="server"></asp:Label></li>
            <li class="clearfix">
                <label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, image %>"></asp:Literal>：</label>
                <div class="image-frame">
                    <div id="imageContainer" class="clearfix"></div>
                </div>
            </li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, create_time %>"></asp:Literal>：</label><asp:Label ID="lb_createtime" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, status_update_time %>"></asp:Literal>：</label><asp:Label ID="lb_updatetime" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, current_status %>"></asp:Literal>：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_creator %>"></asp:Literal>：</label><asp:Label ID="lb_createuser" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, responsible_technician %>"></asp:Literal>：</label><asp:Label ID="lb_technician" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_manager %>"></asp:Literal>：</label><asp:Label ID="lb_admin" runat="server"></asp:Label></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_name %>"></asp:Literal>：</label><asp:Label ID="lb_customername" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_customer_name %>"></asp:Literal>：</label><asp:Label ID="lb_endcustomername" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, contact_person %>"></asp:Literal>：</label><asp:Label ID="lb_contactperson" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, telephone %>"></asp:Literal>：</label><asp:Label ID="lb_customer_telephone" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, mobile %>"></asp:Literal>：</label><asp:Label ID="lb_customer_mobile" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, address %>"></asp:Literal>：</label><asp:Label ID="lb_customer_address" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, postcode %>"></asp:Literal>：</label><asp:Label ID="lb_customer_postcode" runat="server"></asp:Label></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, product_name %>"></asp:Literal>：</label><asp:Label ID="lb_productname" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, serial_number %>"></asp:Literal>：</label><asp:Label ID="lb_serialnumber" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, ordering_number %>"></asp:Literal>：</label><asp:Label ID="lb_product_orderingnumber" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, firmware_version %>"></asp:Literal>：</label><asp:Label ID="lb_product_firmware" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:Label ID="lb_product_remark" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, tool_type %>"></asp:Literal>：</label><asp:Label ID="lb_tooltype" runat="server"></asp:Label></li>
        </ul>
            
        <asp:Panel ID="pn_sparepart" runat="server" Visible="false">
            <table>
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, spare_part_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, ordering_number %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, amount %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal></th>
                </tr>
            <asp:Repeater ID="rpt_sparepart" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("SparePartName")%></td>
                        <td><%# Eval("OrderingNumber")%></td>
                        <td><%# Eval("Amount")%></td>
                        <td><%# Eval("Remark")%></td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>

        <asp:Panel ID="pn_repairlog" runat="server" Visible="false">
            <table>
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_content %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, default_character %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, start_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_time %>"></asp:Literal></th>
                </tr>
            <asp:Repeater ID="rpt_repairlog" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("WorkDetail")%></td>
                        <td><%# Eval("DefaultCharacter")%></td>
                        <td><%# Eval("StartTime")%></td>
                        <td><%# Eval("EndTime")%></td>
                        <td><%# Eval("WorkTime")%></td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>

        <ul>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, station %>"></asp:Literal>：</label><asp:Label ID="lb_stationname" runat="server"></asp:Label></li>

            <li><label></label><asp:Button ID="btn_update" runat="server" Text="修改该工单" OnClick="btn_update_Click" /></li>
            <li><label></label><asp:Button ID="btn_orderlog" runat="server" Text="查看工单操作记录" OnClick="btn_orderlog_Click" /></li>
        </ul></div>
    </div>
</asp:Content>
