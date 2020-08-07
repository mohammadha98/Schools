using System;
using System.Linq;
using Schools.Application.Service.Interfaces;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolService:ISchoolService
    {
        private ISchoolRepository _school;

        public SchoolService(ISchoolRepository school)
        {
            _school = school;
        }
        public GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId, int shireId,
            int cityId, int areaId)
        {
            var result = _school.GetAllSchools();

            //Filtering

            if (string.IsNullOrEmpty(schoolName))
            {
                result = result.Where(r => r.SchoolTitle == schoolName);
            }

            if (groupId > 0)
            {
                result = result.Where(r => r.GroupId == groupId);
            }

            if (subId >0)
            {
                result = result.Where(r => r.SubGroupId == subId);
            }
            if (shireId > 0)
            {
                result = result.Where(r => r.ShireId == shireId);
            }
            if (cityId > 0)
            {
                result = result.Where(r => r.CityId == cityId);
            }
            if (areaId > 0 )
            {
                result = result.Where(r => r.AreaId == areaId);
            }

            int skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var schoolModel=new GetAllSchoolForAdmin()
            {
                Schools = result.Skip(skip).Take(take).ToList(),
                ShireId = shireId,
                CityId = cityId,
                AreaId = areaId,
                GroupId = groupId,
                ParentId = subId,
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                SchoolName = schoolName
            };
            return schoolModel;
        }
    }
}