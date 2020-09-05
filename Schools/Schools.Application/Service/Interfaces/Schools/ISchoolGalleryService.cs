using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolGalleryService
    {
        bool AddGalleryForSchool(int schoolId,List<IFormFile> images);
        void DeleteSchoolGalleries(int schoolId);
        bool DeleteGallery(int galleryId,int schoolId);
        void EditGallery(SchoolGallery gallery, IFormFile image);
    }
}