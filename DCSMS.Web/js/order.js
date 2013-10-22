var sparePartTemplate = [];
sparePartTemplate.push('<tr><td><input type="text" title="sparePartName" maxlength="50" /></td>');
sparePartTemplate.push('    <td><input type="text" title="orderingNumber" maxlength="30" /></td>');
sparePartTemplate.push('    <td><input type="text" title="sparePartAmount" maxlength="10" /></td>');
sparePartTemplate.push('    <td><input type="text" title="sparePartRemark" maxlength="300" /></td>');
sparePartTemplate.push('    <td><input type="button" value="添加备件" title="sparePartAdd" />');
sparePartTemplate.push('    <input type="hidden" value="0" title="sparePartId" /></td></tr>');

var sparePartHandler = function (adminHide) {
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

            if (adminHide) {
                if (parseInt($('#ctl00_MainContentPlaceHolder_hf_usertype').val()) != 2) {
                    sparePartTable.parent().hide();
                }
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
}

var imageHandler = function () {
    var orderId = $('[title="orderId"]').html();
    var imageContainer = $('#imageContainer');

    imageShow();
    imageUpload();

    function imageShow() {
        $.ajax({
            url: '/ajax.asmx/imageShow',
            data: '{orderId:"' + orderId + '"}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                var result = JSON.parse(r.d);

                var imageItem = '<dl>';
                for (var i = 0; i < result.length; i++) {
                    imageItem += '<dd><a href="' + result[i].fileUrl + '" target="_blank"><img imageId="' + result[i].id + '" src="' + result[i].fileUrl + '" /></a></dd>';
                }
                imageItem += '</dl>';
                imageContainer.html(imageItem);
            }
        });
    }

    function imageUpload() {
        $("#uploadify").uploadify({
            'swf': 'js/uploadify/uploadify.swf',
            'uploader': 'uploadHandler.ashx',
            'buttonClass': '',
            'buttonText': 'UPLOAD IMAGE',
            'fileSizeLimit': 2048,
            'fileTypeDesc': 'Image Files',
            'fileTypeExts': '*.jpg; *.png; *.gif',
            'formData': { 'orderId': orderId },
            'queueID': 'fileQueue',
            'multi': true,
            'queueSizeLimit': 10,
            'uploadLimit': 10,
            'onQueueComplete': imageShow
        });
    }
}