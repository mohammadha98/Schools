using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models;
using Schools.Domain.Repository.InterfaceRepository;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.SocialNetworks
{
    public class IndexModel : PageModel
    {
        private ISocialNetworkRepository _social;

        public IndexModel(ISocialNetworkRepository social)
        {
            _social = social;
        }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public void OnGet()
        {
            SocialNetworks = _social.GetAllSocialNetworks();
        }

        public IActionResult OnGetDelete(int networkId)
        {
            var network = _social.GetSocialNetwork(networkId);
            if (network == null)
                return Content("NotFound");
                
            _social.DeleteNetwork(network);
            return Content("Deleted");
        }
    }
}
