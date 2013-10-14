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