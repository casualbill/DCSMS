<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderCreate.aspx.cs" Inherits="DCSMS.Web.order.orderCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            userAjaxSelector($('[title="technicianSelector"]'), true);
            customerAjaxSelector($('[title="customerName"]'), $('#ctl00_MainContentPlaceHolder_hf_cityid'), 1, false);
            customerAjaxSelector($('[title="endCustomerName"]'), $('#ctl00_MainContentPlaceHolder_hf_cityid'), 2, false);
            regionSelector($('#provinceSelector'), $('#citySelector'));
        });

        function btn_submit_client_click() {
            if ($('#ctl00_MainContentPlaceHolder_ddl_worktype').children(':selected').val() == "0") {
                $('.content-tips').html('请选择工作类型！');
                return false;
            }

            if ($('#ctl00_MainContentPlaceHolder_rbl_customer').children(':checked').val() == "1") {
                if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_customername'))) {
                    $('.content-tips').html('请输入客户名称！');
                    return false;
                }

                if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_endcustomername'))) {
                    $('.content-tips').html('请输入终客户名称！');
                    return false;
                }

                if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_contactperson'))) {
                    $('.content-tips').html('请输入联系人！');
                    return false;
                }

                if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_telephone')) && !textValidate($('#ctl00_MainContentPlaceHolder_tb_mobile'))) {
                    $('.content-tips').html('电话和手机号码需至少输入一项！');
                    return false;
                }

                if (textValidate($('#ctl00_MainContentPlaceHolder_tb_telephone')) && !telephoneValidate($('#ctl00_MainContentPlaceHolder_tb_telephone'))) {
                    $('.content-tips').html('请输入正确的电话号码！');
                    return false;
                }

                if (textValidate($('#ctl00_MainContentPlaceHolder_tb_mobile')) && !telephoneValidate($('#ctl00_MainContentPlaceHolder_tb_mobile'))) {
                    $('.content-tips').html('请输入正确的手机号码！');
                    return false;
                }

            } else {
                if ($('#ctl00_MainContentPlaceHolder_hf_customerid').val() == "0") {
                    $('.content-tips').html('请选择客户！');
                    return false;
                }
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

            if ($('#ctl00_MainContentPlaceHolder_ddl_tooltype').children(':selected').val() == "0") {
                $('.content-tips').html('请选择工具类型！');
                return false;
            }

            if ($('#ctl00_MainContentPlaceHolder_ddl_station').children(':selected').val() == "0") {
                $('.content-tips').html('请选择工作站！');
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
        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, order_create %>"></asp:Literal>
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, work_type %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_worktype" runat="server">
                <asp:ListItem Text="请选择工作类型" Value="0"></asp:ListItem>
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer %>"></asp:Literal>：</label>
            <asp:RadioButtonList ID="rbl_customer" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbl_customer_change" CssClass="radiobox">
                <asp:ListItem Text="新建" Value="1"></asp:ListItem>
                <asp:ListItem Text="选择已有" Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, province %>"></asp:Literal>：<em>*</em></label><select id="provinceSelector"></select></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, city %>"></asp:Literal>：<em>*</em></label><select id="citySelector"></select>
                <asp:HiddenField ID="hf_cityid" runat="server" />
            </li>

            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_customername" title="customerName" runat="server" MaxLength="100"></asp:TextBox>
                <asp:HiddenField ID="hf_customerid" Value="0" runat="server" /></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_customer_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_endcustomername" title="endCustomerName" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, contact_person %>"></asp:Literal>：</label><asp:TextBox ID="tb_contactperson" title="contactPerson" runat="server" MaxLength="50" Enabled="false"></asp:TextBox></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, telephone %>"></asp:Literal>：</label><asp:TextBox ID="tb_telephone" title="telephone" runat="server" MaxLength="20" Enabled="false"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, mobile %>"></asp:Literal>：</label><asp:TextBox ID="tb_mobile" title="mobile" runat="server" MaxLength="20" Enabled="false"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, address %>"></asp:Literal>：</label><asp:TextBox ID="tb_address" title="address" runat="server" MaxLength="100" Enabled="false"></asp:TextBox></li>
            <li class="margin-bottom"><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, postcode %>"></asp:Literal>：</label><asp:TextBox ID="tb_postcode" title="postcode" runat="server" MaxLength="10" Enabled="false"></asp:TextBox></li>
    
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, product_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, serial_number %>"></asp:Literal>：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, ordering_number %>"></asp:Literal>：</label><asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, firmware_version %>"></asp:Literal>：</label><asp:TextBox ID="tb_firmwareversion" MaxLength="20" runat="server"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            <li class="margin-bottom"><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, tool_type %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_tooltype" runat="server">
                <asp:ListItem Text="请选择工具类型" Value="0"></asp:ListItem>
                <asp:ListItem Text="电动装配工具" Value="1"></asp:ListItem>
                <asp:ListItem Text="气动装配工具" Value="2"></asp:ListItem>
                <asp:ListItem Text="控制器" Value="3"></asp:ListItem>
                <asp:ListItem Text="气动打磨工具" Value="4"></asp:ListItem>
                <asp:ListItem Text="电池式工具" Value="5"></asp:ListItem>
                <asp:ListItem Text="附件" Value="6"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, station %>"></asp:Literal>：</label><asp:DropDownList ID="ddl_station" runat="server"></asp:DropDownList></li>

            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, responsible_technician %>"></asp:Literal>：</label><asp:TextBox ID="tb_technician" runat="server" title="technicianSelector"></asp:TextBox>
            <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" /></li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:TextBox ID="tb_remark" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox></li>
            <li><label>访客可见故障描述及备注：</label><asp:RadioButtonList ID="rbl_ispublic" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radiobox">
                <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="否" Value="0"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" /></li>
        </ul></div>

        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
