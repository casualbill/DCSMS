﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTaskDetail.aspx.cs" Inherits="DCSMS.Web.myTaskDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var sparePartTemplate = [];
        sparePartTemplate.push('<tr><td><input type="text" title="sparePartName" maxlength="50" /></td>');
        sparePartTemplate.push('    <td><input type="text" title="orderingNumber" maxlength="30" /></td>');
        sparePartTemplate.push('    <td><input type="text" title="sparePartAmount" maxlength="10" /></td>');
        sparePartTemplate.push('    <td><input type="text" title="sparePartRemark" maxlength="300" /></td>');
        sparePartTemplate.push('    <td><input type="button" value="添加备件" title="sparePartAdd" />');
        sparePartTemplate.push('    <input type="hidden" value="0" title="sparePartId" /></td></tr>');

        $(function () {
            var orderId = $('[title="orderId"]').html();
            var sparePartTable = $('[title="sparePartTable"]');
            $.ajax({
                url: '/ajax.asmx/spraePartQuery',
                data: '{orderId:"' + orderId + '"}',
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                success: function (r) {
                    var result = JSON.parse(r.d);
                    var spartPartCollection;

                    for (var i = 0; i < result.length; i++) {
                        var temp = $(sparePartTemplate.join(''));
                        temp.find('[title="sparePartName"]').val(result[i].sparePartName);
                        temp.find('[title="orderingNumber"]').val(result[i].orderingNumber);
                        temp.find('[title="sparePartAmount"]').val(result[i].amount);
                        temp.find('[title="sparePartRemark"]').val(result[i].remark);
                        temp.find('[title="sparePartId"]').val(result[i].id);
                        temp.find('input').attr('disabled', true);
                        temp.find('[title="sparePartAdd"]').remove()
                        temp.children().last().append('<input type="button" value="删除备件" title="sparePartRemove" />');

                        sparePartTable.append(temp);
                    }

                    sparePartTable.append(sparePartTemplate.join(''));

                    if (parseInt($('#ctl00_MainContentPlaceHolder_hf_usertype').val()) != 2) {
                        sparePartTable.parent().hide();
                    }
                }
            });

            sparePartTable.delegate('[title="sparePartAdd"]', 'click', function () {
                var self = $(this);
                var sparePartInfo = self.parent().parent();
                var sparePartName = sparePartInfo.find('[title="sparePartName"]').val();
                var orderingNumber = sparePartInfo.find('[title="orderingNumber"]').val();
                var sparePartAmount = sparePartInfo.find('[title="sparePartAmount"]').val();
                var sparePartRemark = sparePartInfo.find('[title="sparePartRemark"]').val();

                if (sparePartName.length < 1 || orderingNumber.length < 1 || sparePartAmount.length < 1 || isNaN(sparePartAmount)) {
                    alert('请完整填写备件信息');
                } else {
                    $.ajax({
                        url: '/ajax.asmx/sparePartAdd',
                        data: '{sparePartName:"' + sparePartName + '", orderingNumber:"' + orderingNumber + '", amount:"' + sparePartAmount + '", remark:"' + sparePartRemark + '", orderId:"' + orderId + '"}',
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json",
                        success: function (r) {
                            var result = JSON.parse(r.d);

                            if (result == -2) {
                                alert('你没有操作权限！');
                            } else if (result == -1) {
                                alert('工单不存在！')
                            } else if (result == 1) {
                                sparePartInfo.find('input').attr('disabled', true);
                                self.val('已添加');
                                sparePartTable.append(sparePartTemplate.join(''));
                            } else { alert('系统错误'); }
                        }
                    });
                }
            });

            sparePartTable.delegate('[title="sparePartRemove"]', 'click', function () {
                if (confirm('确定删除此备件？')) {
                    var sparePartInfo = $(this).parent().parent();
                    var id = sparePartInfo.find('[title="sparePartId"]').val();
                    $.ajax({
                        url: '/ajax.asmx/sparePartRemove',
                        data: '{orderId:"' + orderId + '", id:"' + id + '"}',
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json",
                        success: function (r) {
                            var result = JSON.parse(r.d);

                            if (result == 1) {
                                sparePartInfo.remove();
                            } else { alert('系统错误'); }
                        }
                    });
                }
            });
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:HiddenField ID="hf_usertype" runat="server" />
    工单号：<asp:Label ID="lb_orderid" title="orderId" runat="server"></asp:Label><br />
    工作类型：<asp:Label ID="lb_worktype" runat="server"></asp:Label><br />
    维修站：<asp:Label ID="lb_stationname" runat="server"></asp:Label><br />
    <br />
    CustomerName：<asp:Label ID="lb_customername" runat="server"></asp:Label><br />
    EndCustomerName：<asp:Label ID="lb_endcustomername" runat="server"></asp:Label><br />
    ContactPerson：<asp:Label ID="lb_contactperson" runat="server"></asp:Label><br />
    Telephone：<asp:Label ID="lb_customer_telephone" runat="server"></asp:Label><br />
    Mobile：<asp:Label ID="lb_customer_mobile" runat="server"></asp:Label><br />
    Address：<asp:Label ID="lb_customer_address" runat="server"></asp:Label><br />
    PostCode：<asp:Label ID="lb_customer_postcode" runat="server"></asp:Label><br />
    <br />
    工具型号：<asp:Label ID="lb_productname" runat="server"></asp:Label><br />
    工具序列号：<asp:Label ID="lb_serialnumber" runat="server"></asp:Label><br />
    工具订货号：<asp:Label ID="lb_product_orderingnumber" runat="server"></asp:Label><br />
    固件版本：<asp:Label ID="lb_product_firmware" runat="server"></asp:Label><br />
    备注：<asp:Label ID="lb_product_remark" runat="server"></asp:Label><br />
    <br />

    <table>
        <tbody title="sparePartTable">
            <tr>
                <th>备件名称</th>
                <th>订货号</th>
                <th>数量</th>
                <th>备注</th>
                <th>操作</th>
            </tr>
        </tbody>
    </table>

    <br />
    故障描述：<asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox><br />
    照片选择：<asp:TextBox ID="tb_imgurl" MaxLength="300" runat="server"></asp:TextBox><br />
    备注：<asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox><br />
    <br />
    当前状态：<asp:Label ID="lb_orderstatus" runat="server"></asp:Label><br />

    <asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" /><br />

    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />

</asp:Content>
