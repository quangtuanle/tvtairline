$(function() {
    "use strict";

    $.fn.datepicker.dates['en'] = {
        days: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"],
        daysShort: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
        daysMin: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"],
        months: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
        monthsShort: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        today: "Today",
        clear: "Clear",
        format: "dd/mm/yyyy",
        titleFormat: "MM yyyy", /* Leverages same syntax as 'format' */
        weekStart: 0
    };

    $('.datetimepickerWidget').datepicker({
        todayHighlight: true,
        beforeShowDay: function(e) {
            if ($('.datepicker-days .datepicker-switch').length) {
                var switchHTML = $('.datepicker-days .datepicker-switch');
                var titleDate = switchHTML.text();
                var titleDateArr = titleDate.split(' ');
                var titleMonth = titleDateArr[0];
                titleMonth = '<span class="month-base">'+titleMonth+'</span>';
                switchHTML.html(titleMonth+' '+titleDateArr[1]);
            }
        }
    });

    // Custom Selectbox
    $('select').selectbox();

    // Slide logo on footer
    $('.slide-logo-wrapper').slick({
        infinite: true,
        slidesToShow: 6,
        slidesToScroll: 6,
        autoplay: true,
        autoplaySpeed: 1,
        speed: 8000,
        arrows: false,
        pauseOnHover: false,
        responsive: [
            {
                breakpoint: 769,
                settings: {
                    slidesToShow: 4
                }
            },
            {
                breakpoint: 481,
                settings: {
                    slidesToShow: 3,
                    speed: 5000
                }
            },
            {
                breakpoint: 381,
                settings: {
                    slidesToShow: 2
                }
            }
        ]
    });

    // Slider result
    $('.info-ticket-slider-nav').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        asNavFor: '.info-ticket-slider-for',
        dots: false,
        arrows: true,
        focusOnSelect: true,
        autoplay: false,
        autoplaySpeed: 5000
    });
    $('.info-ticket-slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.info-ticket-slider-nav'
    });

    // Focus input place
    $('body').on('click', function(event) {
        if (!$('.place-from').hasClass('hide')) {
            if ($(event.target).closest('.input-place-from').length)
                return;

            $('.place-from').addClass('hide');
        }

        if (!$('.place-to').hasClass('hide')) {
            if ($(event.target).closest('.input-place-to').length)
                return;

            $('.place-to').addClass('hide');
        }
    });

    $('.input-place-from').focus(function () {
        $('.place-from').removeClass('hide');

        if (!$('.place-to').hasClass('hide')) {
            $('.place-to').addClass('hide');
        }
    });

    $('.input-place-to').focus(function () {
        $('.place-to').removeClass('hide');

        if (!$('.place-from').hasClass('hide')) {
            $('.place-from').addClass('hide');
        }
    });

    
});
