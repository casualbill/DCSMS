<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="DCSMS.Web.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/global.css" rel="Stylesheet" type="text/css" />
    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/common.js"></script>
    <script>
        $(function () {

            ajaxTextbox($(userQuery));


        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="textBox" runat="server"></asp:TextBox>
        <asp:Button ID="button" runat="server" OnClick="onButtonClick" />
        <asp:Label ID="label" runat="server"></asp:Label><br /><br />

        <input id="userQuery" type="text" />
        <div id="userQueryResult"></div>
    </div>
    </form>
</body>
</html>
