$(function(){
    $('[data-toggle="tooltip"]').tooltip();

    $('.notification-row .message-layer .text p').click(function(){
        var $this = $(this);
        var message = $this.parents().closest('.notification-row').find('.message-text');
        $(message).slideToggle();
    });
    $('.notification-layer ul li > a').click(function () {
        var counter = 1;
        var $this = $(this);
        var message = $this.parents().closest('li').find('.message-layer');
        $(message).slideToggle();
        var id = message.attr("data-item");
        if (id) {
           $.ajax({
               url: "/UserPanel/Notifications/SeeNotification?id=" + id,
               type: "get"
           }).done(function () {
               $(message).removeAttr("data-item");
           });
       }
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
function ChangePage(pageId) {
    $("#pageId").val(pageId);
    $(".form-layer-style").submit();
}
$(".submit-button").click(function() {
    $("#pageId").val(1);

});

function deleteItem(notificationId) {
    swal({
        title: "آیا از حذف اطمینان دارید؟",
        icon: "warning",
        buttons: ["خیر", "بله"]
    }).then((isOk) => {
        if (isOk) {
            $.ajax({
                url: "/UserPanel/Notifications/DeleteNotification?notificationId=" + notificationId,
                type: "get",
                beforeSend: function() {
                    $(".loading").show();
                },
                complete: function() {
                    $(".loading").hide();
                }
            }).done(function(data) {
                if (data === "Deleted") {
                    swal({
                        title: "عملیات  با موفقیت انجام شد",
                        icon: "success",
                        button: "باشه"
                    }).then((isOk) => {
                        location.reload();
                    });
                } else {
                    swal({
                        title: "عملیات به مشکل برخورد کرد",
                        icon: "error",
                        button: "باشه"
                    });
                }
            });
        }
    });
}
$("#upImgAvatar").change(function() {
    $("#changeAvatar").submit();
});