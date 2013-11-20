<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerCreate.aspx.cs" Inherits="DCSMS.Web.customer.customerCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            regionSelector($('#provinceSelector'), $('#citySelector'));
        });

        function btn_submit_client_click() {
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

            $('.content-tips').html('');
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_create %>"></asp:Literal>
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, customer_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_customername" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, end_customer_name %>"></asp:Literal>：</label><asp:TextBox ID="tb_endcustomername" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, contact_person %>"></asp:Literal>：</label><asp:TextBox ID="tb_contactperson" runat="server" MaxLength="50"></asp:TextBox></li>

            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, province %>"></asp:Literal>：</label><select id="provinceSelector"></select></li>
            <li><label><em>*</em><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, city %>"></asp:Literal>：</label><select id="citySelector"></select>
                <asp:HiddenField ID="hf_cityid" runat="server" />
            </li>

            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, telephone %>"></asp:Literal>：</label><asp:TextBox ID="tb_telephone" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, mobile %>"></asp:Literal>：</label><asp:TextBox ID="tb_mobile" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, address %>"></asp:Literal>：</label><asp:TextBox ID="tb_address" runat="server" MaxLength="100"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, postcode %>"></asp:Literal>：</label><asp:TextBox ID="tb_postcode" runat="server" MaxLength="10"></asp:TextBox></li>
            <li><label><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, remark %>"></asp:Literal>：</label><asp:TextBox ID="tb_remark" runat="server" MaxLength="300"></asp:TextBox></li>
            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
