using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolCourseRepository:ISchoolCourseRepository
    {
        private SchoolsDbContext _db;

        public SchoolCourseRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public void AddCourse(SchoolCourse course)
        {
            _db.SchoolCourses.Add(course);
            _db.SaveChanges();
        }

        public List<SchoolCourse> GetCoursesBySchoolId(int schoolId)
        {
            return _db.SchoolCourses.Where(c => c.SchoolId == schoolId).ToList();
        }

        public void EditCourse(SchoolCourse course)
        {
            _db.SchoolCourses.Update(course);
            _db.SaveChanges();
        }

        public void DeleteCourse(SchoolCourse course)
        {
            course.IsDelete = true;
            EditCourse(course);
        }
    }
}