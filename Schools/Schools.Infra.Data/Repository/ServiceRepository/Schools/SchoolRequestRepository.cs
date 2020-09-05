using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository.Schools
{
    public class SchoolRequestRepository:ISchoolRequestRepository
    {
        private SchoolsDbContext _db;

        public SchoolRequestRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public IQueryable<SchoolRequest> GetAllRequest()
        {
            return _db.SchoolRequests.Include(r=>r.User);
        }

        public void AddRequest(SchoolRequest request)
        {
            _db.SchoolRequests.Add(request);
            _db.SaveChanges();
        }

        public void DeleteRequest(int requestId)
        {
            var request = GetRequestById(requestId);
            request.IsDelete = true;
            _db.SchoolRequests.Update(request);
            _db.SaveChanges();
        }

        public SchoolRequest GetRequestById(int requestId)
        {
            return _db.SchoolRequests.Include(r=>r.Galleries).SingleOrDefault(r => r.RequestId == requestId);
        }

        public SchoolRequest GetRequestByUserId(int userId)
        {
            return _db.SchoolRequests.FirstOrDefault(r => r.UserId == userId);
        }

        public void EditRequest(SchoolRequest request)
        {
            _db.SchoolRequests.Update(request);
            _db.SaveChanges();
        }
    }
}