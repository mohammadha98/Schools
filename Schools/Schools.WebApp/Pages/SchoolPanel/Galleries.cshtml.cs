using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Pages.SchoolPanel
{
    [PermissionsChecker(3)]
    public class GalleriesModel : PageModel
    {
        private ISchoolRepository _school;
        private ISchoolGalleryRepository _gallery;
        private ISchoolGalleryService _service;
        private IUserRoleRepository _role;

        public GalleriesModel(ISchoolRepository school, ISchoolGalleryRepository gallery, ISchoolGalleryService service, IUserRoleRepository role)
        {
            _school = school;
            _gallery = gallery;
            _service = service;
            _role = role;
        }
    

        [BindProperty]
        public IFormFile Galley { get; set; }
        public List<SchoolGallery> SchoolGalleries { get; set; }
        public School School { get; set; }

        public void OnGet()
        {
            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null)
            {
                Response.Redirect("/");
            }
            else
            {
                SchoolGalleries = _gallery.GetSchoolGalleriesBySchoolId(School.SchoolId).ToList();
            }
        }

        public IActionResult OnPost()
        {
            if (!_role.CheckPermission(User.GetUserId(),7))
            {
                return RedirectToPage("Index");
            }

            if (Galley == null) return Redirect("/SchoolPanel/Galleries");
            if (!Galley.IsImage()) return Redirect("/SchoolPanel/Galleries");

            School = _school.GetSchoolByUserId(User.GetUserId());
            if (School == null) return Redirect("/SchoolPanel/Galleries");

            var fileName = SaveFileInServer.SaveFile(Galley, "wwwroot/images/schools/gallery");
            var gallery = new SchoolGallery()
            {
                SchoolId = School.SchoolId,
                IsDelete = false,
                ImageName = fileName,
                IsActive = false
            };
            _gallery.AddSchoolGallery(gallery);
            _gallery.SaveChanges();
            TempData["Success"] = true;
            return Redirect("/SchoolPanel/Galleries");
        }

        public IActionResult OnGetDeleteGallery(int galleryId)
        {
            if (!_role.CheckPermission(User.GetUserId(), 8))
            {
                return RedirectToPage("Index");
            }

            var school = _school.GetSchoolByUserId(User.GetUserId());
            var res = _service.DeleteGallery(galleryId,school.SchoolId);

            return Content(res == false ? "error" : "Deleted");
        }
    }
}
