var sparePartTemplate = [];
sparePartTemplate.push('<tr><td><input type="text" title="sparePartName" maxlength="50" /></td>');
sparePartTemplate.push('    <td><input type="text" title="orderingNumber" maxlength="30" /></td>');
sparePartTemplate.push('    <td><input type="text" title="sparePartAmount" maxlength="10" /></td>');
sparePartTemplate.push('    <td><input type="text" title="sparePartRemark" maxlength="300" /></td>');
sparePartTemplate.push('    <td><input type="button" value="添加备件" title="sparePartAdd" />');
sparePartTemplate.push('    <input type="hidden" value="0" title="sparePartId" /></td></tr>');

var repairLogTemplate = [];
repairLogTemplate.push('<tr><td><input type="text" title="workDetail" maxlength="300" /></td>');
repairLogTemplate.push('    <td><input type="text" title="defaultCharacter" maxlength="300" /></td>');
repairLogTemplate.push('    <td><input type="text" title="startTime" maxlength="20" /></td>');
repairLogTemplate.push('    <td><input type="text" title="endTime" maxlength="20" /></td>');
repairLogTemplate.push('    <td><input type="text" title="workTime" maxlength="10" /></td>');
repairLogTemplate.push('    <td><input type="button" value="添加维修记录" title="repairLogAdd" />');
repairLogTemplate.push('    <input type="hidden" value="0" title="repairLogId" /></td></tr>');

var sparePartHandler = function () {
    var orderId = getQueryStringByName('id');
    var sparePartTable = $('[title="sparePartTable"]');
    sparePartTable.parent().removeClass('hide');

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
}

var repairLogHandler = function () {
    var orderId = getQueryStringByName('id');
    var repairLogTable = $('[title="repairLogTable"]');
    repairLogTable.parent().removeClass('hide');

    $.ajax({
        url: '/ajax.asmx/repairLogQuery',
        data: '{orderId:"' + orderId + '"}',
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        success: function (r) {
            var result = JSON.parse(r.d);
            var spartPartCollection;

            for (var i = 0; i < result.length; i++) {
                var temp = $(repairLogTemplate.join(''));
                temp.find('[title="workDetail"]').val(result[i].workDetail);
                temp.find('[title="defaultCharacter"]').val(result[i].orderingNumber);
                temp.find('[title="startTime"]').val(result[i].startTime);
                temp.find('[title="endTime"]').val(result[i].endTime);
                temp.find('[title="workTime"]').val(result[i].workTime);
                temp.find('[title="repairLogId"]').val(result[i].id);
                temp.find('input').attr('disabled', true);
                temp.find('[title="repairLogAdd"]').remove()
                temp.children().last().append('<input type="button" value="删除维修记录" title="repairLogRemove" />');

                repairLogTable.append(temp);
            }

            repairLogTable.append(repairLogTemplate.join(''));
            repairLogTable.find('[title="startTime"]').last().datetimepicker();
            repairLogTable.find('[title="endTime"]').last().datetimepicker();
        }
    });

    repairLogTable.delegate('[title="repairLogAdd"]', 'click', function () {
        var self = $(this);
        var repairLogInfo = self.parent().parent();
        var workDetail = repairLogInfo.find('[title="workDetail"]').val();
        var defaultCharacter = repairLogInfo.find('[title="defaultCharacter"]').val();
        var startTime = repairLogInfo.find('[title="startTime"]').val();
        var endTime = repairLogInfo.find('[title="endTime"]').val();
        var workTime = repairLogInfo.find('[title="workTime"]').val();

        if (workDetail.length < 1) {
            alert('请完整填写维修信息');
        } else {
            $.ajax({
                url: '/ajax.asmx/repairLogAdd',
                data: '{workDetail:"' + workDetail + '", defaultCharacter:"' + defaultCharacter + '", startTime:"' + startTime + '", endTime:"' + endTime + '", workTime:"' + workTime + '", orderId:"' + orderId + '"}',
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
                        repairLogInfo.find('input').attr('disabled', true);
                        self.val('已添加');
                        repairLogTable.append(repairLogTemplate.join(''));
                        repairLogTable.find('[title="startTime"]').last().datetimepicker();
                        repairLogTable.find('[title="endTime"]').last().datetimepicker();
                    } else { alert('系统错误'); }
                }
            });
        }
    });

    repairLogTable.delegate('[title="repairLogRemove"]', 'click', function () {
        if (confirm('确定删除此维修记录？')) {
            var repairLogInfo = $(this).parent().parent();
            var id = repairLogInfo.find('[title="repairLogId"]').val();
            $.ajax({
                url: '/ajax.asmx/repairLogRemove',
                data: '{orderId:"' + orderId + '", id:"' + id + '"}',
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                success: function (r) {
                    var result = JSON.parse(r.d);

                    if (result == 1) {
                        repairLogInfo.remove();
                    } else { alert('系统错误'); }
                }
            });
        }
    });
}

var imageHandler = function (isControllable) {
    var orderId = getQueryStringByName('id');
    var imageContainer = $('#imageContainer');
    imageContainer.parent().parent().removeClass('hide');

    imageShow();
    if (isControllable) {
        imageUpload();
        removeButtonEvent();
    }

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
                    imageItem += '<dd imageId="' + result[i].id + '"><a href="' + result[i].fileUrl + '" target="_blank"><img src="' + result[i].fileUrl + '" /></a></dd>';
                }
                imageItem += '</dl>';
                imageContainer.html(imageItem);

                if (isControllable) {
                    imageContainer.find('dd').each(function () {
                        $(this).prepend('<a class="btn-remove" style="display:none;"></a>');
                    });
                }
            }
        });
    }

    function removeButtonEvent() {
        imageContainer.delegate('dd', 'mouseenter', function () {
            $(this).children('.btn-remove').show();
        });

        imageContainer.delegate('dd', 'mouseleave', function () {
            $(this).children('.btn-remove').hide();
        });

        imageContainer.delegate('.btn-remove', 'click', function () {
            if (confirm('确定删除此照片？')) {
                var imageItem = $(this).parent();
                var id = imageItem.attr('imageId');
                $.ajax({
                    url: '/ajax.asmx/imageRemove',
                    data: '{orderId:"' + orderId + '", id:"' + id + '"}',
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json",
                    success: function (r) {
                        var result = JSON.parse(r.d);

                        if (result == 1) {
                            imageItem.remove();
                        } else { alert('系统错误'); }
                    }
                });
            }
        });
    }

    function imageUpload() {
        $("#uploadify").uploadify({
            'swf': '/js/uploadify/uploadify.swf',
            'uploader': '/uploadHandler.ashx',
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

var orderProgressBar = function (orderStatus) {
    var progressBar = $('.order-progress-bar').children();
    for (var i = 0; i < orderStatus; i++) {
        progressBar.children().eq(i).addClass('finished');
    }

    if (orderStatus < 8 && orderStatus > 0) {
        progressBar.children().eq(orderStatus - 1).after('<li class="current-progress"></li>');
    }
}