<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="DCSMS.Web.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/js/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="/js/common.js"></script>
    <script type="text/javascript">
        $(function () {
            regionSelector($('#provinceSelector'), $('#citySelector'));
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <select id="provinceSelector"></select>
        <select id="citySelector"></select>
        <asp:HiddenField ID="hf_city" runat="server" />
        <asp:Button ID="btn_test" runat="server" OnClick="btn_test_click" />
    </div>
    </form>
</body>
</html>
