using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    [PermissionsChecker(35)]

    public class AddModel : PageModel
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public AddModel(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _schoolGroupsRepository = schoolGroupsRepository;
        }


        [BindProperty] 
        public SchoolGroup SchoolGroup { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            SchoolGroup.IsDelete = false;
            _schoolGroupsRepository.CreateGroup(SchoolGroup);

            return RedirectToPage("Index");
        }
    }
}
