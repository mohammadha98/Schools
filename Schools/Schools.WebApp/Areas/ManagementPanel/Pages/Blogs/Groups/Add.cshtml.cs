using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Repository.InterfaceRepository.BlogRepositories;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Blogs.Groups
{
    [PermissionsChecker(27)]

    public class AddModel : PageModel
    {
        private IBlogGroupsRepository _blogGroupsRepository;
        public AddModel(IBlogGroupsRepository blogGroupsRepository)
        {
            _blogGroupsRepository = blogGroupsRepository;
        }

        [BindProperty]
        public BlogGroup groups { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var group = new BlogGroup()
            {
                GroupName = groups.GroupName
            };
            _blogGroupsRepository.InsertGroup(group);
            _blogGroupsRepository.Save();

            return RedirectToPage("Index");
        }
    }
}
