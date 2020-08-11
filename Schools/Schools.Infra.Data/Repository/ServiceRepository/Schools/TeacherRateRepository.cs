using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class TeacherRateRepository:ITeacherRateRepository
    {
        private SchoolsDbContext _context;

        public TeacherRateRepository(SchoolsDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TeacherRate> GetAllTeacherRateByTeacherId(int teacherId)
        {
            return _context.TeacherRates.Where(r => r.TeacherId == teacherId);
        }

        public void AddRateForTeacher(TeacherRate rate)
        {
            _context.TeacherRates.Add(rate);
            _context.SaveChanges();
        }

        public void DeleteRate(TeacherRate rate)
        {
            rate.IsDelete = true;
            _context.TeacherRates.Update(rate);
           
        }

        public TeacherRate GetTeacherRateById(int rateId)
        {
            return _context.TeacherRates.SingleOrDefault(r => r.RateId == rateId);
        }
    }
}