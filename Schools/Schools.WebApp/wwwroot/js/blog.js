function ChangePage(pageId) {
    var blogId = window.location.pathname.split('/')[2];
    $.ajax({
        url: "/Blog/GetBlogComments?pageId=" + pageId + "&blogId=" + blogId,
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
    var blogId = window.location.pathname.split('/')[2];

    swal({
        title: "آیا از حذف اطمینان دارید ؟",
        icon: "warning",
        buttons: ["خیر", "بله"]
    }).then((isOk) => {
        if (isOk) {
            $.ajax({
                url: "/Blog/DeleteComment?commentId=" + commentId + "&blogId=" + blogId,
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
    var blogId = window.location.pathname.split('/')[2];
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
    var blogComment = {
        Comment: text,
        Answer: answerId,
        BlogId: blogId
    }
    $.ajax({
        url: "/Blog/AddComment",
        type: "post",
        data: blogComment,
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
                var count = $(".count").html();
                count = parseInt(count);
                count += 1;
                $(".count").html(count);
            }

        }

    });
});