<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerVerify.aspx.cs" Inherits="DCSMS.Web.customer.customerVerify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/jquery-1.10.2.min.js"></script>
    <script>
        $(function () {
            $('[customerid]').click(function () {
                var self = $(this);
                var customerId = self.attr('customerid');
                if (confirm('confirm')) {
                    $.ajax({
                        url: '/ajax.asmx/customerVerify',
                        data: '{id:"' + customerId + '"}',
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json",
                        success: function (r) {
                            if (r.d == 1) {
                                self.val('已审核').attr('disabled', 'disabled');
                            } else {
                                alert("fail");
                            }
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
    <table>
        <tr>
            <th>ID</th>
            <th>CustomerName</th>
            <th>EndCustomerName</th>
            <th>ContactPerson</th>
            <th>Telephone</th>
            <th>Mobile</th>
            <th>Address</th>
            <th>PostCode</th>
            <th>Remark</th>
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
</asp:Content>

