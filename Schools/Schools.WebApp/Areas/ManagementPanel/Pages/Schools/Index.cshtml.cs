using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.ViewModels.SchoolsViewModels;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    public class IndexModel : PageModel
    {
        private ISchoolService _school;
        private ILocationService _location;

        public IndexModel(ISchoolService school, ILocationService location)
        {
            _school = school;
            _location = location;
        }
    
        public GetAllSchoolForAdmin SchoolModel { get; set; }
        public void OnGet(int pageId=1,string schoolName="",int shireId=0,int cityId=0,int areaId=0,int groupId=0,int subId=0)
        {
            SchoolModel = _school.GetSchoolsForAdmin(pageId, 10, schoolName, groupId, subId, shireId, cityId, areaId);
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

    }
}
