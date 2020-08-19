using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Controllers.Blog
{
    public class BlogController : Controller
    {
        private IBlogServices _blogServices;
        private IBlogRepository _blogRepository;
        public BlogController(IBlogServices blogServices,IBlogRepository blogRepository)
        {
            _blogServices = blogServices;
            _blogRepository = blogRepository;
        }
        
        public IActionResult Index(int pageId=1,string filter = "",int typeId=0,int groupId=0)
        {
            ViewBag.pageId = pageId;
            ViewBag.groupId = groupId;
            ViewBag.typeId = typeId;
            return View(_blogServices.GetCourse(pageId,filter,typeId,groupId,1));
        }

        [Route("ShowBlog/{blogId}")]
        public IActionResult ShowBlog(int blogId, int groupId = 0, int typeId = 0)
        {
            ViewBag.groupId = groupId;
            ViewBag.typeId = typeId;
            var blog = _blogRepository.GetBlogById(blogId);
            if (blog != null)
            {
                blog.BlogVisit += 1;
                _blogRepository.UpdateBlog(blog);
                _blogRepository.Save();
            }
            return View(blog);
        }
    }
}
