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
        public SchoolGroup SchoolGroup { get; set; }

        public void OnGet(int id)
        {
            var group = _schoolGroupsRepository.GetSchoolGroupById(id);
            //اگر گروه خالی باشه یعنی شناسه وارد شده نا معتبر است
            if (group == null)
                Response.Redirect("/ManageMentPanel/Schools/Groups");

        }


        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            SchoolGroup.ParentId = id;
            _schoolGroupsRepository.CreateGroup(SchoolGroup);

            return RedirectToPage("Index");
        }
    }
}
