using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Service.Interfaces.Users;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Controllers
{
    public class BlogController : Controller
    {
        private IBlogServices _blogServices;
        private IBlogRepository _blogRepository;
        private IUserRepository _userRepository;
        public BlogController(IBlogServices blogServices,IBlogRepository blogRepository,IUserRepository userRepository)
        {
            _blogServices = blogServices;
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }
        
        public IActionResult Index(int pageId=1,string filter = "",int typeId=0,int groupId=0)
        {
            ViewBag.pageId = pageId;
            ViewBag.groupId = groupId;
            ViewBag.typeId = typeId;
            return View(_blogServices.GetCourse(pageId,filter,typeId,groupId,21));
        }

        [Route("ShowBlog/{blogId}")]
        public IActionResult ShowBlog(int blogId, int groupId = 0, int typeId = 0)
        {
            ViewBag.groupId = groupId;
            ViewBag.typeId = typeId;
            ViewBag.CommentCount = _blogRepository.CommentCount(blogId);
            var blog = _blogRepository.GetBlogById(blogId);
            if (blog != null)
            {
                blog.BlogVisit += 1;
                _blogRepository.UpdateBlog(blog);
                _blogRepository.Save();
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult CreateComment(BlogComment comment)
        {
            comment.IsDelete = false;
            comment.CreateDate = DateTime.Now;
            comment.UserId = _userRepository.GetUserIdByUserName(User.Identity.Name);
            comment.SecurityCode = 123;
            _blogRepository.AddComment(comment);

            return View("ShowComment", _blogServices.GetBlogComments(comment.BlogId));
        }
        public IActionResult ShowComment(int id, int pageId=1)
        {
            return View(_blogServices.GetBlogComments(id, pageId));
        }
    }
}
