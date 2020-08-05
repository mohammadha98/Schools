$(function(){

    $('#IranMap svg g a path').hover(function() {
        var className = $(this).attr('class');
        var parrentClassName = $(this).parents().closest('g').attr('class');
        var itemName = $('.list.' + parrentClassName + ' .' + className + ' a').html();
        if (itemName) {
            $('.list.' + parrentClassName + ' .' + className + ' a').addClass('hover');
            $('#IranMap .show-title').html(itemName).css({'display': 'block'});
        }
    }, function() {
        $('.list a').removeClass('hover');
        $('#IranMap .show-title').html('').css({'display': 'none'});
    });

    $('.list.province ul li a').hover(function() {
        var className = $(this).attr('id');
        var object = '#IranMap svg g.province' + ' path.' + className;
        var currentClass = $(object).attr('class');
        $(object).attr('class', currentClass + ' hover');
    }, function() {
        var className = $(this).parent('li').attr('class');
        var object = '#IranMap svg g.province' + ' path.' + className;
        var currentClass = $(object).attr('class');
        $(object).attr('class', currentClass.replace(' hover', ''));
    });
    $('.list.island ul li a').hover(function() {
        var className = $(this).attr('id');
        var object = '#IranMap svg g.island' + ' path.' + className;
        var currentClass = $(object).attr('class');
        $(object).attr('class', currentClass + ' hover');
    }, function() {
        var className = $(this).parent('li').attr('class');
        var object = '#IranMap svg g.island' + ' path.' + className;
        var currentClass = $(object).attr('class');
        $(object).attr('class', currentClass.replace(' hover', ''));
    });

    $('#IranMap').mousemove(function(e) {
        var posx = 0;
        var posy = 0;
        if (!e)
            var e = window.event;
        if (e.pageX || e.pageY) {
            posx = e.pageX;
            posy = e.pageY;
        } else if (e.clientX || e.clientY) {
            posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
            posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
        }
        if ($('#IranMap .show-title').html()) {
            var offset = $(this).offset();
            var x = (posx - offset.left + 25) + 'px';
            var y = (posy - offset.top - 5) + 'px';
            $('#IranMap .show-title').css({'left': x, 'top': y});
        }
    });

    $('.content .left-col .list .select-options .item-title').click(function(){
        $(this).parent('.select-options').find('ul').fadeToggle();
        var list = $(this).parents().closest('.list');
        if($(list).hasClass('province')){
            $('.content .left-col .list.island .select-options ul').fadeOut('fast');
        }
        else {
            $('.content .left-col .list.province .select-options ul').fadeOut('fast');
        }
    });

    $('.content .left-col .list .select-options ul li a').click(function(){
        var $this = $(this);
        var id = $(this).attr('id');
        var title = $(this).html();
        var list = $(this).parents().closest('.list');

        $(this).parents().closest('.select-options').find('.item-title').html('').html(title).addClass('active');
        $(this).parents().closest('ul').fadeOut('fast');

        if($(list).hasClass('province')){
            $('.content .left-col .list.island .select-options .item-title').html('').html('انتخاب کنید').removeClass('active');
        }
        else {
            $('.content .left-col .list.province .select-options .item-title').html('').html('انتخاب کنید').removeClass('active');
        }

        $('.description-layer').fadeIn();
        $('.description-layer > span.item-title').html('').html(title);
    });

    $('.main-menu .responsive-menu').click(function(){
        $('.main-menu nav ul').fadeToggle('fast');
    });

    $('.search-title').click(function(){
        $('.search-layer').fadeToggle('fast');
    });
    $('.close-layer').click(function(){
        $('.search-layer').fadeOut('fast');
    });

    function checkMenu() {
        if (window.matchMedia('(max-width: 991px)').matches) {
            $('.main-menu nav ul').css('display','none');
        } else {
            $('.main-menu nav ul').css('display','block');
        }
    }

    checkMenu();

    $(window).resize(function(event) { 
        event.preventDefault();
        checkMenu();
    });


});
