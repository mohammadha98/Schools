using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    public class AddSubGroupModel : PageModel
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public AddSubGroupModel(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _schoolGroupsRepository = schoolGroupsRepository;
        }

        public SchoolGroup SchoolGroup { get; set; }

        [BindProperty]
        public AddSchoolGroupsViewModel addSchoolGroupsViewModel { get; set; }


        public void OnGet(int id)
        {
            if (id != null && id != 0)
            {
                SchoolGroup = _schoolGroupsRepository.GetSchoolGroupById(id);
            }
        }


        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            _schoolGroupsRepository.CreateGroup(new SchoolGroup()
            {
                GroupTitle = addSchoolGroupsViewModel.GroupTitle,
                IsDelete = false,
                ParentId = id
            });


            return RedirectToPage("Index");
        }
    }
}
