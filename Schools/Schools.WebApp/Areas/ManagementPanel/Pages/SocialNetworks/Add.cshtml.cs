using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.SocialNetworks
{
    public class AddModel : PageModel
    {
        private ISocialNetworkRepository _social;

        public AddModel(ISocialNetworkRepository social)
        {
            _social = social;
        }

        [BindProperty]
        public SocialNetwork SocialNetwork { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _social.AddSocialNetwork(SocialNetwork);
            return RedirectToPage("Index");
        }
    }
}
