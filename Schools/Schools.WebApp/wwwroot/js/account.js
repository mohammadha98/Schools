$(function(){
    $('[data-toggle="tooltip"]').tooltip();

    $('.notification-row .message-layer .text p').click(function(){
        var $this = $(this);
        var message = $this.parents().closest('.notification-row').find('.message-text');
        $(message).slideToggle();
    });
    $('.notification-layer ul li > a').click(function(){
        var $this = $(this);
        var message = $this.parents().closest('li').find('.message-layer');
        $(message).slideToggle();
    });
    $('.terms-layer ul li > a').click(function(){
        var $this = $(this);
        var message = $this.parents().closest('li').find('.message-layer');
        $(message).slideToggle();
    });

    $('.account-layer .right-side .sidebar > header').click(function(){
        var $this = $(this);
        var $status = $(this).parent('.sidebar');
        if($status.hasClass('open')){
            $status.removeClass('open');
            $this.find('i').addClass('zmdi-chevron-down');
            $this.find('i').removeClass('zmdi-chevron-up');
            $this.parent('.sidebar').find('.inner').slideDown();
        }
        else{
            $status.addClass('open');
            $this.find('i').addClass('zmdi-chevron-up');
            $this.find('i').removeClass('zmdi-chevron-down');
            $this.parent('.sidebar').find('.inner').slideUp();
        }
    });
    $('.account-content-layer header').click(function(){
        var $this = $(this);
        var $status = $(this).parent('.account-content-layer');
        if($status.hasClass('open')){
            $status.removeClass('open');
            $this.find('i').addClass('zmdi-chevron-down');
            $this.find('i').removeClass('zmdi-chevron-up');
            $this.parent('.account-content-layer').find('.inner:first').slideDown();
        }
        else{
            $status.addClass('open');
            $this.find('i').addClass('zmdi-chevron-up');
            $this.find('i').removeClass('zmdi-chevron-down');
            $this.parent('.account-content-layer').find('.inner:first').slideUp();
        }
    });
    $('.account-content-layer header').click(function(){
        var $this = $(this);
        var $status = $(this).parent('.account-content-layer');
        if($status.hasClass('close-inner')){
            $status.removeClass('close-inner');
            $this.find('i').addClass('zmdi-chevron-down');
            $this.find('i').removeClass('zmdi-chevron-up');
            $this.parent('.account-content-layer').find('.inner:first').slideDown();
        }
        else{
            $status.addClass('close-inner');
            $this.find('i').addClass('zmdi-chevron-up');
            $this.find('i').removeClass('zmdi-chevron-down');
            $this.parent('.account-content-layer').find('.inner:first').slideUp();
        }
    });
});
