using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    [PermissionsChecker(27)]

    public class EditModel : PageModel
    {
        private IBlogGroupsRepository _group;
        public EditModel(IBlogGroupsRepository group)
        {
            _group = group;
        }
        [BindProperty]
        public BlogGroup groups { get; set; }
        public void OnGet(int id)
        {
            var group = _group.GetGroupById(id);
            groups = group;
        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            var group = _group.GetGroupById(id);
            group.GroupName = groups.GroupName;

            _group.Save();
            return RedirectToPage("index");
        }
    }
}
