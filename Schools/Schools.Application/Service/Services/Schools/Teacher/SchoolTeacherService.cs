using Schools.Application.Service.Interfaces.Schools.Teacher;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools.Teacher
{

    public class SchoolTeacherService : ISchoolTeacherService
    {
        private ISchoolTeacherRepository _teacher;
        private ITeacherRateRepository _rate;

        public SchoolTeacherService(ISchoolTeacherRepository teacher, ITeacherRateRepository rate)
        {
            _teacher = teacher;
            _rate = rate;
        }
        public void DeleteTeacher(int teacherId)
        {
            var teacher = _teacher.GetTeacherById(teacherId);
            if (teacher == null)
                return;

            var rates = _rate.GetAllTeacherRateByTeacherId(teacherId);
            foreach (var item in rates)
            {
                _rate.DeleteRate(item);
            }

            teacher.IsDelete = true;
            _teacher.DeleteTeacher(teacher);
        }
    }
}