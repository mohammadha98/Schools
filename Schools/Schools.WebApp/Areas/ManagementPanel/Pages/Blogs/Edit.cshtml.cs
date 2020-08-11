using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs
{
    public class EditModel : PageModel
    {
        private IBlogRepository _blogRepository;
        private IBlogGroupsRepository _groupsRepository;
        public EditModel(IBlogRepository blogRepository, IBlogGroupsRepository groupsRepository)
        {
            _blogRepository = blogRepository;
            _groupsRepository = groupsRepository;
        }

        [BindProperty]
        public Blog Blog { get; set; }
        public void OnGet(int id,string parameter)
        {
            var blog = _blogRepository.GetBlogById(id);
            Blog = blog;
            ViewData["GroupId"] = new SelectList(_groupsRepository.GetAllGroups(parameter), "GroupId", "GroupName");

        }

        public IActionResult OnPost(int id,IFormFile imgUp)
        {
            if (!ModelState.IsValid)
                return Page();

            var blog = _blogRepository.GetBlogById(id);
            blog.Title = Blog.Title;
            blog.ShortDescription = Blog.ShortDescription;
            blog.BlogText = Blog.BlogText;
            blog.TypeId = Blog.TypeId;
            blog.GroupId = Blog.GroupId;
            blog.Tags = Blog.Tags;

            if (imgUp?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "blogs",
                    blog.BlogId + Path.GetExtension(imgUp.FileName));
                blog.ImageName = blog.BlogId + Path.GetExtension(imgUp.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imgUp.CopyTo(stream);
                }
            }

            _blogRepository.Save();
            return RedirectToPage("index");

        }
    }
}
