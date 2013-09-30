<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="customerUpdate.aspx.cs" Inherits="DCSMS.Web.customer.customerUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    CustomerID：<asp:Label ID="lb_customerid" runat="server"></asp:Label><br />
    CustomerName：<asp:TextBox ID="tb_customername" runat="server" MaxLength="100"></asp:TextBox><br />
    EndCustomerName：<asp:TextBox ID="tb_endcustomername" runat="server" MaxLength="100"></asp:TextBox><br />
    ContactPerson：<asp:TextBox ID="tb_contactperson" runat="server" MaxLength="50"></asp:TextBox><br />
    Telephone：<asp:TextBox ID="tb_telephone" runat="server" MaxLength="20"></asp:TextBox><br />
    Mobile：<asp:TextBox ID="tb_mobile" runat="server" MaxLength="20"></asp:TextBox><br />
    Address: <asp:TextBox ID="tb_address" runat="server" MaxLength="100"></asp:TextBox><br />
    PostCode：<asp:TextBox ID="tb_postcode" runat="server" MaxLength="10"></asp:TextBox><br />
    Remark：<asp:TextBox ID="tb_remark" runat="server" MaxLength="300"></asp:TextBox><br />
    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />
    <asp:Label ID="lb_tips" runat="server"></asp:Label>
</asp:Content>
