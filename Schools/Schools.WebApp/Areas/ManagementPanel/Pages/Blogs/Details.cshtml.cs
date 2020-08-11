using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Operations;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private IBlogRepository _blogRepository;
        public DetailsModel(IBlogRepository blogRepository)
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
    }
}
