using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Repository.InterfaceRepository.Locations;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Locations
{
    public class EditModel : PageModel
    {
        private ILocationRepository _location;

        public EditModel(ILocationRepository location)
        {
            _location = location;
        }
        [BindProperty]
        public Shire Shire { get; set; }
        public void OnGet(int shireId)
        {
            var shire = _location.GetShireById(shireId);
            if (shire == null)
                Response.Redirect("/ManagementPanel/Locations");

            Shire = shire;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _location.EditShire(Shire);
            return RedirectToPage("Index");
        }
    }
}
