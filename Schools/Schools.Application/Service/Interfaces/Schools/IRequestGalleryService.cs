using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface IRequestGalleryService
    {
        bool AddGallery(List<IFormFile> galleries, int requestId);
        void DeleteGallery(int galleryId);
    }
}