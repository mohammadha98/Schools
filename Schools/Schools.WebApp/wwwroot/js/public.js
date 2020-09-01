$(function(){

    $('.top-layer .top-bar .left-side .logged-in > span').click(function(){
        $('.top-layer .top-bar .left-side .logged-in .sublayer').fadeToggle();
    });

    $("html , body").click(function(e) {
        if (!$(e.target).parents().hasClass('logged-in')) {
            $('.top-layer .top-bar .left-side .logged-in .sublayer').fadeOut('fast');
        }
    });
    $('.fixed-menu .inner').slimScroll({
        railVisible: true,
        position: 'left',
        size: '4px',
        height: '100%',
        distance: '5px',
        railColor: '#000',
        railOpacity: 0.6,
        alwaysVisible: false
    });
    $('.fixed-menu .inner nav > ul li').each(function(){
        if($(this).find('ul').length > 0) {
            $(this).append('<span class="arrow-sign"><i class="zmdi zmdi-minus"></i><i class="zmdi zmdi-plus"></i></span>');
        } 
    });
    $('.fixed-menu .inner nav > ul li .arrow-sign .zmdi-plus').click(function(e){
        var parent = $(this).parent();
        e.preventDefault();
        $(this).parents().closest('li').find('ul:first').slideDown( "fast", function() {
            $(parent).find('.zmdi-plus').hide();
            $(parent).find('.zmdi-minus').show();
        }); 
    });
    $('.fixed-menu .inner nav > ul li .arrow-sign .zmdi-minus').click(function(e){
        var parent = $(this).parent();
        e.preventDefault();
        $(this).parent('.arrow-sign').parent('li').find('ul:first').slideUp( "fast", function() {
            $(parent).find('.zmdi-minus').hide();
            $(parent).find('.zmdi-plus').show();
        }); 
    });
    $('.responsive-menu').click(function(){
        $('.overlay').fadeIn('fast');
        $('.fixed-menu').animate({right: "0"});
    });
    $('.close-menu').click(function(){
        $('.overlay').fadeOut('fast');
        $('.fixed-menu').animate({right: "-310px"});
    });
    $(".overlay").click(function(e) {
        if (!$(e.target).parents().hasClass('fixed-menu')) {
            $('.overlay').fadeOut('fast');
            $('.fixed-menu').animate({right: "-310px"});
        }
    });

    function checkMenu() {
        if (!window.matchMedia('(max-width: 991px)').matches) {
            $('.fixed-menu').css('right','-310px');
            $('.overlay').css('display','none');
        }
    }

    checkMenu();

    $(window).resize(function(event) { 
        event.preventDefault();
        checkMenu();
    });

    $('.last-items-layer header .select-layer ul li input').on('change',function(){
        var $this = $(this);
        var title = $(this).val();
        $('.last-items-layer header .select-layer > span i').html('').html(title);
        $('.last-items-layer header .select-layer ul').fadeOut('fast');
    });

    $('.last-items-layer header .select-layer > span').click(function(){
        $('.last-items-layer header .select-layer ul').fadeToggle();
    });
    $('.best-item-layer header .select-layer ul li input').on('change',function(){
        var $this = $(this);
        var title = $(this).val();
        $('.best-item-layer header .select-layer > span i').html('').html(title);
        $('.best-item-layer header .select-layer ul').fadeOut('fast');
    });

    $('.best-item-layer header .select-layer > span').click(function(){
        $('.best-item-layer header .select-layer ul').fadeToggle();
    });

});
$("#shires").change(function() {
    var title = $(this).val();
    $.ajax({
        url: "/GetCityByShireTitle/"+title,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#cities").html(data);
    });
});
$(".shires").change(function () {
    var id = $(this).val();
    $.ajax({
        url: "/GetCityByShireId/" + id,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $(".cities").html(data);
    });
});
