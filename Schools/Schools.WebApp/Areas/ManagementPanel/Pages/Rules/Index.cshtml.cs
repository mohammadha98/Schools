using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Rules
{
    public class IndexModel : PageModel
    {
        private ISchoolRulesRepository _rules;

        public IndexModel(ISchoolRulesRepository rules)
        {
            _rules = rules;
        }
        public SchoolRules SchoolRules { get; set; }
        public void OnGet()
        {
            SchoolRules = _rules.GetRule();
        }
    }
}
