<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderUpdate.aspx.cs" Inherits="DCSMS.Web.order.orderUpdate" %>
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
            orderProgressBar(<% =orderStatus %>);

            userAjaxSelector($('[title="technicianSelector"]'), true);
            customerAjaxSelector($('[title="customerName"]'), null, 1, true);
        });

        function btn_submit_client_click() {
            if ($('#ctl00_MainContentPlaceHolder_hf_customerid').val() == "0") {
                $('.content-tips').html('请选择客户！');
                return false;
            }

            if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_productname'))) {
                $('.content-tips').html('请输入工具型号！');
                return false;
            }

            if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_serialnumber'))) {
                $('.content-tips').html('请输入工具序列号！');
                return false;
            }

            if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_product_orderingnumber'))) {
                $('.content-tips').html('请输入工具订货号！');
                return false;
            }

            if ($('#ctl00_MainContentPlaceHolder_hf_technicianid').val() == "0") {
                $('.content-tips').html('请选择跟单技术员！');
                return false;
            }

            $('.content-tips').html('');
            return true;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        工单<asp:Label ID="lb_orderid" title="orderId" runat="server"></asp:Label>修改
    </div>

    <div class="main-content">
        <div class="order-progress-bar clearfix"><ul>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text1 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text2 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text3 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text4 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text5 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text6 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text7 %>"></asp:Literal></li>
            <li><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_status_text8 %>"></asp:Literal></li>
        </ul></div>

        <div class="content-list"><ul>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_type %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_worktype" runat="server">
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer %>"></asp:Literal>：</label><asp:TextBox ID="tb_customer" runat="server" title="customerName"></asp:TextBox>
                <asp:HiddenField ID="hf_customerid" Value="0" runat="server" /></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, product_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, serial_number %>"></asp:Literal>：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, ordering_number %>"></asp:Literal>：</label><asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, firmware_version %>"></asp:Literal>：</label><asp:TextBox ID="tb_product_firmware" MaxLength="20" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, tool_type %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_tooltype" runat="server">
                <asp:ListItem Text="<%$ Resources:GlobalResource, tool_type_text1 %>" Value="1"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, tool_type_text2 %>" Value="2"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, tool_type_text3 %>" Value="3"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, tool_type_text4 %>" Value="4"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, tool_type_text5 %>" Value="5"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, tool_type_text6 %>" Value="6"></asp:ListItem>
            </asp:DropDownList></li>
            <li><label></label><asp:LinkButton ID="lbtn_inspectionresult" runat="server" Text="<%$ Resources:GlobalResource, inspection_result_and_tool_function_test %>" OnClick="lbtn_inspectionresult_click"></asp:LinkButton></li>
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
            <li class="clearfix">
                <label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, select_image %>"></asp:Literal>：</label>
                <div class="image-frame">
                    <div id="imageContainer" class="clearfix"></div>
                    <div id="fileQueue"></div><input type="file" name="uploadify" id="uploadify" />
                </div>
            </li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, responsible_technician %>"></asp:Literal>：</label><asp:TextBox ID="tb_technician" runat="server" title="technicianSelector"></asp:TextBox>
                <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" /></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, current_status %>"></asp:Literal>：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label>
                <asp:HiddenField ID="hd_formerstatus" runat="server" /></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, update_status %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_orderstatus" runat="server">
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text1 %>" Value="1"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text2 %>" Value="2"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text3 %>" Value="3"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text4 %>" Value="4"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text5 %>" Value="5"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text6 %>" Value="6"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text7 %>" Value="7"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:GlobalResource, order_status_text8 %>" Value="8"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label>访客可见故障描述及备注：</label><asp:RadioButtonList ID="rbl_ispublic" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radiobox">
                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                <asp:ListItem Text="否" Value="0"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label></label><asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" CssClass="checkbox" />
                <asp:HiddenField ID="hf_adminid" runat="server" /></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
