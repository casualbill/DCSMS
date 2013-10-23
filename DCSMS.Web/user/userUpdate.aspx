<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="userUpdate.aspx.cs" Inherits="DCSMS.Web.user.userUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function btn_submit_client_click() {
            if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_username'))) {
                $('.content-tips').html('用户名必须不少于4个字符！');
                return false;
            }

            if (!textValidate($('#ctl00_MainContentPlaceHolder_tb_realname'))) {
                $('.content-tips').html('请输入用户姓名！');
                return false;
            }

            if ($('#ctl00_MainContentPlaceHolder_rbl_usertype').children(':checked').length < 1) {
                $('.content-tips').html('请选择用户类型！');
                return false;
            }

            $('.content-tips').html('');
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        用户修改
    </div>

    <div class="main-content">
        <div class="content-list"><ul>
            <li><label>用户ID：</label><asp:Label ID="lb_userid" runat="server"></asp:Label></li>
            <li><label>用户名：</label><asp:TextBox ID="tb_username" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>姓名：</label><asp:TextBox ID="tb_realname" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>工号：</label><asp:TextBox ID="tb_empcode" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label>电话：</label><asp:TextBox ID="tb_telephone" runat="server" MaxLength="20"></asp:TextBox></li>
            <li><label>Email：</label><asp:TextBox ID="tb_email" runat="server" MaxLength="50"></asp:TextBox></li>
            <li><label>用户组：</label><asp:RadioButtonList ID="rbl_usertype" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical" CssClass="radiobox-vertical">
                <asp:ListItem Text="Guest" Value="1"></asp:ListItem>
                <asp:ListItem Text="Technician" Value="2"></asp:ListItem>
                <asp:ListItem Text="Admin" Value="3"></asp:ListItem>
                <asp:ListItem Text="Manager" Value="4"></asp:ListItem>
                <asp:ListItem Text="Super Manager" Value="5"></asp:ListItem>
            </asp:RadioButtonList></li>
            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="确定" OnClientClick="return btn_submit_client_click();" OnClick="btn_submit_Click" /></li>
        </ul></div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
