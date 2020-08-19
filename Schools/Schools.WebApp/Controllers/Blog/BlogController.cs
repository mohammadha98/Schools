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
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }
        
        public IActionResult Index(int pageId=1,string filter = "",int typeId=0,int groupId=0)
        {
            ViewBag.pageId = pageId;
            ViewBag.groupId = groupId;
            ViewBag.typeId = typeId;
            return View(_blogServices.GetCourse(pageId,filter,typeId,groupId,1));
        }
    }
}
