$(function () {
    $('.send-message').click(function () {
        $('#send-message-popup').fadeIn();
    });
    $('.submit-rating').click(function () {
        var teacherId = $(this).attr("data-id");
        var teacherName = $(this).attr("data-name");
        $("#teacherName").html(teacherName);
        $("#token").val(teacherId);
        $('#submit-rating-popup').fadeIn();
    });
    $('.popup-layer .close-popup').click(function () {
        $("#token").val("");
        $('.popup-layer').css('display', 'none');
        $('#send-message-popup').css('display', 'none');
        $('#submit-rating-popup').css('display', 'none');
    });
    $(".popup-layer").click(function (e) {
        if (!$(e.target).parents().hasClass('popup-content')) {
            $('.popup-layer').css('display', 'none');
            $('#send-message-popup').css('display', 'none');
            $('#submit-rating-popup').css('display', 'none');
        }
    });

    $('.terms-list-layer article ul li h3,.teachers-list-layer article ul li header').click(function () {
        var sign = $(this).parents().closest('li');
        var desc = $(this).parents().closest('li').find('.desc');
        if ($(sign).hasClass('open')) {
            $(sign).removeClass('open');
            $(desc).slideUp();
        }
        else {
            $(sign).addClass('open');
            $(desc).slideDown();
        }
    });

    $('.readonly-rating-star').raty({
        readOnly: true,
        number: 5,
        score: function () {
            return $(this).attr('data-score');
        }
    });

    $('.last-terms-carousel').owlCarousel({
        margin: 18,
        nav: true,
        dots: false,
        rtl: true,
        autoplay: true,
        loop: true,
        autoplayHoverPause: true,
        autoplaySpeed: 1000,
        responsive: {
            0: {
                items: 1
            },
            480: {
                items: 1
            },
            600: {
                items: 2
            },
            991: {
                items: 3
            },
            1199: {
                items: 3
            }
        },
        navText: [
            '<i class="zmdi zmdi-caret-left"></i>',
            '<i class="zmdi zmdi-caret-right"></i>'
        ]
    });
  
    $(".popup-layer .submit-rating-layer").submit(function () {
        event.preventDefault();
        var schoolId = window.location.pathname.split('/')[2];
        var teacherId = event.target[0].value;
        var rate1 = event.target[1].value;
        var rate2 = event.target[3].value;
        var rate3 = event.target[5].value;
        var rate4 = event.target[7].value;
        var rate5 = event.target[9].value;

        var number = (parseInt(rate1) + parseInt(rate2) + parseInt(rate3) + parseInt(rate4) + parseInt(rate5)) / 5;
        var num = parseFloat(number);
        var totalRate = num.toFixed(1);
        if (totalRate > 0) {
            swal({
                title: "امتیاز : " + totalRate,
                text: "آیا از ثبت اطمینان دارید؟",
                icon: "warning",
                buttons: ["خیر", "بله"]
            }).then((isOk) => {
                if (isOk) {
                    $.ajax({
                        url: "/School/TeacherRating?schoolId=" + schoolId + "&rate=" + totalRate + "&teacherId=" + teacherId,
                        type: "get",
                        beforeSend: function () {
                            $(".loading").show();
                        },
                        complete: function () {
                            $(".loading").hide();
                        },
                        error: function (error) {
                            if (error.status === 400) {
                                swal({
                                    title: "عملیات ناموفق",
                                    text: "شما یک بار به این استاد امتیاز داده اید",
                                    icon: "error",
                                    button: "باشه"
                                });
                                $("#submit-rating-popup").css("display", "none");

                            }
                            if (error.status === 403 ) {
                                swal({
                                    title: "عملیات ناموفق",
                                    text: "برای امتیاز دهی باید وارد حساب کاربری خود شوید",
                                    icon: "error",
                                    button: "باشه"
                                });
                                $("#submit-rating-popup").css("display", "none");

                            }
                        }
                    }).done(function (data) {
                        if (data === "Success") {
                            swal({
                                title: "اعملیات با موفقیت انجام شد",
                                icon: "success",
                                button: "باشه"
                            });
                            $("#submit-rating-popup").css("display", "none");
                        }
                    });
                }
            });
        }
    });
    $('#gallery-button').click(function () {
        $('html, body').animate({
            scrollTop: $(".gallery-layer").offset().top - 20
        }, 1000);
    });
    $('#contact-button').click(function () {
        $('html, body').animate({
            scrollTop: $(".contact-info-layer").offset().top - 20
        }, 1000);
    });
    $('#submit-comment-button').click(function () {
        $('html, body').animate({
            scrollTop: $(".comments-layer").offset().top - 20
        }, 1000);
    });
    $('#submit-rating').click(function () {
        $('html, body').animate({
            scrollTop: $(".submit-rating-layer").offset().top - 20
        }, 1000);
    });
    $('#image-gallery').lightSlider({
        gallery: true,
        item: 1,
        thumbItem: 4,
        slideMargin: 0,
        speed: 2000,
        auto: true,
        loop: true,
        pauseOnHover: true,
        rtl: true,
        mode: 'fade',
        autoWidth: true,
        onSliderLoad: function () {
            $('#image-gallery').removeClass('cS-hidden');
        }
    });

    $('#rate-one').raty({
        number: 5,
        half: true,
        target: '#environment-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#rate-two').raty({
        number: 5,
        half: true,
        target: '#quality-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#rate-three').raty({
        number: 5,
        half: true,
        target: '#employees-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#rate-four').raty({
        number: 5,
        half: true,
        target: '#calm-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#rate-five').raty({
        number: 5,
        half: true,
        target: '#variety-tools-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#rate-six').raty({
        number: 5,
        half: true,
        target: '#quality-tools-rate',
        targetKeep: true,
        targetType: "number"
    });
    $(".schoolRate").submit(function () {
        var schoolId = window.location.pathname.split('/')[2];
        event.preventDefault();
        var rate = $('.show-selected-rate .view i').html();
        if (parseFloat(rate) > 0) {
            swal({
                title: "امتیاز : " + rate,
                text: "آیا از ثبت اطمینان دارید؟",
                icon: "warning",
                buttons: ["خیر", "بله"]
            }).then((isOk) => {
                if (isOk) {
                    $.ajax({
                        url: "/School/Rating?schoolId=" + schoolId + "&rate=" + rate,
                        type: "get",
                        beforeSend: function () {
                            $(".loading").show();
                        },
                        complete: function () {
                            $(".loading").hide();
                        },
                        error: function (error) {
                            if (error.status === 400) {
                                swal({
                                    title: "عملیات ناموفق",
                                    text: "شما یک بار به این آموزشگاه امتیاز داده اید",
                                    icon: "error",
                                    button: "باشه"
                                });
                            }
                            if (error.status === 403) {
                                swal({
                                    title: "عملیات ناموفق",
                                    text: "برای درج نظر باید وارد حساب کاربری خود شوید",
                                    icon: "error",
                                    button: "باشه"
                                });
                            }
                        }
                    }).done(function (data) {
                        if (data === "Success") {
                            swal({
                                title: "اعملیات با موفقیت انجام شد",
                                icon: "success",
                                button: "باشه"
                            });
                        }
                    });
                }
            });

        }
    });
    $('.rating-row div i').click(function () {

        var element1 = 0;
        var element2 = 0;
        var element3 = 0;
        var element4 = 0;
        var element5 = 0;
        var element6 = 0;

        if ($('#environment-rate').val() != 0) {
            var element1 = $('#environment-rate').val();
        }
        if ($('#quality-rate').val() != 0) {
            var element2 = $('#quality-rate').val();
        }
        if ($('#employees-rate').val() != 0) {
            var element3 = $('#employees-rate').val();
        }
        if ($('#calm-rate').val() != 0) {
            var element4 = $('#calm-rate').val();
        }
        if ($('#variety-tools-rate').val() != 0) {
            var element5 = $('#variety-tools-rate').val();
        }
        if ($('#quality-tools-rate').val() != 0) {
            var element6 = $('#quality-tools-rate').val();
        }
        var number = (parseInt(element1) + parseInt(element2) + parseInt(element3) + parseInt(element4) + parseInt(element5) + parseInt(element6)) / 6;
        var num = parseFloat(number);
        var rounded = num.toFixed(1);
        $('.show-selected-rate .view i').html(rounded);
    });


    $('#teacher-rate-one').raty({
        number: 5,
        half: true,
        target: '#level-information-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#teacher-rate-two').raty({
        number: 5,
        half: true,
        target: '#content-transfer-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#teacher-rate-three').raty({
        number: 5,
        half: true,
        target: '#behavior-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#teacher-rate-four').raty({
        number: 5,
        half: true,
        target: '#taking-part-rate',
        targetKeep: true,
        targetType: "number"
    });

    $('#teacher-rate-five').raty({
        number: 5,
        half: true,
        target: '#use-time-rate',
        targetKeep: true,
        targetType: "number"
    });
});

function ChangePage(pageId) {
    var schoolId = window.location.pathname.split('/')[2];
    $.ajax({
        url: "/GetComments/" + pageId + "/" + schoolId,
        type: "get",
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#comments").html(data);
    });
}

function replyComment(id) {
    $("#reply-comment-id").val(id);
    var elment = document.getElementById("comments");
    elment.scrollIntoView();
    $("#comment_text").select();
}

function DeleteComment(commentId) {
    var schoolId = window.location.pathname.split('/')[2];

    swal({
        title: "آیا از حذف اطمینان دارید ؟",
        icon: "warning",
        buttons: ["خیر", "بله"]
    }).then((isOk) => {
        if (isOk) {
            $.ajax({
                url: "/School/DeleteComment?commentId=" + commentId + "&schoolId=" + schoolId,
                type: "get",
                beforeSend: function () {
                    $(".loading").show();
                },
                complete: function () {
                    $(".loading").hide();
                }
            }).done(function (data) {
                if (data === "Deleted") {
                    swal({
                        title: "اعملیات با موفقیت انجام شد",
                        icon: "success",
                        button: "باشه"
                    }).then((isOk) => {
                        location.reload();
                    });
                } else {
                    swal({
                        title: "اعملیات به مشکل برخورد کرد",
                        icon: "error",
                        button: "باشه"
                    });
                }
            });
        }
    });
}
$(".send-Comment").submit(function () {
    var schoolId = window.location.pathname.split('/')[2];
    event.preventDefault();
    var answerId = $("#reply-comment-id").val();
    var text = $("#comment_text").val();
    if (!text || text.length <= 4) {
        swal({
            title: "متن نظر را وارد کنید",
            icon: "error",
            button: "باشه"
        });
        return;
    }
    var comment = {
        Text: text,
        Answer: answerId,
        SchoolId: schoolId
    }
    $.ajax({
        url: "/School/AddComment/",
        type: "post",
        data: comment,
        beforeSend: function () {
            $(".loading").show();
        },
        complete: function () {
            $(".loading").hide();
        }
    }).done(function (data) {
        $("#comment_text").val("");
        $("#reply-comment-id").val("null");

        if (data === "Error") {
            swal({
                title: "عملیات ناموفق بود",
                icon: "error",
                button: "باشه"
            });
        } else {
            if (data === "Success") {
                swal({
                    title: "نظر شما باموفقیت ثبت شد",
                    icon: "success",
                    button: "باشه"
                }).then((isOk) => {
                    location.reload();
                });
            } else {
                swal({
                    title: "نظر شما باموفقیت ثبت شد",
                    icon: "success",
                    button: "باشه"
                });
                $(".comments-list").prepend(data);
            }

        }

    });
});
$(".like-this").click(function () {
    var schoolId = window.location.pathname.split('/')[2];

    var cls = $(this).hasClass("disabled");
    if (!cls) {
        $.ajax({
            url: "/School/LikeSchool?schoolId=" + schoolId,
            type: "get",
            beforeSend: function () {
                $(".loading").show();
            },
            complete: function () {
                $(".loading").hide();
            }
        }).done(function (data) {

            if (data === "Removed") {
                $(".like-this").removeClass("liked");
                swal({
                    title: "عملیات موفق",
                    text: "آموزشگاه از لیست علاقه مندی های شما حذف شد",
                    icon: "success",
                    button: "باشه"
                });
                var count = $(".like-count").html();
                var newCount = parseInt(count);
                $(".like-count").html(--newCount);
            }
            if (data === "Added") {
                $(".like-this").addClass("liked");
                swal({
                    title: "عملیات موفق",
                    text: "آموزشگاه به لیست علاقه مندی های شما اضافه شد",
                    icon: "success",
                    button: "باشه"
                });
                var count = $(".like-count").html();
                var newCount = parseInt(count);
                $(".like-count").html(++newCount);
            }
            if (data === "Error") {
                swal({
                    title: "عملیات ناموفق",
                    text: "لیست علاقه مندی ها فقط برای کاربران سایت فعال می باشد",
                    icon: "error",
                    button: "باشه"
                });
            }
        });
    }
});
$("#send-message-popup form").submit(function () {
    event.preventDefault();
    var schoolId = window.location.pathname.split('/')[2];
    var title = event.target[0].value;
    var text = event.target[1].value;

    if (title && title.length >= 4 && text && text.length >= 5) {
        $.ajax({
            url: "/UserPanel/Messages/SendMessage?text=" + text + "&title=" + title + "&schoolId=" + schoolId,
            type: "get",
            beforeSend: function () {
                $(".loading").show();
            },
            complete: function () {
                $(".loading").hide();
            },
            error: function (error) {
                if (error.status === 400) {
                    swal({
                        title: "عملیات ناموفق",
                        text: "اطلاعات دستکاری شده ! لطفا از دستکاری اطلاعات خودداری کنید",
                        icon: "error",
                        button: "باشه"
                    });
                }
            }
        }).done(function (data) {
            if (data === "Success") {
                swal({
                    title: "پیام شما برای آموزشگاه ارسال شد",
                    text: "می توانید از پنل کاربری پیام خود را مشاهده کنید",
                    icon: "success",
                    button: "باشه"
                });
                $(".popup-layer").css("display", "none");
            }
        });
    } else {
        swal({
            title: "عملیات ناموفق",
            text: "عنوان یا متن کوتاه است ، متن شما باید بیشتر از 5 کاراکتر باشد",
            icon: "error",
            button: "باشه"
        });
    }
});