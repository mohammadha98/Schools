using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.SocialNetworks
{
    public class EditModel : PageModel
    {
        private ISocialNetworkRepository _social;

        public EditModel(ISocialNetworkRepository social)
        {
            _social = social;
        }
        [BindProperty]
        public SocialNetwork SocialNetwork { get; set; }
        public void OnGet(int networkId)
        {
             SocialNetwork = _social.GetSocialNetwork(networkId);
            if (SocialNetwork == null)
            {
                Response.Redirect("/ManagementPanel/SocialNetworks");
            }
        }

        public IActionResult OnPost(int networkId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SocialNetwork.SW_Id = networkId;
            _social.EditSocialNetwork(SocialNetwork);
            return RedirectToPage("Index");
        }
    }
}
