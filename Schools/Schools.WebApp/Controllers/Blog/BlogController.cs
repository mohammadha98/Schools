using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Blogs;

namespace Schools.WebApp.Controllers.Blog
{
    public class BlogController : Controller
    {
        private IBlogServices _blogServices;
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }
        [Route("/Blog")]
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
