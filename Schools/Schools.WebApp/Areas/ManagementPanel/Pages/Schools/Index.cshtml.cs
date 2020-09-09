using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    [PermissionsChecker(28)]

    public class IndexModel : PageModel
    {
        private ISchoolService _school;
        private ILocationService _location;
        private ISchoolGroupsRepository _groups;

        public IndexModel(ISchoolService school, ILocationService location, ISchoolGroupsRepository groups)
        {
            _school = school;
            _location = location;
            _groups = groups;
        }
   
    
        public GetAllSchoolForAdmin SchoolModel { get; set; }
        public void OnGet(int pageId=1,string schoolName="",int shireId=0,int cityId=0,int groupId=0,int subId=0,string hasRequest="")
        {
            var group = _groups.GetAllGroups();
            ViewData["groups"] =group.Where(g => g.ParentId == null).ToList();
            ViewData["subGroups"] =group.Where(g => g.ParentId == groupId).ToList();
            SchoolModel = _school.GetSchoolsForAdmin(pageId, 12, schoolName, groupId, subId, shireId, cityId,hasRequest);
        }

        public IActionResult OnGetGetCity(int shireId)
        {
            var cities = _location.GetAllCityByShireId(shireId);
            var result = "<option value='0'>انتخاب کنید</option>";

            foreach (var city in cities)
            {
                result += $"<option value='{city.CityId}'>{city.CityTitle}</option>";
            }
            return Content(result);
        }

        public IActionResult OnGetGetSubGroups(int groupId)
        {
            var groups = _groups.GetAllGroups().Where(g=>g.ParentId==groupId);
            var result = "<option value='0'>انتخاب کنید</option>";

            foreach (var sub in groups)
            {
                result += $"<option value='{sub.GroupId}'>{sub.GroupTitle}</option>";
            }
            return Content(result);
        }
    }
}
