using System.Collections.Generic;
using Schools.Domain.Models.Schools.Teachers;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ITeacherRateRepository
    {
        IEnumerable<TeacherRate> GetAllTeacherRateByTeacherId(int teacherId);
        void AddRateForTeacher(TeacherRate rate);
        void DeleteRate(TeacherRate rate);
        TeacherRate GetTeacherRateById(int rateId);
    }
}