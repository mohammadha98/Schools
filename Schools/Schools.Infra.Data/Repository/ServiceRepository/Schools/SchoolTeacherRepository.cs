using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolTeacherRepository:ISchoolTeacherRepository
    {
        private SchoolsDbContext _context;

        public SchoolTeacherRepository(SchoolsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SchoolTeacher> GetTeachersBySchoolId(int schoolId)
        {
            return _context.SchoolTeachers.Where(t => t.SchoolId == schoolId);
        }

        public SchoolTeacher GetTeacherById(int teacherId)
        {
            return _context.SchoolTeachers.SingleOrDefault(t => t.TeacherId == teacherId);
        }

        public void AddTeacher(SchoolTeacher teacher)
        {
            _context.SchoolTeachers.Add(teacher);
            _context.SaveChanges();
        }

        public void EditTeacher(SchoolTeacher teacher)
        {
            _context.SchoolTeachers.Update(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(SchoolTeacher teacher)
        {
            teacher.IsDelete = true;
            EditTeacher(teacher);
        }


        public bool IsTeacherExist(int teacherId)
        {
            return _context.SchoolTeachers.Any(t => t.TeacherId == teacherId);

        }
    }
}