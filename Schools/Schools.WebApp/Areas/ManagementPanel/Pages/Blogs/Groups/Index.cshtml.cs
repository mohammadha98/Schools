using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    [PermissionsChecker(27)]

    public class IndexModel : PageModel
    {
        private IBlogGroupsRepository _group;

        public IndexModel(IBlogGroupsRepository @group)
        {
            _group = @group;
        }

        [BindProperty]
        public IEnumerable<BlogGroup> Groups { get; set; }
        public void OnGet()
        {
            Groups = _group.GetAllGroups();
        }
    }
}
