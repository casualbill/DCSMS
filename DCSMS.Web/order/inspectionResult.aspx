<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="inspectionResult.aspx.cs" Inherits="DCSMS.Web.order.inspectionResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        检查结果及工具功能测试
    </div>

    <div class="main-content">
        <table>
            <tr>
                <td>1</td>
                <td><asp:Label ID="lb_itemtext1" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item1" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment1" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>2</td>
                <td><asp:Label ID="lb_itemtext2" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item2" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment2" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>3</td>
                <td><asp:Label ID="lb_itemtext3" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item3" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment3" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr>
                <td>4</td>
                <td><asp:Label ID="lb_itemtext4" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item4" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment4" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr id="tr_inspectionresult5" runat="server">
                <td>5</td>
                <td><asp:Label ID="lb_itemtext5" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item5" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment5" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr id="tr_inspectionresult6" runat="server">
                <td>6</td>
                <td><asp:Label ID="lb_itemtext6" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item6" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment6" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr id="tr_inspectionresult7" runat="server">
                <td>7</td>
                <td><asp:Label ID="lb_itemtext7" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item7" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment7" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
            <tr id="tr_inspectionresult8" runat="server">
                <td>8</td>
                <td><asp:Label ID="lb_itemtext8" runat="server"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddl_item8" runat="server">
                        <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                        <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                        <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                        <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tb_comment8" runat="server" MaxLength="300"></asp:TextBox></td>
            </tr>
        </table>
    </div>
</asp:Content>
