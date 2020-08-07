using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Groups
{
    public class AddModel : PageModel
    {
        private ISchoolGroupsRepository _schoolGroupsRepository;
        public AddModel(ISchoolGroupsRepository schoolGroupsRepository)
        {
            _schoolGroupsRepository = schoolGroupsRepository;
        }


        [BindProperty]
        public SchoolGroupsViewModel schoolGroupsViewModel { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            List<string> SubGroup = new List<string>();

            SchoolGroup schoolGroup = new SchoolGroup();
            schoolGroup.GroupTitle = schoolGroupsViewModel.GroupTitle;
            schoolGroup.IsDelete = schoolGroupsViewModel.IsDelete;

            string txt = "";
            foreach(var text in schoolGroupsViewModel.SubGroup)
            {
                if (!text.Equals("-"))
                {
                    txt += text;
                }
                else
                {
                    SubGroup.Add(txt);
                }
            }
            

            return RedirectToPage();
        }
    }
}
