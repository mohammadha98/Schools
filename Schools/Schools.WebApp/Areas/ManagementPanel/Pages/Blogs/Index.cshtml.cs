using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schools.Application.Service.Interfaces.Blogs;
using Schools.Application.Service.Services.Blogs;
using Schools.Application.ViewModels.BlogsViewModels;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private IBlogServices _blogServices;
        public IndexModel(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        [BindProperty]
        public List<BlogsViewModels> Blogs { get; set; }

        public void OnGet(string filter = "", int getType = 0)
        {
            Blogs = _blogServices.FilterBlog(filter, getType);
        }
    }
}
