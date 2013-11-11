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
            <li>等待客户审核</li>
            <li>等待工单检查</li>
            <li>等待报价</li>
            <li>等待客户确认</li>
            <li>等待备件到齐</li>
            <li>等待维修</li>
            <li>等待发货</li>
            <li>工单完成</li>
        </ul></div>

        <div class="content-list"><ul>
            <li><label>工作类型：</label><asp:Label ID="lb_worktype" runat="server"></asp:Label></li>
            <li id="li_failure_description" runat="server"><label>故障描述：</label><asp:Label ID="lb_failure_description" runat="server"></asp:Label></li>
            <li id="li_order_remark" runat="server"><label>备注：</label><asp:Label ID="lb_order_remark" runat="server"></asp:Label></li>
            <li class="clearfix">
                <label>照片：</label>
                <div class="image-frame">
                    <div id="imageContainer" class="clearfix"></div>
                </div>
            </li>
            <li><label>创建时间：</label><asp:Label ID="lb_createtime" runat="server"></asp:Label></li>
            <li><label>状态更新时间：</label><asp:Label ID="lb_updatetime" runat="server"></asp:Label></li>
            <li><label>当前状态：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label></li>
            <li><label>创建者：</label><asp:Label ID="lb_createuser" runat="server"></asp:Label></li>
            <li><label>跟单技术员：</label><asp:Label ID="lb_technician" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>管理者：</label><asp:Label ID="lb_admin" runat="server"></asp:Label></li>

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
            <li><label>备注：</label><asp:Label ID="lb_product_remark" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>工具类型：</label><asp:Label ID="lb_tooltype" runat="server"></asp:Label></li>
        </ul>
            
        <asp:Panel ID="pn_sparepart" runat="server" Visible="false">
            <table>
                <tr>
                    <th>备件名称</th>
                    <th>订货号</th>
                    <th>数量</th>
                    <th>备注</th>
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
                    <th>工作内容</th>
                    <th>缺省特征信息</th>
                    <th>开始时间</th>
                    <th>结束时间</th>
                    <th>消耗工时</th>
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
            <li><label>维修站：</label><asp:Label ID="lb_stationname" runat="server"></asp:Label></li>

            <li><label></label><asp:Button ID="btn_update" runat="server" Text="修改该工单" OnClick="btn_update_Click" /></li>
            <li><label></label><asp:Button ID="btn_orderlog" runat="server" Text="查看工单操作记录" OnClick="btn_orderlog_Click" /></li>
        </ul></div>
    </div>
</asp:Content>
