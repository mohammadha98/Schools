using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    [PermissionsChecker(27)]
    public class DeleteModel : PageModel
    {
        private IBlogGroupsRepository _group;
        public DeleteModel(IBlogGroupsRepository blogGroupsRepository)
        {
            _group = blogGroupsRepository;
        }
        [BindProperty]
        public BlogGroup groups { get; set; }
        public void OnGet(int id)
        {
            var group = _group.GetGroupById(id);
            groups = group;
        }

        public IActionResult OnPost()
        {
            var group = _group.GetGroupById(groups.GroupId);
            group.IsDelete = true;
            _group.Save();
            return RedirectToPage("index");
        }
    }
}
