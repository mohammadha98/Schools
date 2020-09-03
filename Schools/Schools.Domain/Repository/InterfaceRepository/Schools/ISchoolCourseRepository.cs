using System.Collections.Generic;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolCourseRepository
    {
        void AddCourse(SchoolCourse course);
        SchoolCourse GetCourseById(int courseId);
        List<SchoolCourse> GetCoursesBySchoolId(int schoolId);
        void EditCourse(SchoolCourse course);
        void DeleteCourse(SchoolCourse course);
    }
}