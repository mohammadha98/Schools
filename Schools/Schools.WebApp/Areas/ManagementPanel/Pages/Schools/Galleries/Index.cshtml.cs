using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Galleries
{
    public class IndexModel : PageModel
    {
        private ISchoolService _school;
        private ISchoolGalleryRepository _gallery;
        private ISchoolGalleryService _galleryService;

        public IndexModel(ISchoolService school, ISchoolGalleryRepository gallery, ISchoolGalleryService galleryService)
        {
            _school = school;
            _gallery = gallery;
            _galleryService = galleryService;
        }

        public School School { get; set; }
        public List<SchoolGallery> SchoolGalleries { get; set; }
        public void OnGet(int schoolId)
        {
            School = _school.GetSchoolById(schoolId);
            if (School == null)
            {
                Response.Redirect("/ManagementPanel/Schools");
            }
            else
            {
                SchoolGalleries = _gallery.GetSchoolGalleriesBySchoolId(schoolId).ToList();
            }
        }
        public IActionResult OnGetDeleteGallery(int schoolId, int galleryId)
        {
            var gallery = _gallery.GetSchoolGalleryById(galleryId);

            if (gallery == null || gallery.SchoolId != schoolId) return Content("NotFound");



            var res = _galleryService.DeleteGallery(galleryId, schoolId);

            return Content(res ? "Deleted" : "NotFound");
        }
    }
}
