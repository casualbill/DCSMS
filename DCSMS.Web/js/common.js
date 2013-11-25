var mainMenuListHandler = function (userType) {
    if (userType >= 4) {
        $('#menuUser dl').on('mouseenter', function () {
            $(this).children('dt').css({ 'border-left': '1px solid #FFF', 'border-right': '1px solid #FFF', 'border-top': '1px solid #FFF' });
            $(this).children('dd').show();
        });

        $('#menuUser dl').on('mouseleave', function () {
            $(this).children('dt').css({ 'border-left': '1px solid #000', 'border-right': '1px solid #000', 'border-top': '1px solid #000' });
            $(this).children('dd').hide();
        });
    } else {
        $('#menuUser').hide();
    }

    if (userType >= 3) {
        $('#menuCustomer dl').on('mouseenter', function () {
            $(this).children('dt').css({ 'border-left': '1px solid #FFF', 'border-right': '1px solid #FFF', 'border-top': '1px solid #FFF' });
            $(this).children('dd').show();
        });

        $('#menuCustomer dl').on('mouseleave', function () {
            $(this).children('dt').css({ 'border-left': '1px solid #000', 'border-right': '1px solid #000', 'border-top': '1px solid #000' });
            $(this).children('dd').hide();
        });
    } else {
        $('#menuCustomer').hide();
    }

    if (userType == 1) {
        $('#menuTask').hide();
        $('#menuOrderCreate').hide();
    }
}

var addToFavorite = function (url, title) {
    var ua = navigator.userAgent.toLowerCase();
    if (ua.indexOf("msie 8") > -1) {
        external.AddToFavoritesBar(url, title, "");
    } else {
        try {
            window.external.addFavorite(url, title);
        } catch (e) {
            try {
                window.sidebar.addPanel(title, url, "");
            } catch (e) {
                alert("您的浏览器不支持自动添加至收藏夹，请使用\"Ctrl+D\"进行手动添加！");
            }
        }
    }
}

var getQueryStringByName = function (name) {
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1) {
        return "";
    }
    return result[1];
}

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


var customerAjaxSelector = function (textbox, cityHiddenField, queryType, brief) {
    textbox.attr('autocomplete', 'off');
    var customerIdField = $('[name="ctl00$MainContentPlaceHolder$hf_customerid"]');

    textbox.on('keyup focus', function (e) {
        if (e.type == 'keyup') {
            customerIdField.val('0');
            if (!brief) {
                $('[title="contactPerson"]').val('');
                $('[title="telephone"]').val('');
                $('[title="mobile"]').val('');
                $('[title="address"]').val('');
                $('[title="postcode"]').val('');
            }
        }
        var queryStr = $(this).val();

        var cityId;
        if (cityHiddenField) {
            cityId = cityHiddenField.val();
        } else {
            cityId = 0;
        }

        $.ajax({
            url: '/ajax.asmx/customerQuery',
            data: '{queryStr:"' + queryStr + '", cityId:' + cityId + ', queryType:"' + queryType + '", brief: ' + brief + '}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                $('#customerSelectorList').remove();
                var data = JSON.parse(r.d);
                if (data.length > 0) {
                    showList(data);
                }
            }
        });
    });

    textbox.on('blur', function () {
        setTimeout(function () {
            $('#customerSelectorList').remove();
        }, 200);
    });

    $('body').delegate('#customerSelectorList li', 'click', function () {
        var customerId = $(this).attr('customerId');
        $('[title="customerName"]').val($(this).attr('customerName'));
        $('[title="endCustomerName"]').val($(this).attr('endCustomerName'));
        customerIdField.val(customerId);
        $(this).parent().parent().remove();

        if (!brief) {
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
            item.html('<span>' + data[i].customerName + '</span> - ' + data[i].endCustomerName);
            item.attr({
                'customerId': data[i].id,
                'customerName': data[i].customerName,
                'endCustomerName': data[i].endCustomerName
            });

            if (!brief) {
                item.attr({
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

var regionSelector = function (provinceSelector, citySelector) {
    $.ajax({
        url: '/ajax.asmx/provinceList',
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        success: function (r) {
            var data = JSON.parse(r.d);
            for (var i = 0; i < data.length; i++) {
                provinceSelector.append('<option value="' + data[i].id + '">' + data[i].province + '</option>');
            }
            showCityList(1);
        }
    });

    provinceSelector.delegate(provinceSelector, 'change', function () {
        var provinceId = $(this).val();
        showCityList(provinceId);
    });

    function showCityList(provinceId) {
        $.ajax({
            url: '/ajax.asmx/cityList',
            data: '{provinceId:' + provinceId + '}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                citySelector.html('');
                var data = JSON.parse(r.d);
                for (var i = 0; i < data.length; i++) {
                    citySelector.append('<option value="' + data[i].id + '">' + data[i].city + '</option>');
                }
                citySelector.next('[type="hidden"]').val(data[0].id);
            }
        });
    }

    citySelector.delegate(citySelector, 'change', function () {
        var cityId = $(this).val();
        $(this).next('[type="hidden"]').val(cityId);
    });
}

var textValidate = function (textbox, minLength) {
    if (!minLength) {
        minLength = 1;
    }
    if (textbox.val().length < minLength) {
        return false;
    }
    return true;
}

var telephoneValidate = function (textbox) {
    var regExp = new RegExp('^[\\s\\d\\.\\*,+-]{5,}$');
    return regExp.test(textbox.val());
}