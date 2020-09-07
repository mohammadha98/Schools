using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Blogs;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    [PermissionsChecker(25)]
    public class AddModel : PageModel
    {
        private IBlogServices _blog;

        public AddModel(IBlogServices blog)
        {
            _blog = blog;
        }
        [BindProperty]
        public Blog Blog { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost(IFormFile imgUp)
        {
            if (!ModelState.IsValid)
                return Page();
            if (Blog.TypeId < 3 && Blog.TypeId > 6)
            {
                ModelState.AddModelError("typeId", "نوع بلاگ را انتخاب کنید");
                return Page();
            }

            if (imgUp == null)
            {
                ModelState.AddModelError("imgUp", "عکس را انتخاب کنید");
                return Page();
            }

            var res = _blog.AddBlog(Blog, imgUp);
            if (res == false)
            {
                ModelState.AddModelError("Image", "عکس  قابل قبول نمی باشد");
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
