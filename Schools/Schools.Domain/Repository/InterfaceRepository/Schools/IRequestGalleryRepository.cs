using System.Collections.Generic;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface IRequestGalleryRepository
    {
        void AddGallery(RequestGallery gallery);
        List<RequestGallery> GetRequestGalleries(int requestId);
        RequestGallery GetRequestGallery(int galleryId);
        void DeleteRequestGallery(RequestGallery gallery);
        void SaveChange();
    }
}