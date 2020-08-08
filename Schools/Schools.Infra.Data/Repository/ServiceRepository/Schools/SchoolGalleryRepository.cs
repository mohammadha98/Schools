using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolGalleryRepository:ISchoolGalleryRepository
    {
        private SchoolsDbContext _context;

        public SchoolGalleryRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public void AddSchoolGallery(SchoolGallery gallery)
        {
            _context.SchoolGalleries.Add(gallery);
            _context.SaveChanges();
        }

        public void DeleteSchoolGallery(int galleryId)
        {
            var galley = GetSchoolGalleryById(galleryId);
            if (galley != null)
            {
                galley.IsDelete = true;
                EditSchoolGallery(galley);
            }
        }

        public void EditSchoolGallery(SchoolGallery gallery)
        {
            _context.SchoolGalleries.Update(gallery);
            _context.SaveChanges();
        }

        public IEnumerable<SchoolGallery> GetSchoolGalleriesBySchoolId(int schoolId)
        {
            return _context.SchoolGalleries.Where(s => s.SchoolId == schoolId);
        }

        public SchoolGallery GetSchoolGalleryById(int galleryId)
        {
            return _context.SchoolGalleries.SingleOrDefault(s => s.GalleryId == galleryId);
        }
    }
}