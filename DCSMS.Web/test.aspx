﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="DCSMS.Web.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataGrid ID="dataGrid" runat="server"></asp:DataGrid>
        <asp:Label ID="label" runat="server"></asp:Label>
        <asp:TextBox ID="textBox" runat="server"></asp:TextBox>
        <asp:Button ID="button" runat="server" OnClick="onButtonClick" />
    </div>
    </form>
</body>
</html>
