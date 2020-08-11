using Schools.Application.ViewModels.SchoolsViewModels;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolService
    {
        GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId,
            int shireId, int cityId);

        bool AddNewSchool(AddSchoolViewModel school);
        bool EditSchool(EditSchoolViewModel school);
        EditSchoolViewModel GetSchoolForEdit(int schoolId);
    }
}