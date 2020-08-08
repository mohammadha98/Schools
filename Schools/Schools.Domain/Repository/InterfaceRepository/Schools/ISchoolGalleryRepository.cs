using System.Collections.Generic;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolGalleryRepository
    {
        void AddSchoolGallery(SchoolGallery gallery);
        void DeleteSchoolGallery(int galleryId);
        void EditSchoolGallery(SchoolGallery gallery);
        IEnumerable<SchoolGallery> GetSchoolGalleriesBySchoolId(int schoolId);
        SchoolGallery GetSchoolGalleryById(int galleryId);

    }
}