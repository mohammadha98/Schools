using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Galleries
{
    [PermissionsChecker(32)]
    public class EditModel : PageModel
    {
        private ISchoolRepository _school;
        private ISchoolGalleryService _gallery;
        private ISchoolGalleryRepository _schoolGallery;

        public EditModel(ISchoolRepository school, ISchoolGalleryService gallery, ISchoolGalleryRepository schoolGallery)
        {
            _school = school;
            _gallery = gallery;
            _schoolGallery = schoolGallery;
        }
        [BindProperty]
        public bool IsActive { get; set; }
        public void OnGet(int galleryId, int schoolId)
        {
            var school = _school.GetSchoolBySchoolId(schoolId);
            if (school == null) Response.Redirect("/managementPanel/Schools");
            var gallery = _schoolGallery.GetSchoolGalleryById(galleryId);
            if (gallery == null || gallery.SchoolId != schoolId)
            {
                Response.Redirect("/managementPanel/Schools");
            }
            else
            {
                IsActive = gallery.IsActive;
            }
        }

        public IActionResult OnPost(IFormFile image, int galleryId, int schoolId)
        {
            if (image != null &&!image.IsImage())
            {
                return Page();
            }
            var gallery = _schoolGallery.GetSchoolGalleryById(galleryId);
            if (gallery == null || gallery.SchoolId != schoolId)
            {
                return Redirect("/managementPanel/Schools");
            }


            gallery.IsActive = IsActive;
            _gallery.EditGallery(gallery,image);
            return Redirect("/ManagementPanel/Schools/Galleries/" + schoolId);
        }
    }
}
