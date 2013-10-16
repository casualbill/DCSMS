<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerVerify.aspx.cs" Inherits="DCSMS.Web.customer.customerVerify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('[customerid]').click(function () {
                var self = $(this);
                var customerId = self.attr('customerid');
                if (confirm('确定通过该用户审核？')) {
                    $.ajax({
                        url: '/ajax.asmx/customerVerify',
                        data: '{id:"' + customerId + '"}',
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json",
                        success: function (r) {
                            switch (r.d) {
                                case 1: self.val('已审核').attr('disabled', 'disabled'); break;
                                case -1: alert('你没有操作权限！'); break;
                                case -2: alert('登录超时，请重新登录！'); break;
                                default: alert('系统错误！');
                            }

                            if (r.d == 1) {
                                self.val('已审核通过！').attr('disabled', 'disabled');
                            } else if (r.d == -1) { } else if (r.d == -2) { } else if (r) {
                                alert("系统错误！");
                            }
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        待审核客户列表
    </div>

    <div class="main-content">
        <asp:Panel ID="pn_table" runat="server" Visible="false">
            <table>
                <tr>
                    <th>客户ID</th>
                    <th>客户名称</th>
                    <th>终客户名称</th>
                    <th>联系人</th>
                    <th>电话</th>
                    <th>手机</th>
                    <th>地址</th>
                    <th>邮编</th>
                    <th>备注</th>
                    <th>操作</th>
                </tr>
            <asp:Repeater ID="rpt_customerinfo" runat="server">
                <ItemTemplate>

                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("CustomerName")%></td>
                        <td><%# Eval("EndCustomerName")%></td>
                        <td><%# Eval("ContactPerson")%></td>
                        <td><%# Eval("Telephone")%></td>
                        <td><%# Eval("Mobile")%></td>
                        <td><%# Eval("Address")%></td>
                        <td><%# Eval("PostCode")%></td>
                        <td><%# Eval("Remark")%></td>
                        <td>
                            <input type="button" customerid="<%# Eval("Id") %>" value="通过审核" />
                        </td>
                    </tr>
            
                </ItemTemplate>
            </asp:Repeater>
            </table>
        </asp:Panel>

        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips" Visible="false"></asp:Label>
    </div>
</asp:Content>

