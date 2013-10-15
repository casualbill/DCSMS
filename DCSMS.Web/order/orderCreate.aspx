<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderCreate.aspx.cs" Inherits="DCSMS.Web.order.orderCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            userAjaxSelector($('[title="technicianSelector"]'), true);
            customerAjaxSelector($('[title="customerName"]'), false);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        新建工单
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label>工作类型：</label><asp:DropDownList ID="ddl_worktype" AutoPostBack="true" OnSelectedIndexChanged="ddl_worktype_changed" runat="server">
                <asp:ListItem Text="请选择工作类型" Value=""></asp:ListItem>
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList>
            <asp:HiddenField ID="hf_worktype" Value="" runat="server" /></li>
            

            <li><label>客户：</label>
            <asp:RadioButtonList ID="rbl_customer" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbl_customer_change" CssClass="radiobox">
                <asp:ListItem Text="新建" Value="1"></asp:ListItem>
                <asp:ListItem Text="选择已有" Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList></li>

            <li><label>客户名称：</label><asp:TextBox ID="tb_customername" title="customerName" runat="server" MaxLength="100"></asp:TextBox>
                <asp:HiddenField ID="hf_customerid" Value="0" runat="server" /></li>
            <li><label>终客户名称：</label><asp:TextBox ID="tb_endcustomername" title="endCustomerName" runat="server" MaxLength="100" Enabled="false"></asp:TextBox></li>
            <li><label>联系人：</label><asp:TextBox ID="tb_contactperson" title="contactPerson" runat="server" MaxLength="50" Enabled="false"></asp:TextBox></li>
            <li><label>电话：</label><asp:TextBox ID="tb_telephone" title="telephone" runat="server" MaxLength="20" Enabled="false"></asp:TextBox></li>
            <li><label>手机：</label><asp:TextBox ID="tb_mobile" title="mobile" runat="server" MaxLength="20" Enabled="false"></asp:TextBox></li>
            <li><label>地址：</label><asp:TextBox ID="tb_address" title="address" runat="server" MaxLength="100" Enabled="false"></asp:TextBox></li>
            <li class="margin-bottom"><label>邮编：</label><asp:TextBox ID="tb_postcode" title="postcode" runat="server" MaxLength="10" Enabled="false"></asp:TextBox></li>
    
            <li><label>工具型号：</label><asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox></li>
            <li><label>序列号：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>订货号：</label><asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>固件版本：</label><asp:TextBox ID="tb_firmwareversion" MaxLength="20" runat="server"></asp:TextBox></li>
            <li class="margin-bottom"><label>备注：</label><asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox></li>

            <li><label>工作站：</label><asp:DropDownList ID="ddl_station" AutoPostBack="true" OnSelectedIndexChanged="ddl_station_changed" runat="server"></asp:DropDownList>
            <asp:HiddenField ID="hf_stationid" Value="" runat="server" /></li>

            <li><label>跟单技术员：</label><asp:TextBox ID="tb_technician" runat="server" title="technicianSelector"></asp:TextBox>
            <asp:HiddenField ID="hf_technicianid" Value="0" runat="server" /></li>

            <li><label>备注：</label><asp:TextBox ID="tb_remark" runat="server" MaxLength="500" TextMode="MultiLine"></asp:TextBox></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" /></li>
        </ul></div>

        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
