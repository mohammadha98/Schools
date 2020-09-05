using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Rules
{
    public class AddModel : PageModel
    {
        private ISchoolRulesRepository _rules;

        public AddModel(ISchoolRulesRepository rules)
        {
            _rules = rules;
        }
        [BindProperty]
        public SchoolRules SchoolRules { get; set; }
        public void OnGet()
        {
            var rule = _rules.GetRule();
            if (rule != null)
            {
                Response.Redirect("/ManagementPanel/Rules");
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(SchoolRules.RuleTitle))
            {
                return Page();
            }
            var rule = _rules.GetRule();
            if (rule != null)
            {
                Response.Redirect("/ManagementPanel/Rules");
            }
            _rules.AddRule(SchoolRules);
            return RedirectToPage("Index");
        }
    }
}
