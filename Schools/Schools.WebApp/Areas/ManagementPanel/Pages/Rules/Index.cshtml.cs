using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Rules
{
    [PermissionsChecker(1)]
    public class IndexModel : PageModel
    {
        private ISchoolRulesRepository _rules;

        public IndexModel(ISchoolRulesRepository rules)
        {
            _rules = rules;
        }
        public Domain.Models.Rules SchoolRules { get; set; }
        public void OnGet()
        {
            SchoolRules = _rules.GetRule();
        }
    }
}
