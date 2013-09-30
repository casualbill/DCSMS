<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerQuery.aspx.cs" Inherits="DCSMS.Web.customer.customerQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:TextBox ID="tb_query_text" runat="server" MaxLength="50"></asp:TextBox>
    <asp:Button ID="btn_submit" runat="server" Text="submit" OnClick="btn_submit_Click" />
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
                    <a href="customerUpdate.aspx?id=<%# Eval("Id") %>">编辑</a>
                </td>
            </tr>
            
        </ItemTemplate>
    </asp:Repeater>
    </table>
</asp:Content>
