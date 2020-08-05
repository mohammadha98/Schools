$(function(){

    $('.send-message').click(function(){
        $('#send-message-popup').fadeIn();
    });
    $('.submit-rating').click(function(){
        $('#submit-rating-popup').fadeIn();
    });
    $('.popup-layer .close-popup').click(function(){
        $('.popup-layer').css('display','none');
        $('#send-message-popup').css('display','none');
        $('#submit-rating-popup').css('display','none');
    });
    $(".popup-layer").click(function(e) {
        if (!$(e.target).parents().hasClass('popup-content')) {
            $('.popup-layer').css('display','none');
            $('#send-message-popup').css('display','none');
            $('#submit-rating-popup').css('display','none');
        }
    });

    $('.terms-list-layer article ul li h3,.teachers-list-layer article ul li header').click(function(){
        var sign = $(this).parents().closest('li');
        var desc = $(this).parents().closest('li').find('.desc');
        if($(sign).hasClass('open')){
            $(sign).removeClass('open');
            $(desc).slideUp();
        }
        else{
            $(sign).addClass('open');
            $(desc).slideDown();
        }
    });

    $('.readonly-rating-star').raty({
        readOnly:true,
        number: 5,
        score: function() {
            return $(this).attr('data-score');
        }
    });

    $('.last-terms-carousel').owlCarousel({
        margin:18,
        nav:true,
        dots:false,
        rtl: true,
        autoplay:true,
        loop:true,
        autoplayHoverPause:true,
        autoplaySpeed:1000,
        responsive:{
            0:{
                items:1
            },
            480:{
                items:1
            },
            600:{
                items:2
            },
            991:{
                items:3
            },
            1199:{
                items:3
            }
        },
        navText: [
            '<i class="zmdi zmdi-caret-left"></i>',
            '<i class="zmdi zmdi-caret-right"></i>'
        ]
    });

    $('#gallery-button').click(function(){
        $('html, body').animate({
            scrollTop: $(".gallery-layer").offset().top - 20
        }, 1000);
    });
    $('#contact-button').click(function(){
        $('html, body').animate({
            scrollTop: $(".contact-info-layer").offset().top - 20
        }, 1000);
    });
    $('#submit-comment-button').click(function(){
        $('html, body').animate({
            scrollTop: $(".comments-layer").offset().top - 20
        }, 1000);
    });
    $('#submit-rating').click(function(){
        $('html, body').animate({
            scrollTop: $(".submit-rating-layer").offset().top - 20
        }, 1000);
    });
    $('#image-gallery').lightSlider({
        gallery:true,
        item:1,
        thumbItem:4,
        slideMargin: 0,
        speed:2000,
        auto:true,
        loop:true,
        pauseOnHover:true,
        rtl:true,
        mode: 'fade',
        autoWidth:true,
        onSliderLoad: function() {
            $('#image-gallery').removeClass('cS-hidden');
        }  
    });

    $('#rate-one').raty({
        number: 5,
        half: true ,
        target     : '#environment-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#rate-two').raty({
        number: 5,
        half: true ,
        target     : '#quality-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#rate-three').raty({
        number: 5,
        half: true ,
        target     : '#employees-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#rate-four').raty({
        number: 5,
        half: true ,
        target     : '#calm-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#rate-five').raty({
        number: 5,
        half: true ,
        target     : '#variety-tools-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#rate-six').raty({
        number: 5,
        half: true ,
        target     : '#quality-tools-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('.rating-row div i').click(function(){

        var element1 = 0;
        var element2 = 0;
        var element3 = 0;
        var element4 = 0;
        var element5 = 0;
        var element6 = 0;

        if($('#environment-rate').val() != 0){
            var element1 = $('#environment-rate').val();
        }
        if($('#quality-rate').val() != 0){
            var element2 = $('#quality-rate').val();
        }
        if($('#employees-rate').val() != 0){
            var element3 = $('#employees-rate').val();
        }
        if($('#calm-rate').val() != 0){
            var element4 = $('#calm-rate').val();
        }
        if($('#variety-tools-rate').val() != 0){
            var element5 = $('#variety-tools-rate').val();
        }
        if($('#quality-tools-rate').val() != 0){
            var element6 = $('#quality-tools-rate').val();
        }
        var number = (parseInt(element1) + parseInt(element2) + parseInt(element3) + parseInt(element4) + parseInt(element5) + parseInt(element6)) / 6 ;
        var num = parseFloat(number);
        var rounded = num.toFixed(1); 
        $('.show-selected-rate .view i').html(rounded);
    });
    /*$('#submit-rating-popup .popup-content > .inner').slimScroll({
        railVisible: true,
        position: 'left',
        size: '5px',
        height: '300px',
        distance: '10px',
        railColor: '#000',
        railOpacity: 0.4,
        alwaysVisible: true
    });*/
    
    $('#teacher-rate-one').raty({
        number: 5,
        half: true ,
        target     : '#level-information-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#teacher-rate-two').raty({
        number: 5,
        half: true ,
        target     : '#content-transfer-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#teacher-rate-three').raty({
        number: 5,
        half: true ,
        target     : '#behavior-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#teacher-rate-four').raty({
        number: 5,
        half: true ,
        target     : '#taking-part-rate',
        targetKeep : true,
        targetType : "number"
    });

    $('#teacher-rate-five').raty({
        number: 5,
        half: true ,
        target     : '#use-time-rate',
        targetKeep : true,
        targetType : "number"
    });
});
