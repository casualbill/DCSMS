<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DCSMS.Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/global.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="/js/common.js"></script>
    <script type="text/javascript">
        function btn_submit_client_click() {
            if (!textValidate($('#tb_username'), 4)) {
                $('#lb_loginfo').html('用户名必须不少于4个字符！');
                return false;
            }

            if (!textValidate($('#tb_password'), 6)) {
                $('#lb_loginfo').html('密码必须不少于6个字符！');
                return false;
            }
            $('#lb_loginfo').html('');
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="wrapper">
            <div id="main">
                <div class="main-title">
                    <img src="/images/img_logo_big.png" />
                </div>

                <table cellpadding="0" cellspacing="0" class="login-table">
                    <tr>
                        <td width="40%" class="login-item-text"><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, username %>"></asp:Literal>：</td>
                        <td width="60%"><asp:TextBox ID="tb_username" runat="server" MaxLength="32"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="login-item-text"><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:GlobalResource, password %>"></asp:Literal>：</td>
                        <td><asp:TextBox ID="tb_password" runat="server" TextMode="Password" MaxLength="32"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="login-item-text"></td>
                        <td><asp:Button ID="btn_submit" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" runat="server" Text="<%$ Resources:GlobalResource, login %>" /></td>
                    </tr>
                    <tr>
                        <td class="login-item-text"></td>
                        <td><asp:Label ID="lb_loginfo" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
