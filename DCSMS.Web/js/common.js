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

var ajaxTextbox = function (textbox) {
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
        //$('.ajax-list').remove();
    });

    function showList(data) {
        $('.ajax-list').remove();
        var offset = textbox.offset();
        console.log(offset);
        var template = $('<div class="ajax-list"><ul></ul></div>');

        for (var i = 0; i < data.length; i++) {
            template.append('<li>' + data[i].userName + '</li>');
            //str += result[i].customerName + ' ';
        }
        $('body').append(template);
        template.css({
            width: textbox.width(),
            left: offset.left,
            top: offset.top + 20,
        });
    }
};