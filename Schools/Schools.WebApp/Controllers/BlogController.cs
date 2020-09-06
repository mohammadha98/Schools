using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Convertors;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private IBlogServices _blogServices;
        private IBlogRepository _blog;
        private IBlogCommentService _comment;

        public BlogController(IBlogServices blogServices, IBlogRepository blog, IBlogCommentService comment)
        {
            _blogServices = blogServices;
            _blog = blog;
            _comment = comment;
        }


        [Route("/Blogs")]
        public IActionResult Index(int page = 1, string search = "", int? typeId = null, string groupTitle = "")
        {
            ViewData["LastBlogs"] = _blogServices.GetLastBlogs(4);
            var model = _blogServices.GetBlogsByFilter(page, 21, search, typeId, groupTitle);
            return View(model);
        }

        [Route("Blog/{blogId}/{blogTitle}")]
        public IActionResult ShowBlog(int blogId)
        {
            ViewData["LastBlogs"] = _blogServices.GetLastBlogs(4);
            var blog = _blog.GetBlogById(blogId);
            if (blog == null)
            {
                return NotFound();
            }
            _blogServices.AddVisitForBlog(blog);
            //پر کردن اولیه بخش نظرات
            ViewData["Comments"] = _comment.GetBlogComments(1, 10, blogId);
            return View(blog);
        }

        public IActionResult GetBlogComments(int pageId, int blogId)
        {
            var blogComments = _comment.GetBlogComments(pageId, 10, blogId);
            if (blogComments.BlogComments == null)
            {
                return NotFound();
            }
            return PartialView("Blog/_BlogComments", blogComments);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddComment(BlogComment blogComment)
        {

            blogComment.UserId = User.GetUserId();
            if (string.IsNullOrEmpty(blogComment.Comment))
            {
                return Content("Error");
            }
            var resultComment = _comment.AddComment(blogComment);
            var userName = $"{resultComment.User.Name} {resultComment.User.Family}";
            var res = $"<div class='comment-box'><div class='img-layer'><img src='/images/userAvatars/{resultComment.User.UserAvatar}'/></div><div class='left'><span>{userName}</span><i>ارسال شده در {resultComment.CreateDate.ToShamsi()}</i><p>{blogComment.Comment}</p></div></div>";
            //اگر این نظر یک پاسخ برای یک نظر دیگه باشد وارد شرط میشه و بعد سمت کلاینت صفحه را رفرش میکنیم
            if (blogComment.Answer != null)
            {
                return Content("Success");
            }
            return Content(res);
        }
        [Authorize]
        public IActionResult DeleteComment(int commentId, int blogId)
        {

            var comment = _comment.GetBlogCommentById(commentId);
            if (comment != null)
            {
                if (comment.BlogId == blogId)
                {
                    if (comment.UserId == User.GetUserId())
                    {
                        _comment.DeleteComment(comment);
                        return Content("Deleted");
                    }
                }

            }
            return Content("Error");

        }

    }
}
