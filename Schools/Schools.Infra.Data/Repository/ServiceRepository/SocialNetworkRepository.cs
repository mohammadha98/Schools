using System.Collections.Generic;
using System.Linq;
using Schools.Domain.Models;
using Schools.Domain.Repository.InterfaceRepository;
using Schools.Infra.Data.Context;

namespace Schools.Infra.Data.Repository.ServiceRepository
{
    public class SocialNetworkRepository:ISocialNetworkRepository
    {
        private SchoolsDbContext _db;

        public SocialNetworkRepository(SchoolsDbContext db)
        {
            _db = db;
        }
        public List<SocialNetwork> GetAllSocialNetworks()
        {
            return _db.SocialNetworks.ToList();
        }

        public void AddSocialNetwork(SocialNetwork network)
        {
            _db.SocialNetworks.Add(network);
            _db.SaveChanges();
        }

        public void EditSocialNetwork(SocialNetwork network)
        {
            _db.SocialNetworks.Update(network);
            _db.SaveChanges();
        }

        public void DeleteNetwork(SocialNetwork network)
        {
            _db.SocialNetworks.Remove(network);
            _db.SaveChanges();
        }

        public SocialNetwork GetSocialNetwork(int netWorkId)
        {
            return _db.SocialNetworks.SingleOrDefault(n => n.SW_Id == netWorkId);
        }
    }
}