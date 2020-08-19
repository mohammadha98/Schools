﻿using Microsoft.AspNetCore.Mvc;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Controllers.Blog
{
    public class PageController : Controller
    {
        private IBlogRepository _blogRepository;
        public PageController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [Route("blogPage/{blogId}")]
        public IActionResult ShowBlog(int blogId)
        {
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
