
$(function() {
    "use strict";

    $('.group-place-from .list-place .place-name').click(function () {
        $('.place-from').addClass('hide');
        $('.input-place-from').val($(this).text());
    });

    $('.group-place-to .list-place .place-name').click(function () {
        $('.place-to').addClass('hide');
        $('.input-place-to').val($(this).text());
    });
});

