using System.Collections.Generic;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Schools.Locations;

namespace Schools.Application.ViewModels.SchoolsViewModels
{
    public class SchoolsCategoryViewModel
    {
        public List<SchoolCardViewModel> Schools { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int SchoolCount { get; set; }
        public string ShireTitle { get; set; }
        public string CityTitle { get; set; }
        public string SchoolName { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string CategoryTitle { get; set; }
        public string OrderBy { get; set; }
        public List<Shire> Shires { get; set; }
        public List<City> Cities { get; set; }
        public List<SchoolGroup> SchoolGroups { get; set; }

    }
}