using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolRepository:ISchoolRepository
    {
        private SchoolsDbContext _context;

        public SchoolRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public IQueryable<School> GetAllSchools()
        {
            return _context.Schools
                .Include(s=>s.Shire)
                .Include(s=>s.UserLikes)
                .Include(s=>s.SchoolRates)
                .Include(s=>s.Shire)
                .Include(s=>s.City)
                .Include(s=>s.User)
                .Include(s=>s.SchoolTeachers)
                .ThenInclude(s=>s.User)
                ;
        }

        public School GetSchoolBySchoolId(int schoolId)
        {
            return _context.Schools
                .Include(s => s.User)
                .Include(s => s.SchoolTeachers)
                .ThenInclude(s => s.TeacherRates)
                .Include(s => s.SchoolGalleries)
                .Include(s => s.SchoolCourses)
                .Include(s => s.SchoolRates)
                .Include(s => s.SchoolGroup)
                .Include(s => s.SchoolSubGroup)
                .Include(s => s.Shire)
                .ThenInclude(s => s.Cities)
                .Include(s=>s.SchoolTrainingTypes)
                .ThenInclude(s=>s.TrainingType)
                .Include(s=>s.UserLikes)
                .SingleOrDefault(s => s.SchoolId == schoolId);
        }

        public School GetSchoolByUserId(int userId)
        {
            return _context.Schools
                .Include(s=>s.User)
                .Include(s=>s.SchoolTeachers)
                .ThenInclude(s=>s.TeacherRates)
                .Include(s=>s.SchoolGalleries)
                .Include(s=>s.SchoolCourses)
                .Include(s=>s.SchoolComments)
                .Include(s=>s.SchoolRates)
                .Include(s=>s.SchoolGroup)
                .Include(s=>s.SchoolSubGroup)
                .Include(s=>s.Shire)
                .ThenInclude(s=>s.Cities)
                .SingleOrDefault(s => s.SchoolManager == userId);

        }

        public void DeleteSchool(int schoolId)
        {
            var school = GetSchoolBySchoolId(schoolId);
            school.IsDelete = true;
            EditSchool(school);
        }

        public void AddSchool(School school)
        {
            _context.Schools.Add(school);
            _context.SaveChanges();
        }

        public void EditSchool(School school)
        {
            _context.Schools.Update(school);
            _context.SaveChanges();
        }

        public bool IsSchoolExist(int schoolId)
        {
            return _context.Schools.Any(s => s.SchoolId == schoolId);
        }
    }
}