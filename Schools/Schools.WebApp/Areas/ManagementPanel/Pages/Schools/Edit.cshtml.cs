using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools
{
    public class EditModel : PageModel
    {
        private ISchoolService _school;
        
        private IUserRepository _user;

        public EditModel(ISchoolService school, IUserRepository user)
        {
            _school = school;
            _user = user;
        }

      
       
        [BindProperty]
        public EditSchoolViewModel School { get; set; }
        public void OnGet(int schoolId)
        {
            var school = _school.GetSchoolForEdit(schoolId);
            if (school == null)
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
            else
            {
         
                School = school;
            }

           
        }

        public IActionResult OnPost(int schoolId)
        {
            if (_user.GetUserById(School.SchoolManager) == null)
            {
                ModelState.AddModelError("SchoolManager", "کاربری با شناسه وارد شده وجود ندارد");
                return Page();

            }
            School.SchoolId = schoolId;
        
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
            if (string.IsNullOrEmpty(School.BuildDate))
            {
                ModelState.AddModelError("buildDate", "لطفا تاریخ تاسیس آموزشگاه را انتخاب کنید");
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _school.EditSchool(School);
            return RedirectToPage("Index");
        }
    }
}
