using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    [PermissionsChecker(35)]
    public class IndexModel : PageModel
    {
        private ISchoolGroupsService _schoolGroupsService;
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public IndexModel(ISchoolGroupsService schoolGroupsService, ISchoolGroupsRepository schoolGroupsRepository)
        {
            _schoolGroupsService = schoolGroupsService;
            _schoolGroupsRepository = schoolGroupsRepository;
        }

        public List<SchoolGroup> List { get; set; }

        public void OnGet()
        {
            List = _schoolGroupsRepository.GetAllGroups();
        }

        public IActionResult OnGetDeleteGroup(int groupId)
        {
            var group = _schoolGroupsRepository.GetSchoolGroupById(groupId);
            if (group == null)
                return Content("NotFound");
                
            
            if (_schoolGroupsService.IsGroupHasSchool(groupId))
                return Content("Error");

            _schoolGroupsRepository.DeleteGroup(group);
            return Content("Deleted");


        }
    }
}
