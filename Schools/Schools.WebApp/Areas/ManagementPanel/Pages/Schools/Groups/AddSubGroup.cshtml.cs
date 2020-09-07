using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    [PermissionsChecker(35)]

    public class AddSubGroupModel : PageModel
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public AddSubGroupModel(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _schoolGroupsRepository = schoolGroupsRepository;
        }

        public SchoolGroup SchoolGroup { get; set; }

        [BindProperty]
        public AddSchoolGroupsViewModel addSchoolGroupsViewModel { get; set; }


        public void OnGet(int id)
        {
            var group = _schoolGroupsRepository.GetSchoolGroupById(id);
            if (group == null)
                Response.Redirect("/ManagementPanel/Schools/Groups");

            SchoolGroup = group;


        }


        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            _schoolGroupsRepository.CreateGroup(new SchoolGroup()
            {
                GroupTitle = addSchoolGroupsViewModel.GroupTitle,
                IsDelete = false,
                ParentId = id
            });


            return RedirectToPage("Index");
        }
    }
}
