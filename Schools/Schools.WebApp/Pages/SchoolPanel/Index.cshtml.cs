using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Pages.SchoolPanel
{
    public class IndexModel : PageModel
    {
        private ISchoolRepository _school;

        public IndexModel(ISchoolRepository school)
        {
            _school = school;
        }
        public School School { get; set; }
        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());

            if (School == null)
            {
                Response.Redirect("/");
            }


        }
    }
}
