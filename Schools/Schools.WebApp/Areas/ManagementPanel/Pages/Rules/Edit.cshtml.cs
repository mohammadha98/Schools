using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Rules
{
    [PermissionsChecker(1)]

    public class EditModel : PageModel
    {
        private ISchoolRulesRepository _rules;

        public EditModel(ISchoolRulesRepository rules)
        {
            _rules = rules;
        }
        [BindProperty]
        public Domain.Models.Rules SchoolRules { get; set; }
        public void OnGet()
        {
            SchoolRules = _rules.GetRule();
            if (SchoolRules==null)
            {
                Response.Redirect("/ManagementPanel/Rules");
            }
        }
    }
}
