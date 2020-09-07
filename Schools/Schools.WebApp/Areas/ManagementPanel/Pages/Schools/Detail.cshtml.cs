using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    [PermissionsChecker(28)]

    public class DetailModel : PageModel
    {
        private ISchoolRepository _school;

        public DetailModel(ISchoolRepository school)
        {
            _school = school;
        }
        public School School { get; set; }
        public void OnGet(int schoolId)
        {
            School = _school.GetSchoolBySchoolId(schoolId);
            if(School==null) Response.Redirect("/ManagementPanel/Schools");
        }
    }
}
