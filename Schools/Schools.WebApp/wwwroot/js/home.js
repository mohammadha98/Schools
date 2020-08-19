$(function(){

    $('.categories-layer .select-layer ul li input').on('change',function(){
        var $this = $(this);
        var title = $(this).val();
        $('.categories-layer .select-layer > span i').html('').html(title);
        $('.categories-layer .select-layer ul').fadeOut('fast');
    });

    $('.categories-layer .select-layer > span').click(function(){
        $('.categories-layer .select-layer ul').fadeToggle();
    });

    $('.categories-layer .list-layer nav').slimScroll({
        railVisible: true,
        position: 'left',
        size: '4px',
        height: '265px',
        distance: '4px',
        color: '#637886',
        railColor: '#eef1f3',
        railOpacity: 0.9,
        alwaysVisible: true
    });

    $('.popular-item-col .popular-item-carousel').owlCarousel({
        margin:18,
        nav:false,
        dots:true,
        rtl: true,
        autoplay:true,
        loop:true,
        autoplayHoverPause:true,
        autoplaySpeed:1000,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:1
            },
            991:{
                items:2
            },
            1199:{
                items:3
            }
        }/*,
        navText: [
            '<i class="zmdi zmdi-chevron-right"></i>',
            '<i class="zmdi zmdi-chevron-left"></i>'
        ]*/
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

    $('.best-item-carousel').owlCarousel({
        margin:20,
        nav:false,
        dots:true,
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
                items:4
            }
        }
    });

    $('.readonly-rating-star').raty({
        readOnly:true,
        number: 5,
        score: function() {
            return $(this).attr('data-score');
        }
    });

});
