<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderCreate.aspx.cs" Inherits="DCSMS.Web.order.orderCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            userAjaxSelector($('[title="technicianSelector"]'), true);
            customerAjaxSelector($('[title="customerName"]'), false);
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
        新建工单
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label><em>*</em>工作类型：</label><asp:DropDownList ID="ddl_worktype" runat="server">
                <asp:ListItem Text="请选择工作类型" Value="0"></asp:ListItem>
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList>            

            <li><label><em>*</em>客户：</label>
            <asp:RadioButtonList ID="rbl_customer" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbl_customer_change" CssClass="radiobox">
                <asp:ListItem Text="新建" Value="1"></asp:ListItem>
                <asp:ListItem Text="选择已有" Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label><em>*</em>客户名称：</label><asp:TextBox ID="tb_customername" title="customerName" runat="server" MaxLength="100"></asp:TextBox>
                <asp:HiddenField ID="hf_customerid" Value="0" runat="server" /></li>
            <li><label><em>*</em>终客户名称：</label><asp:TextBox ID="tb_endcustomername" title="endCustomerName" runat="server" MaxLength="100" Enabled="false"></asp:TextBox></li>
            <li><label><em>*</em>联系人：</label><asp:TextBox ID="tb_contactperson" title="contactPerson" runat="server" MaxLength="50" Enabled="false"></asp:TextBox></li>
            <li><label>电话：</label><asp:TextBox ID="tb_telephone" title="telephone" runat="server" MaxLength="20" Enabled="false"></asp:TextBox></li>
            <li><label>手机：</label><asp:TextBox ID="tb_mobile" title="mobile" runat="server" MaxLength="20" Enabled="false"></asp:TextBox></li>
            <li><label>地址：</label><asp:TextBox ID="tb_address" title="address" runat="server" MaxLength="100" Enabled="false"></asp:TextBox></li>
            <li class="margin-bottom"><label>邮编：</label><asp:TextBox ID="tb_postcode" title="postcode" runat="server" MaxLength="10" Enabled="false"></asp:TextBox></li>
    
            <li><label><em>*</em>工具型号：</label><asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox></li>
            <li><label><em>*</em>序列号：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label><em>*</em>订货号：</label><asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>固件版本：</label><asp:TextBox ID="tb_firmwareversion" MaxLength="20" runat="server"></asp:TextBox></li>
            <li class="margin-bottom"><label>备注：</label><asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox></li>

            <li><label><em>*</em>工作站：</label><asp:DropDownList ID="ddl_station" runat="server"></asp:DropDownList>

            <li><label><em>*</em>跟单技术员：</label><asp:TextBox ID="tb_technician" runat="server" title="technicianSelector"></asp:TextBox>
            <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" /></li>

            <li><label>备注：</label><asp:TextBox ID="tb_remark" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox></li>
            <li><label>访客可见故障描述及备注：</label><asp:RadioButtonList ID="rbl_ispublic" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radiobox">
                <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="否" Value="0"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="确定" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" /></li>
        </ul></div>

        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
