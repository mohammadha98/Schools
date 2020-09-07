using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    [PermissionsChecker(26)]

    public class EditModel : PageModel
    {
        private IBlogRepository _blogRepository;
        private IBlogServices _blog;

        public EditModel(IBlogRepository blogRepository, IBlogServices blog)
        {
            _blogRepository = blogRepository;
            _blog = blog;
        }


        [BindProperty]
        public Blog Blog { get; set; }
        public void OnGet(int blogId)
        {
            Blog = _blogRepository.GetBlogById(blogId);
            if (Blog==null)
            {
                Response.Redirect("/ManagementPanel/Blogs");
            }
        }

        public IActionResult OnPost(int blogId, IFormFile imgUp)
        {
            if (!ModelState.IsValid)
                return Page();
            if (Blog.TypeId < 3 && Blog.TypeId > 6)
            {
                ModelState.AddModelError("typeId", "نوع بلاگ را انتخاب کنید");
                return Page();
            }
            var blog = _blogRepository.GetBlog(blogId);
            //New Values
            blog.Title = Blog.Title;
            blog.ShortDescription = Blog.ShortDescription;
            blog.BlogText = Blog.BlogText;
            blog.TypeId = Blog.TypeId;
            blog.GroupId = Blog.GroupId;
            blog.Tags = Blog.Tags;
            //End
           var res= _blog.EditBlog(blog, imgUp);
           if (res==false)
           {
               ModelState.AddModelError("image","عکس معتبر نمی باشد");
               return Page();
           }
            return RedirectToPage("index");
        }
    }
}
