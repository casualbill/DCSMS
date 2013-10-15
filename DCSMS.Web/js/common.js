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

    textbox.on('keyup focus', function () {
        userIdField.val('0');
        var queryStr = $(this).val();
        $.ajax({
            url: '/ajax.asmx/userQuery',
            //url: 'ajax.asmx/customerQuery',
            data: '{queryStr:"' + queryStr + '", isTechnician: false}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                $('.ajax-list').remove();
                var data = JSON.parse(r.d);
                if (data.length > 0) {
                    showList(data);
                }
            }
        });
    });

    textbox.on('blur', function () {
        setTimeout(function () {
            $('.ajax-list').remove();
        }, 100);
    });

    $('body').delegate('.ajax-list li', 'click', function () {
        var userId = $(this).attr('userId');
        var userName = $(this).html();
        textbox.val(userName);
        userIdField.val(userId);
        $(this).parent().parent().remove();
    });

    function showList(data) {
        var offset = textbox.offset();
        var template = $('<div class="ajax-list"><ul></ul></div>');

        for (var i = 0; i < data.length; i++) {
            template.children().append('<li userId="' + data[i].id + '">' + data[i].userName + '</li>');
            //str += result[i].customerName + ' ';
        }
        $('body').append(template);
        template.css({
            width: textbox.innerWidth(),
            left: offset.left,
            top: offset.top + textbox.innerHeight()
        });
    }
};