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
    public class AddModel : PageModel
    {
        private IBlogRepository _blogRepository;
        public AddModel(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        [BindProperty]
        public Blog Blog { get; set; }
        public void OnGet()
        {
           
        }
        public IActionResult OnPost(IFormFile imgUp)
        {
            if (!ModelState.IsValid)
                return Page();

            var blog = new Blog()
            {
                Title = Blog.Title,
                ShortDescription = Blog.ShortDescription,
                BlogText = Blog.BlogText,
                Tags = Blog.Tags,
                TypeId = Blog.TypeId,
                GroupId = Blog.GroupId,
                CreateDate = DateTime.Now
            };

            _blogRepository.InsertBlog(blog);
            _blogRepository.Save();

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

            _blogRepository.UpdateBlog(blog);
            _blogRepository.Save();


            return RedirectToPage("Index");
        }
    }
}
