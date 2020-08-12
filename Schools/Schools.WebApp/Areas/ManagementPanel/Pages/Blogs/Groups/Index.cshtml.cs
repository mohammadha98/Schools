using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    public class IndexModel : PageModel
    {
        private IBlogGroupsRepository _blogGroupsRepository;
        public IndexModel(IBlogGroupsRepository blogGroupsRepository)
        {
            _blogGroupsRepository = blogGroupsRepository;
        }

        [BindProperty]
        public IEnumerable<BlogGroup> Groups { get; set; }
        public void OnGet(string parameter)
        {
            Groups = _blogGroupsRepository.GetAllGroups(parameter);
        }
    }
}