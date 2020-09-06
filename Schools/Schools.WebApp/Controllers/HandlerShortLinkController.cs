using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Controllers
{
    public class HandlerShortLinkController : Controller
    {
        private ISchoolRepository _school;

        public HandlerShortLinkController(ISchoolRepository school)
        {
            _school = school;
        }
        [Route("/s/{shortLink}")]
        public IActionResult HandlerSchoolShortLink(string shortLink)
        {
            var school = _school.GetSchoolByShortLink(shortLink);
            if (school==null)
            {
                return NotFound();
            }
            var host = Request.Host;
            var path = $"/School/{school.SchoolId}/{school.SchoolTitle.Trim().Replace(" ", "-")}";
            path = String.Join(
                "/",
                path.Split("/").Select(s => System.Net.WebUtility.UrlEncode(s))
            );

            return Redirect($"https://{host}{path}");
        }
        
    }
}