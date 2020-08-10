using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Infra.Data.Context;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    public class AddSubGroupModel : PageModel
    {
        private SchoolsDbContext _context;
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public AddSubGroupModel(SchoolsDbContext context, ISchoolGroupsRepository schoolGroupsRepository)
        {
            _context = context;
            _schoolGroupsRepository = schoolGroupsRepository;
        }

        [BindProperty]
        public SchoolGroupsViewModel SchoolGroupsViewModel { get; set; }
        public string GroupName { get; set; }
        public int Id { get; set; }

        public void OnGet(int id)
        {
            if (id != null)
                GroupName = _schoolGroupsRepository.GetSchoolGroupById(id).GroupTitle;
                
            

            ViewData["Groups"] = _context.SchoolGroups.Where(g => g.ParentId == null).Select(g => new SelectListItem()
            {
                Text = g.GroupTitle,
                Value = g.GroupId.ToString()
            }).ToList();


        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var parentId = Id == null ? SchoolGroupsViewModel.GroupId : Id;

            _schoolGroupsRepository.CreateGroup(new SchoolGroup()
            {
                GroupTitle = SchoolGroupsViewModel.GroupTitle,
                ParentId = parentId,
                IsDelete = SchoolGroupsViewModel.IsDelete
            });


            return RedirectToPage("Index");
        }
    }
}
