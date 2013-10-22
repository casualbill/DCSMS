<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTaskDetail.aspx.cs" Inherits="DCSMS.Web.myTaskDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/js/uploadify/uploadify.css" />
    <script type="text/javascript" src="/js/uploadify/jquery.uploadify.js"></script>
    <script type="text/javascript" src="/js/order.js"></script>
    <script type="text/javascript">
        $(function () {
            sparePartHandler(true);
            imageHandler();
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-content">
        <div class="content-list"><ul>
            <asp:HiddenField ID="hf_usertype" runat="server" />
            <li><label>工单号：</label><asp:Label ID="lb_orderid" title="orderId" runat="server"></asp:Label></li>
            <li><label>工作类型：</label><asp:Label ID="lb_worktype" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>维修站：</label><asp:Label ID="lb_stationname" runat="server"></asp:Label></li>
            
            <li><label>客户名称：</label><asp:Label ID="lb_customername" runat="server"></asp:Label></li>
            <li><label>终客户名称：</label><asp:Label ID="lb_endcustomername" runat="server"></asp:Label></li>
            <li><label>联系人：</label><asp:Label ID="lb_contactperson" runat="server"></asp:Label></li>
            <li><label>电话：</label><asp:Label ID="lb_customer_telephone" runat="server"></asp:Label></li>
            <li><label>手机：</label><asp:Label ID="lb_customer_mobile" runat="server"></asp:Label></li>
            <li><label>地址：</label><asp:Label ID="lb_customer_address" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>邮编：</label><asp:Label ID="lb_customer_postcode" runat="server"></asp:Label></li>
            
            <li><label>工具型号：</label><asp:Label ID="lb_productname" runat="server"></asp:Label></li>
            <li><label>工具序列号：</label><asp:Label ID="lb_serialnumber" runat="server"></asp:Label></li>
            <li><label>工具订货号：</label><asp:Label ID="lb_product_orderingnumber" runat="server"></asp:Label></li>
            <li><label>固件版本：</label><asp:Label ID="lb_product_firmware" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>备注：</label><asp:Label ID="lb_product_remark" runat="server"></asp:Label></li>
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
            <li><label>当前状态：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label></li>
            <li><label></label><asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" CssClass="checkbox" /></li>
            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="确定" OnClick="btn_submit_Click" /></li>
        </ul></div>
    </div>
</asp:Content>
