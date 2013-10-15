<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="orderUpdate.aspx.cs" Inherits="DCSMS.Web.order.orderUpdate" %>
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
    <div class="main-title">
        工单<asp:Label ID="lb_orderid" title="orderId" runat="server"></asp:Label>修改
    </div>

    <div class="main-content">
        <div class="content-list"><ul>

            <li><label>工作类型：</label><asp:DropDownList ID="ddl_worktype" runat="server">
                <asp:ListItem Text="质保" Value="1"></asp:ListItem>
                <asp:ListItem Text="客户付费" Value="2"></asp:ListItem>
                <asp:ListItem Text="Demo工具维修" Value="3"></asp:ListItem>
                <asp:ListItem Text="项目维修" Value="4"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label>客户：</label><asp:DropDownList ID="ddl_customer" runat="server"></asp:DropDownList></li>

            <li><label>工具型号：</label><asp:TextBox ID="tb_productname" MaxLength="50" runat="server"></asp:TextBox></li>
            <li><label>序列号：</label><asp:TextBox ID="tb_serialnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>订货号：</label><asp:TextBox ID="tb_product_orderingnumber" MaxLength="30" runat="server"></asp:TextBox></li>
            <li><label>固件版本：</label><asp:TextBox ID="tb_product_firmware" MaxLength="20" runat="server"></asp:TextBox></li>
            <li><label>备注：</label><asp:TextBox ID="tb_product_remark" MaxLength="300" TextMode="MultiLine" runat="server"></asp:TextBox></li>

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
            <li><label>照片选择：</label><asp:TextBox ID="tb_imgurl" MaxLength="300" runat="server"></asp:TextBox></li>
            <li><label>备注：</label><asp:TextBox ID="tb_remark" MaxLength="500" TextMode="MultiLine" runat="server"></asp:TextBox></li>
            <li><label>跟单技术员：</label><asp:DropDownList ID="ddl_technician" runat="server"></asp:DropDownList></li>
            <li><label>当前状态：</label><asp:Label ID="lb_orderstatus" runat="server"></asp:Label>
                <asp:HiddenField ID="hd_formerstatus" runat="server" /></li>
            <li><label>更新状态：</label><asp:DropDownList ID="ddl_orderstatus" runat="server">
                <asp:ListItem Text="等待客户审核" Value="1"></asp:ListItem>
                <asp:ListItem Text="等待检查" Value="2"></asp:ListItem>
                <asp:ListItem Text="等待报价" Value="3"></asp:ListItem>
                <asp:ListItem Text="等待客户确认" Value="4"></asp:ListItem>
                <asp:ListItem Text="等待备件到齐" Value="5"></asp:ListItem>
                <asp:ListItem Text="等待维修" Value="6"></asp:ListItem>
                <asp:ListItem Text="等待发货" Value="7"></asp:ListItem>
                <asp:ListItem Text="完成" Value="8"></asp:ListItem>
            </asp:DropDownList></li>

            <li><label></label><asp:CheckBox ID="cb_manageorder" runat="server" Text="由我管理这个工单" CssClass="checkbox" />
                <asp:HiddenField ID="hf_adminid" runat="server" /></li>

            <li><label></label><asp:Button ID="btn_submit" runat="server" Text="确定" OnClick="btn_submit_Click" /></li>
        </ul></div>
    </div>
    <asp:Label ID="lb_tips" runat="server" CssClass="content-tips"></asp:Label>
</asp:Content>
