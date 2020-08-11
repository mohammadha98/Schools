using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    public class DeleteModel : PageModel
    {
        private IBlogRepository _blogRepository;
        public DeleteModel(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [BindProperty]
        public Blog Blog { get; set; }
        public void OnGet(int id)
        {
            var blog = _blogRepository.GetBlogById(id);
            Blog = blog;
        }
        public IActionResult OnPost()
        {
            var blog = _blogRepository.GetBlogById(Blog.BlogId);
            blog.IsDelete = true;
            _blogRepository.Save();
            return RedirectToPage("index");
        }
    }
}
