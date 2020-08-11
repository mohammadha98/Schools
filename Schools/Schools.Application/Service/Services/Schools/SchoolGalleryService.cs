using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolGalleryService:ISchoolGalleryService
    {
        private ISchoolGalleryRepository _gallery;

        public SchoolGalleryService(ISchoolGalleryRepository gallery)
        {
            _gallery = gallery;
        }
        public bool AddGalleryForSchool(int schoolId, List<IFormFile> images)
        {
            //اول چک می کنیم که فایل های وارد شده عکس باشن
            if (images.Any(f => !ImageValidator.IsImage(f)))
            {
                return false;
            }

            //حالا مطمعین میشیم که تمام فایل ها عکس هست 
            foreach (var file in images)
            {
                //این کلاس وظیفه ذخیره فایل را در مسیر وارد شده رو داره
                var fileName = SaveFileInServer.SaveFile(file, "wwwroot/images/Schools/gallery");
                var imageGalley=new SchoolGallery()
                {
                    ImageName = fileName,
                    SchoolId = schoolId,
                    IsDelete = false
                };
                _gallery.AddSchoolGallery(imageGalley);
            }

            return true;
        }

        public void DeleteSchoolGalleries(int schoolId)
        {
            var galleries = _gallery.GetSchoolGalleriesBySchoolId(schoolId).ToList();
            foreach (var gallery in galleries)
            {
                //اگر فایلی در مسیر وارد شده وحود داشته باشه حذف میشه
                DeleteFileFromServer.DeleteFile(gallery.ImageName,"wwwroot/images/Schools/gallery");
                _gallery.DeleteSchoolGallery(gallery.GalleryId);
            }
        }
    }
}