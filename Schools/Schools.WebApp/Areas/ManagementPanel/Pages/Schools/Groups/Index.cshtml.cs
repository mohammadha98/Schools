using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
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
