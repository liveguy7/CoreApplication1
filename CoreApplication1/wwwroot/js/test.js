
$(function () {
    $(".table").each(function () {
        var colText = $(this).text();
        if (colText == 'Active') {
            $(this).addClass("cellGreen");
        } else {
            $(this).addClass("cellRed");
        }
    });
});










