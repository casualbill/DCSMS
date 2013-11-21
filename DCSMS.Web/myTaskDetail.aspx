<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTaskDetail.aspx.cs" Inherits="DCSMS.Web.myTaskDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/js/jquery.ui.timepicker/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="/js/jquery.ui.timepicker/jquery-ui-timepicker-addon.min.css" />
    <link rel="stylesheet" type="text/css" href="/js/uploadify/uploadify.css" />
    <script type="text/javascript" src="/js/jquery.ui.timepicker/jquery-ui-1.10.3.custom.min.js"></script>
    <script type="text/javascript" src="/js/jquery.ui.timepicker/jquery-ui-timepicker-addon.min.js"></script>
    <script type="text/javascript" src="/js/uploadify/jquery.uploadify.js"></script>
    <script type="text/javascript" src="/js/order.js"></script>
    <script type="text/javascript">
        $(function () {
            sparePartHandler();
            repairLogHandler();
            imageHandler(true);
            orderProgressBar(<% =formerStatus %>);
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
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
            <asp:HiddenField ID="hf_usertype" runat="server" />
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_id %>"></asp:Literal>：</label><asp:Label ID="lb_orderid" title="orderId" runat="server"></asp:Label></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_type %>"></asp:Literal>：</label><asp:Label ID="lb_worktype" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, station %>"></asp:Literal>：</label><asp:Label ID="lb_stationname" runat="server"></asp:Label></li>
            
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

        <table>
            <tbody title="sparePartTable">
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, spare_part_name %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, ordering_number %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, amount %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, operation %>"></asp:Literal></th>
                </tr>
            </tbody>
        </table>

        <table>
            <tbody title="repairLogTable">
                <tr>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_content %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, default_character %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, start_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_time %>"></asp:Literal></th>
                    <th><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, operation %>"></asp:Literal></th>
                </tr>
            </tbody>
        </table>

        <ul>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, failure_description %>"></asp:Literal>：</label><asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox></li>
            <li class="clearfix hide">
                <label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, select_image %>"></asp:Literal>：</label>
                <div class="image-frame">
                    <div id="imageContainer" class="clearfix"></div>
                    <div id="fileQueue"></div><input type="file" name="uploadify" id="uploadify" />
                </div>
            </li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, current_status %>"></asp:Literal>：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label></li>
            <li><label></label><asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" CssClass="checkbox" /></li>
            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClick="btn_submit_Click" /></li>
        </ul></div>
    </div>
</asp:Content>
