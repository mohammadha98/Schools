using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Galleries
{
    public class AddModel : PageModel
    {
        private ISchoolRepository _school;
        private ISchoolGalleryRepository _gallery;

        public AddModel(ISchoolRepository school, ISchoolGalleryRepository gallery)
        {
            _school = school;
            _gallery = gallery;
        }
        public bool IsActive { get; set; }
        public void OnGet(int schoolId)
        {
            var school = _school.GetSchoolBySchoolId(schoolId);
            if (school == null) Response.Redirect("/managementPanel/Schools");
        }

        public IActionResult OnPost(IFormFile image,int schoolId)
        {
            var school = _school.GetSchoolBySchoolId(schoolId);
            if (school == null) return Redirect("/managementPanel/Schools");
            if (!image.IsImage())
            {
                return Page();
            }
            var fileName = SaveFileInServer.SaveFile(image, "wwwroot/images/schools/gallery");
            var gallery=new SchoolGallery()
            {
                ImageName = fileName,
                IsActive = IsActive,
                IsDelete = false,
                SchoolId = schoolId
            };
            _gallery.AddSchoolGallery(gallery);
            return Redirect("/ManagementPanel/Schools/Galleries/" + schoolId);
        }
    }
}
