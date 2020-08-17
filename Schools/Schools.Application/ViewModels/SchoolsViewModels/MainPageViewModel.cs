using System.Collections.Generic;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Schools.Locations;

namespace Schools.Application.ViewModels.SchoolsViewModels
{
    public class MainPageViewModel
    {
        public List<SchoolCardViewModel> PopularSchools { get; set; }
        public List<SchoolCardViewModel> LastRegisteredSchools { get; set; }
        public List<SchoolCardViewModel> BestSchools { get; set; }
        public List<Shire> Shires { get; set; }
        public List<City> ShireCities { get; set; }
        public List<SchoolGroup> SchoolGroups { get; set; }
        public string ShireTitle { get; set; }
        public int SchoolsCount { get; set; }

    }
}