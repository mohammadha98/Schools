using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schools.Application.ViewModels.SchoolsViewModels.SchoolRequest
{
    public class SchoolRequestsViewModel
    {
        public List<Domain.Models.Schools.SchoolRequest> SchoolRequests { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public string ManagerName { get; set; }
        public bool IsAccept { get; set; }
    }

    public class AcceptOrRejectRequestViewModel
    {
        public string RejectText { get; set; }
        [Required]
        public string SchoolName { get; set; }
        public bool IsAccept { get; set; }
        public string MetaDescription { get; set; }
        public string KeyWord { get; set; }

    }
}