using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolGalleryService
    {
        bool AddGalleryForSchool(int schoolId,List<IFormFile> images);
        void DeleteSchoolGalleries(int schoolId);
    }
}