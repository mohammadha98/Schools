using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolGroupsService : ISchoolGroupsService
    {
        private ISchoolGroupsRepository _groups;

        public SchoolGroupsService(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _groups = schoolGroupsRepository;
        }


        public bool IsGroupHasSchool(int groupId)
        {
            var group = _groups.GetSchoolGroupById(groupId);
            if (group == null)
                return true;

            return group.Schools.Any() || group.SchoolsSub.Any();
        }

        public List<SchoolGroup> GetSchoolGroupsByShireTitle(string shireTitle)
        {
            var groups= _groups.GetAllGroups();

            var groupsModel=new List<SchoolGroup>();
            foreach (var item in groups)
            {
                //اگر گروه وارد شده آموزشگاهی زیر مجموعه اون بود که نام استانش با نام استان وارد شده یکسان باشه وارد شرط میشه
                if (item.Schools.Any(s=>s.Shire.ShireTitle==shireTitle) || item.SchoolsSub.Any(s=>s.Shire.ShireTitle==shireTitle))
                {
                    groupsModel.Add(item);
                }   
            }

            return groupsModel;
        }

        public List<SchoolGroup> GetSchoolGroups()
        {
            return _groups.GetAllGroups();
        }

        public SchoolGroup GetSchoolGroup(int groupId)
        {
            return _groups.GetSchoolGroupById(groupId);
        }
    }
}
