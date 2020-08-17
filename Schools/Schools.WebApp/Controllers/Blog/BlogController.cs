using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Controllers.Blog
{
    public class BlogController : Controller
    {
        private IBlogServices _blogServices;
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }
        
        public IActionResult Index(string filter = "")
        {
            return View(_blogServices.GetCourse(filter));
        }

        [Route("blog/{typeId}/{groupId}")]
        public IActionResult Course(string filter="", int typeId = 0, int groupId = 0)
        {
            return View("Index",_blogServices.GetCourse(filter,typeId, groupId));
        }
    }
}
