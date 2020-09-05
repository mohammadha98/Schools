using System.Collections.Generic;
using Schools.Domain.Models.Schools.Teachers;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolTeacherRepository
    {
        IEnumerable<SchoolTeacher> GetTeachersBySchoolId(int schoolId);
        SchoolTeacher GetTeacherById(int teacherId);
        void AddTeacher(SchoolTeacher teacher);
        void EditTeacher(SchoolTeacher teacher);
        void DeleteTeacher(SchoolTeacher teacher);
        bool IsTeacherExist(int teacherId);
    }
}