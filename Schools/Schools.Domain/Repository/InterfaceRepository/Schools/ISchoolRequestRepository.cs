using System.Linq;
using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolRequestRepository
    {
        IQueryable<SchoolRequest> GetAllRequest();

        void AddRequest(SchoolRequest request);
        void DeleteRequest(int requestId);
        SchoolRequest GetRequestById(int requestId);
        SchoolRequest GetRequestByUserId(int userId);
        void EditRequest(SchoolRequest request);
    }
}