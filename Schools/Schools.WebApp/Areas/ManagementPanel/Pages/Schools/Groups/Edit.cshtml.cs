using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    public class EditModel : PageModel
    {
        private ISchoolGroupsRepository _groups;

        public EditModel(ISchoolGroupsRepository groups)
        {
            _groups = groups;
        }
        [BindProperty]
        public string GroupTitle { get; set; }
        public void OnGet(int groupId)
        {
            var group = _groups.GetSchoolGroupById(groupId);

            if (group==null)
                Response.Redirect("/ManagementPanel/Schools/Groups");

            GroupTitle = group!.GroupTitle;
        }

        public IActionResult OnPost(int groupId)
        {
            if (string.IsNullOrEmpty(GroupTitle))
            {
                return Page();
            }
            var group = _groups.GetSchoolGroupById(groupId);
            group.GroupTitle = GroupTitle;

            _groups.EditGroup(group);
           return RedirectToPage("Index");
        }
    }
}
