<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderUpdate.aspx.cs" Inherits="DCSMS.Web.order.orderUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/js/uploadify/uploadify.css" />
    <script type="text/javascript" src="/js/uploadify/jquery.uploadify.js"></script>
    <script type="text/javascript" src="/js/order.js"></script>
    <script type="text/javascript">
        $(function () {
            sparePartHandler();
            imageHandler(true);

            userAjaxSelector($('[title="technicianSelector"]'), true);
            customerAjaxSelector($('[title="customerSelector"]'), true);
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
        <div class="content-list"><ul>

            <li><label>工作类型：</label><asp:DropDownList ID="ddl_worktype" runat="server">
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label>客户：</label><asp:TextBox ID="tb_customer" runat="server" title="customerSelector"></asp:TextBox>
                <asp:HiddenField ID="hf_customerid" Value="0" runat="server" /></li>

            <li><label>工具型号：</label><asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox></li>
            <li><label>序列号：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>订货号：</label><asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>固件版本：</label><asp:TextBox ID="tb_product_firmware" MaxLength="20" runat="server"></asp:TextBox></li>
            <li><label>备注：</label><asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox></li>

        </ul>

        <table>
            <tbody title="sparePartTable">
                <tr>
                    <th>备件名称</th>
                    <th>订货号</th>
                    <th>数量</th>
                    <th>备注</th>
                    <th>操作</th>
                </tr>
            </tbody>
        </table>

        <ul>
            <li><label>故障描述：</label><asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox></li>
            <li class="clearfix">
                <label>照片选择：</label>
                <div class="image-frame">
                    <div id="imageContainer" class="clearfix"></div>
                    <div id="fileQueue"></div><input type="file" name="uploadify" id="uploadify" />
                </div>
            </li>
            <li><label>备注：</label><asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            <li><label>跟单技术员：</label><asp:TextBox ID="tb_technician" runat="server" title="technicianSelector"></asp:TextBox>
                <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" /></li>
            <li><label>当前状态：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label>
                <asp:HiddenField ID="hd_formerstatus" runat="server" /></li>
            <li><label>更新状态：</label><asp:DropDownList ID="ddl_orderstatus" runat="server">
                <asp:ListItem Text="等待客户审核" Value="1"></asp:ListItem>
                <asp:ListItem Text="等待检查" Value="2"></asp:ListItem>
                <asp:ListItem Text="等待报价" Value="3"></asp:ListItem>
                <asp:ListItem Text="等待客户确认" Value="4"></asp:ListItem>
                <asp:ListItem Text="等待备件到齐" Value="5"></asp:ListItem>
                <asp:ListItem Text="等待维修" Value="6"></asp:ListItem>
                <asp:ListItem Text="等待发货" Value="7"></asp:ListItem>
                <asp:ListItem Text="完成" Value="8"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label></label><asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" CssClass="checkbox" />
                <asp:HiddenField ID="hf_adminid" runat="server" /></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="确定" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
