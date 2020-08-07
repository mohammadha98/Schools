using System.Collections.Generic;
using Schools.Domain.Models.Schools;

namespace Schools.Application.ViewModels.SchoolsViewModels
{
    public class GetAllSchoolForAdmin
    {
        public List<School> Schools { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int ShireId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string SchoolName { get; set; }
        public int GroupId { get; set; }
        public int ParentId { get; set; }


    }
}