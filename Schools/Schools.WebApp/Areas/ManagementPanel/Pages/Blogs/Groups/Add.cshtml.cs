using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    public class AddModel : PageModel
    {
        private IBlogGroupsRepository _blogGroupsRepository;
        public AddModel(IBlogGroupsRepository blogGroupsRepository)
        {
            _blogGroupsRepository = blogGroupsRepository;
        }

        [BindProperty]
        public BlogGroup groups { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var group = new BlogGroup()
            {
                GroupName = groups.GroupName
            };
            _blogGroupsRepository.InsertGroup(group);
            _blogGroupsRepository.Save();

            return RedirectToPage("Index");
        }
    }
}
