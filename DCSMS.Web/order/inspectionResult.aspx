<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="inspectionResult.aspx.cs" Inherits="DCSMS.Web.order.inspectionResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            $('select').each(function () {
                if ($(this).val() != '2') {
                    $(this).closest('tr').find('[type="text"]').attr('disabled', true);
                }
            });

            $('select').on('change', function () {
                if ($(this).val() == '2') {
                    $(this).closest('tr').find('[type="text"]').removeAttr('disabled');
                } else {
                    $(this).closest('tr').find('[type="text"]').val('').attr('disabled', true);
                }
            })
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-title">
        <asp:Literal runat="server" Text="<%$ Resources:GlobalResource, inspection_result_and_tool_function_test %>"></asp:Literal>
    </div>

    <div class="main-content">
        <div class="content-list">

            <div class="content-tips"><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, inspection_result %>"></asp:Literal></div>
            <table>
                <tr>
                    <td>1</td>
                    <td><asp:Label ID="lb_ir_itemtext1" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item1" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment1" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>2</td>
                    <td><asp:Label ID="lb_ir_itemtext2" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item2" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment2" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>3</td>
                    <td><asp:Label ID="lb_ir_itemtext3" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item3" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment3" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>4</td>
                    <td><asp:Label ID="lb_ir_itemtext4" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item4" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment4" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_ir5" runat="server">
                    <td>5</td>
                    <td><asp:Label ID="lb_ir_itemtext5" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item5" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment5" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_ir6" runat="server">
                    <td>6</td>
                    <td><asp:Label ID="lb_ir_itemtext6" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item6" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment6" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_ir7" runat="server">
                    <td>7</td>
                    <td><asp:Label ID="lb_ir_itemtext7" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item7" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment7" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_ir8" runat="server">
                    <td>8</td>
                    <td><asp:Label ID="lb_ir_itemtext8" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_ir_item8" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_ir_comment8" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
            </table>

            <div class="content-tips"><asp:Literal runat="server" Text="<%$ Resources:GlobalResource, tool_function_test %>"></asp:Literal></div>
            <table>
                <tr>
                    <td>1</td>
                    <td><asp:Label ID="lb_tft_itemtext1" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_tft_item1" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_tft_comment1" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>2</td>
                    <td><asp:Label ID="lb_tft_itemtext2" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_tft_item2" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_tft_comment2" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>3</td>
                    <td><asp:Label ID="lb_tft_itemtext3" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_tft_item3" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_tft_comment3" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_tft4" runat="server">
                    <td>4</td>
                    <td><asp:Label ID="lb_tft_itemtext4" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_tft_item4" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_tft_comment4" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_tft5" runat="server">
                    <td>5</td>
                    <td><asp:Label ID="lb_tft_itemtext5" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_tft_item5" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_tft_comment5" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
                <tr id="tr_tft6" runat="server">
                    <td>6</td>
                    <td><asp:Label ID="lb_tft_itemtext6" runat="server"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddl_tft_item6" runat="server">
                            <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                            <asp:ListItem Text="OK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="NOK" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:TextBox ID="tb_tft_comment6" runat="server" MaxLength="300"></asp:TextBox></td>
                </tr>
            </table>

            <ul>
                <li><label></label><asp:Button ID="btn_submit" runat="server" Text="<%$ Resources:GlobalResource, ok %>" OnClick="btn_submit_click" /></li>
            </ul>
        </div>
        <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
    </div>
</asp:Content>
