using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolService
    {
        GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId,
            int shireId, int cityId);

        SchoolsCategoryViewModel GetSchoolsForCategory(int pageId, int take, string shireTitle, string cityTitle,
            string categoryTitle, string schoolName, string courseName, string teacherName, string orderBy);
        MainPageViewModel GetSchoolsForMainPage(string shireTitle);
        bool AddNewSchool(AddSchoolViewModel school);
        bool EditSchool(EditSchoolViewModel school);
        EditSchoolViewModel GetSchoolForEdit(int schoolId);
        School GetSchoolById(int schoolId);
    }
}