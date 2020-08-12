
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    public class EditModel : PageModel
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public EditModel(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _schoolGroupsRepository = schoolGroupsRepository;
        }

        [BindProperty]
        public SchoolGroup SchoolGroup { get; set; }


        public void OnGet(int id)
        {
            var group = _schoolGroupsRepository.GetSchoolGroupById(id);
            if (group == null)
                Response.Redirect("/ManagementPanel/Schools/Groups");

            SchoolGroup = group;
        }

        public IActionResult OnPost(int id)
        {
            SchoolGroup.GroupId = id;
            SchoolGroup.IsDelete = false;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _schoolGroupsRepository.Update(SchoolGroup);
            return RedirectToPage("Index");
        }
    }
}
