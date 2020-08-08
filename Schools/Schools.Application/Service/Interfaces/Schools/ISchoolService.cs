using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolService
    {
        GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId,
            int shireId, int cityId, int areaId);

        bool AddNewSchool(School school,List<IFormFile> gallery ,IFormFile avatar);
        bool EditSchool(School school, List<IFormFile> gallery, IFormFile avatar);
    }
}