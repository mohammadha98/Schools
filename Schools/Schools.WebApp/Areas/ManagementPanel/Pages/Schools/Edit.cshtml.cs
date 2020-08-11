using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    public class EditModel : PageModel
    {
        private ISchoolService _school;
        private ISchoolRepository _repos;
        private IUserRepository _user;

        public EditModel(ISchoolService school, ISchoolRepository repos, IUserRepository user)
        {
            _school = school;
            _repos = repos;
            _user = user;
        }

      
       
        [BindProperty]
        public School School { get; set; }
        public void OnGet(int schoolId)
        {
            var school = _repos.GetSchoolBySchoolId(schoolId);
            if (school==null)
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
            else
            {
         
                School = school;
            }

           
        }

        public IActionResult OnPost(int schoolId, string buildDate,List<IFormFile> gallery,IFormFile avatar)
        {
            if (_user.GetUserById(School.SchoolManager) == null)
            {
                ModelState.AddModelError("SchoolManager", "کاربری با شناسه وارد شده وجود ندارد");
                return Page();

            }

            School.SchoolId = schoolId;
            School.IsDelete = false;
            if (School.ShireId == 0 || School.CityId == 0)
            {
                ModelState.AddModelError("ShireId", "لطفا موقعیت مکانی آموزشگاه را انتخاب کنید");
                return Page();
            }

            if (School.GroupId == 0)
            {
                ModelState.AddModelError("GroupId", "لطفا گروه آموزشگاه را انتخاب کنید");
                return Page();
            }
            if (string.IsNullOrEmpty(buildDate))
            {
                ModelState.AddModelError("buildDate", "لطفا تاریخ تاسیس آموزشگاه را انتخاب کنید");
                return Page();
            }
       
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // عضو اول سال ، عضو دوم ماه ، عضو سوم روز
            //std[0]=سال | std[1]= ماه | std[2]=روز
            string[] build = buildDate.Split("/");

            //تبدیل تاریخ شمسی به میلادی
            var dateConverted = new DateTime(
                int.Parse(build[0]),//سال
                int.Parse(build[1]),//ماه
                int.Parse(build[2]),//روز
                new PersianCalendar()//نوع تاریخ
            );
            School.BuildDate = dateConverted;

            // اون رو دریافت میکنیم Url  در ویو دستکاری بشه بخاطر همین از  SchoolId ممکنه که  
            School.SchoolId = schoolId;
            _school.EditSchool(School, gallery, avatar);
            return RedirectToPage("Index");
        }
    }
}
