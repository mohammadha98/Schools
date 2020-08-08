using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    public class DeleteModel : PageModel
    {
        private IBlogGroupsRepository _blogGroupsRepository;
        public DeleteModel(IBlogGroupsRepository blogGroupsRepository)
        {
            _blogGroupsRepository = blogGroupsRepository;
        }
        [BindProperty]
        public BlogGroup groups { get; set; }
        public void OnGet(int id)
        {
            var group = _blogGroupsRepository.GetGroupById(id);
            groups = group;
        }

        public IActionResult OnPost(int id)
        {
            var group = _blogGroupsRepository.GetGroupById(groups.GroupId);
            group.IsDelete = true;
            _blogGroupsRepository.Save();
            return RedirectToPage("index");
        }
    }
}
