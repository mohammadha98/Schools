using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels.SchoolRequest;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Schools.Requests
{
    [PermissionsChecker(29)]

    public class IndexModel : PageModel
    {
        private ISchoolRequestService _request;

        public IndexModel(ISchoolRequestService request)
        {
            _request = request;
        }
        [BindProperty]
        public SchoolRequestsViewModel RequestModel { get; set; }
        public void OnGet(int pageId=1,string manager="",bool isAccept = false)
        {
            RequestModel = _request.GetSchoolRequests(pageId,10,manager,isAccept);
        }

    }
}
