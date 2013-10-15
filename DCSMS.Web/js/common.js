$(function () {
    $('.header-menu dl').on('mouseenter', function () {
        $(this).children('dt').css({ 'border-left': '1px solid #FFF', 'border-right': '1px solid #FFF', 'border-top': '1px solid #FFF' });
        $(this).children('dd').show();
    });

    $('.header-menu dl').on('mouseleave', function () {
        $(this).children('dt').css({ 'border-left': '1px solid #000', 'border-right': '1px solid #000', 'border-top': '1px solid #000' });
        $(this).children('dd').hide();
    });
});

var userAjaxSelector = function (textbox, isTechnician) {
    textbox.attr('autocomplete', 'off');
    var userIdField = textbox.next('[type="hidden"]');

    textbox.on('keyup focus', function (e) {
        if (e.type == 'keyup') {
            userIdField.val('0');
        }
        var queryStr = $(this).val();
        $.ajax({
            url: '/ajax.asmx/userQuery',
            data: '{queryStr:"' + queryStr + '", isTechnician: ' + isTechnician + '}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                $('#userSelectorList').remove();
                var data = JSON.parse(r.d);
                if (data.length > 0) {
                    showList(data);
                }
            }
        });
    });

    textbox.on('blur', function () {
        setTimeout(function () {
            $('#userSelectorList').remove();
        }, 100);
    });

    $('body').delegate('#userSelectorList li', 'click', function () {
        var userId = $(this).attr('userId');
        var userName = $(this).html();
        textbox.val(userName);
        userIdField.val(userId);
        $(this).parent().parent().remove();
    });

    function showList(data) {
        var offset = textbox.offset();
        var template = $('<div id="userSelectorList" class="ajax-list"><ul></ul></div>');

        for (var i = 0; i < data.length; i++) {
            template.children().append('<li userId="' + data[i].id + '">' + data[i].userName + '</li>');
        }
        $('body').append(template);
        template.css({
            width: textbox.innerWidth(),
            left: offset.left,
            top: offset.top + textbox.innerHeight()
        });
    }
};


var customerAjaxSelector = function (textbox, isOnlyId) {
    textbox.attr('autocomplete', 'off');
    var customerIdField = textbox.next('[type="hidden"]');

    textbox.on('keyup focus', function (e) {
        if (e.type == 'keyup') {
            customerIdField.val('0');
        }
        var queryStr = $(this).val();
        $.ajax({
            url: '/ajax.asmx/customerQuery',
            data: '{queryStr:"' + queryStr + '", isOnlyId: ' + isOnlyId + '}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                $('#customerSelectorList').remove();
                var data = JSON.parse(r.d);
                if (data.length > 0) {
                    console.log(data);
                    showList(data);
                }
            }
        });
    });

    textbox.on('blur', function () {
        setTimeout(function () {
            $('#customerSelectorList').remove();
        }, 100);
    });

    $('body').delegate('#customerSelectorList li', 'click', function () {
        var customerId = $(this).attr('customerId');
        var customerName = $(this).html();
        textbox.val(customerName);
        customerIdField.val(customerId);
        $(this).parent().parent().remove();

        if (!isOnlyId) {
            $('[title="endCustomerName"]').val($(this).attr('endCustomerName'));
            $('[title="contactPerson"]').val($(this).attr('contactPerson'));
            $('[title="telephone"]').val($(this).attr('telephone'));
            $('[title="mobile"]').val($(this).attr('mobile'));
            $('[title="address"]').val($(this).attr('address'));
            $('[title="postcode"]').val($(this).attr('postcode'));
        }
    });

    function showList(data) {
        var offset = textbox.offset();
        var template = $('<div id="customerSelectorList" class="ajax-list"><ul></ul></div>');

        for (var i = 0; i < data.length; i++) {
            var item = $('<li></li>');
            item.html(data[i].customerName);
            item.attr({
                'customerId': data[i].id
            });

            if (!isOnlyId) {
                item.attr({
                    'endCustomerName': data[i].endCustomerName,
                    'contactPerson': data[i].contactPerson,
                    'telephone': data[i].telephone,
                    'mobile': data[i].mobile,
                    'address': data[i].address,
                    'postcode': data[i].postcode
                });
            }

            template.children().append(item);
        }
        $('body').append(template);
        template.css({
            width: textbox.innerWidth(),
            left: offset.left,
            top: offset.top + textbox.innerHeight()
        });
    }
};