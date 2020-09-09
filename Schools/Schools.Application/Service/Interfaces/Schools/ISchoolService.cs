using System.Collections.Generic;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Application.ViewModels.SchoolsViewModels.SchoolRequest;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolService
    {
        GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId,
            int shireId, int cityId,string hasRequest);

        SchoolsCategoryViewModel GetSchoolsForCategory(int pageId, int take, string shireTitle, string cityTitle,
            string categoryTitle, string schoolName, string courseName, string teacherName, string orderBy);

        List<SchoolCardViewModel> GetLastRegistered(int take);
        List<SchoolCardViewModel> GetSimilarSchools(int groupId);
        MainPageViewModel GetSchoolsForMainPage(string shireTitle);
        bool AddNewSchool(AddSchoolViewModel school);
        bool AddNewSchool(SchoolRequest request,AcceptOrRejectRequestViewModel acceptModel);
        bool EditSchool(EditSchoolViewModel school);
        bool IsUserHasSchool(int userId);
        void AddVisitForSchool(School school);
        EditSchoolViewModel GetSchoolForEdit(int schoolId);
        School GetSchoolById(int schoolId);
    }
}