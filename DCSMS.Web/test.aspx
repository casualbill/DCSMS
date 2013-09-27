<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="DCSMS.Web.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.10.2.min.js"></script>
    <script>
        $(function () {

            $('#userQuery').keyup(function () {
                var queryStr = $(this).val();
                $.ajax({
                    //url: 'ajax.asmx/userQuery',
                    url: 'ajax.asmx/customerQuery',
                    data: '{queryStr:"' + queryStr + '"}',
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    success: function (r) {
                        console.log(r.d);
                        var result = JSON.parse(r.d);
                        console.log(result);
                        var str = '';
                        if (result) {
                            for (var i = 0; i < result.length; i++) {
                                //str += result[i].userName + ' ';
                                str += result[i].customerName + ' ';
                            }
                            $('#userQueryResult').html(str);
                        } else {
                            $('#userQueryResult').html('');
                        }
                    }
                });
            });


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
