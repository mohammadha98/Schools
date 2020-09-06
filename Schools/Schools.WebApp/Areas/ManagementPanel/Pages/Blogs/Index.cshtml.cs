using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    [PermissionsChecker(24)]

    public class IndexModel : PageModel
    {
        private IBlogServices _blogServices;
        private IBlogRepository _blogRepository;

        public IndexModel(IBlogServices blogServices, IBlogRepository blogRepository)
        {
            _blogServices = blogServices;
            _blogRepository = blogRepository;
        }
 

        public BlogCategoryViewModel Blogs { get; set; }

        public void OnGet(int pageId=1,string search = "", int? typeId = null, string groupTitle = "")
        {
            Blogs = _blogServices.GetBlogsByFilter(pageId, 10, search, typeId, groupTitle);
        }

        public IActionResult OnGetDeleteBLog(int blogId)
        {
            var blog = _blogRepository.GetBlogById(blogId);
            if (blog==null)
            {
                return Content("NotFound");
            }

            blog.IsDelete = true;
            _blogRepository.UpdateBlog(blog);
            return Content("Deleted");
        }
    }
}
