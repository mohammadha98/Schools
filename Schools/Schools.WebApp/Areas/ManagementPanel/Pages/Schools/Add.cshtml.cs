using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    public class AddModel : PageModel
    {
        private ISchoolService _school;
        private IUserRepository _user;

        public AddModel(ISchoolService school, IUserRepository user)
        {
            _school = school;
            _user = user;
        }
        [BindProperty]
        public School School { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string buildDate, List<IFormFile> gallery, IFormFile avatar)
        {
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
            if (avatar == null || gallery.Count < 1)
            {
                ModelState.AddModelError("avatar", "انتخاب عکس اجباری است");
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
            if (_user.GetUserById(School.SchoolManager) == null)
            {
                ModelState.AddModelError("SchoolManager", "کاربری با شناسه وارد شده وجود ندارد");
                return Page();

            }
            var result = _school.AddNewSchool(School, gallery, avatar);

            if (result == false)
            {
                ModelState.AddModelError("avatar", "شما فقط مجاز به انتخاب عکس می باشید");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
