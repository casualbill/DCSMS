<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="myTaskDetail.aspx.cs" Inherits="DCSMS.Web.myTaskDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="js/uploadify/uploadify.css" />
    <script src="js/uploadify/jquery.uploadify.js"></script>
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

            $("#uploadify").uploadify({
                'swf': 'js/uploadify/uploadify.swf',
                'uploader': 'uploadHandler.ashx',
                'buttonClass': '',
                'buttonText': 'UPLOAD IMAGE',
                'fileSizeLimit': 2048,
                'fileTypeDesc': 'Image Files',
                'fileTypeExts': '*.jpg; *.png; *.gif',
                'formData': { 'orderId': 'SH1300001' },
                'queueID': 'fileQueue',
                'multi': true,
                'queueSizeLimit': 10,
                'uploadLimit': 10
            });
        });
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main-content">
        <div class="content-list"><ul>
            <asp:HiddenField ID="hf_usertype" runat="server" />
            <li><label>工单号：</label><asp:Label ID="lb_orderid" title="orderId" runat="server"></asp:Label></li>
            <li><label>工作类型：</label><asp:Label ID="lb_worktype" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>维修站：</label><asp:Label ID="lb_stationname" runat="server"></asp:Label></li>
            
            <li><label>客户名称：</label><asp:Label ID="lb_customername" runat="server"></asp:Label></li>
            <li><label>终客户名称：</label><asp:Label ID="lb_endcustomername" runat="server"></asp:Label></li>
            <li><label>联系人：</label><asp:Label ID="lb_contactperson" runat="server"></asp:Label></li>
            <li><label>电话：</label><asp:Label ID="lb_customer_telephone" runat="server"></asp:Label></li>
            <li><label>手机：</label><asp:Label ID="lb_customer_mobile" runat="server"></asp:Label></li>
            <li><label>地址：</label><asp:Label ID="lb_customer_address" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>邮编：</label><asp:Label ID="lb_customer_postcode" runat="server"></asp:Label></li>
            
            <li><label>工具型号：</label><asp:Label ID="lb_productname" runat="server"></asp:Label></li>
            <li><label>工具序列号：</label><asp:Label ID="lb_serialnumber" runat="server"></asp:Label></li>
            <li><label>工具订货号：</label><asp:Label ID="lb_product_orderingnumber" runat="server"></asp:Label></li>
            <li><label>固件版本：</label><asp:Label ID="lb_product_firmware" runat="server"></asp:Label></li>
            <li class="margin-bottom"><label>备注：</label><asp:Label ID="lb_product_remark" runat="server"></asp:Label></li>
        </ul>

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
         <ul>
            
            <li><label>故障描述：</label><asp:TextBox ID="tb_failure_description" runat="server" MaxLength="300" TextMode="MultiLine"></asp:TextBox></li>
            <li><label>照片选择：</label><div id="fileQueue"></div><input type="file" name="uploadify" id="uploadify" /></li>
            <li><label>备注：</label><asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            
            <li><label>当前状态：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label></li>

            <li><label></label><asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" CssClass="checkbox" /></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="确定" OnClick="btn_submit_Click" /></li>
        </ul></div>
    </div>
</asp:Content>
