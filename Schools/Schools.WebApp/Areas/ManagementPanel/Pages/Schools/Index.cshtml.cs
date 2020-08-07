using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces;
using Schools.Application.ViewModels.SchoolsViewModels;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    public class IndexModel : PageModel
    {
        private ISchoolService _school;

        public IndexModel(ISchoolService school)
        {
            _school = school;
        }
        public GetAllSchoolForAdmin SchoolModel { get; set; }
        public void OnGet(int pageId=1,string schoolName="",int shireId=0,int cityId=0,int areaId=0,int groupId=0,int subId=0)
        {
            SchoolModel = _school.GetSchoolsForAdmin(pageId, 10, schoolName, groupId, subId, shireId, cityId, areaId);
        }
    }
}
