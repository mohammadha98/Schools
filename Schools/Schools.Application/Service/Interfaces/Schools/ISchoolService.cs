using Schools.Application.ViewModels.SchoolsViewModels;

namespace Schools.Application.Service.Interfaces
{
    public interface ISchoolService
    {
        GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId,
            int shireId, int cityId, int areaId);
    }
}