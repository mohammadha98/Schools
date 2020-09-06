using Schools.Application.ViewModels.SchoolsViewModels.SchoolRequest;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Schools;

namespace Schools.Application.Service.Interfaces.Schools
{
    public interface ISchoolRequestService
    {
        bool AddRequest(RegisterSchoolViewModel request);
        SchoolRequestsViewModel GetSchoolRequests(int pageId,int take,string managerName,bool isAccept);
        SchoolRequest GetSchoolRequest(int requestId);
        SchoolRequest GetSchoolRequestByUserId(int userId);
        void RejectRequest(SchoolRequest request,string rejectText);
        void AcceptRequest(SchoolRequest request, string hostName);
    }
}