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

var ajaxTextbox = function (textbox, hiddenField) {
    textbox.on('keyup', function () {
        var queryStr = $(this).val();
        $.ajax({
            url: 'ajax.asmx/userQuery',
            //url: 'ajax.asmx/customerQuery',
            data: '{queryStr:"' + queryStr + '", isTechnician: false}',
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function (r) {
                var data = JSON.parse(r.d);
                if (data) {
                    showList(data);
                }
            }
        });
    });

    textbox.on('blur', function () {
        $('.ajax-list').remove();
    });

    $('body').delegate('.ajax-list li', 'click', function () {
        var userId = $(this).attr('userId');
        var userName = $(this).html();
        textbox.val(userName);
        hiddenField.val(userId);
        $(this).parent().parent().remove();
    });

    function showList(data) {
        $('.ajax-list').remove();
        var offset = textbox.offset();
        console.log(offset);
        var template = $('<div class="ajax-list"><ul></ul></div>');

        for (var i = 0; i < data.length; i++) {
            template.children().append('<li userId="' + data[i].id + '">' + data[i].userName + '</li>');
            //str += result[i].customerName + ' ';
        }
        $('body').append(template);
        template.css({
            width: textbox.innerWidth(),
            left: offset.left,
            top: offset.top + 20
        });
    }
};