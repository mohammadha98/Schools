using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Controllers
{
    public class HandlerShortLinkController : Controller
    {
        private ISchoolRepository _school;
        private IBlogRepository _blog;

        public HandlerShortLinkController(ISchoolRepository school, IBlogRepository blog)
        {
            _school = school;
            _blog = blog;
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
        [Route("/b/{shortLink}")]
        public IActionResult HandlerBlogShortLink(string shortLink)
        {
            var blog = _blog.GetBlog(shortLink);
            if (blog == null)
            {
                return NotFound();
            }
            var host = Request.Host;
            var path = $"/Blog/{blog.BlogId}/{blog.Title.Trim().Replace(" ", "-")}";
            path = String.Join(
                "/",
                path.Split("/").Select(s => System.Net.WebUtility.UrlEncode(s))
            );

            return Redirect($"https://{host}{path}");
        }
    }
}