using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class RequestGalleryRepository:IRequestGalleryRepository
    {
        private SchoolsDbContext _db;

        public RequestGalleryRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public void AddGallery(RequestGallery gallery)
        {
            _db.RequestGalleries.Add(gallery);
            
        }

        public List<RequestGallery> GetRequestGalleries(int requestId)
        {
           return _db.RequestGalleries.Where(g => g.RequestId == requestId).ToList();
        }

        public RequestGallery GetRequestGallery(int galleryId)
        {
            return _db.RequestGalleries.FirstOrDefault(g=>g.GalleryId==galleryId);
        }

        public void DeleteRequestGallery(RequestGallery gallery)
        {
           
            gallery.IsDelete = true;
            _db.RequestGalleries.Update(gallery);
            _db.SaveChanges();
        }

        public void SaveChange()
        {
            _db.SaveChanges();
        }
    }
}