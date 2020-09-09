using System.Collections.Generic;
using Schools.Domain.Models;

namespace Schools.Domain.Repository.InterfaceRepository
{
    public interface ISocialNetworkRepository
    {
        List<SocialNetwork> GetAllSocialNetworks();
        void AddSocialNetwork(SocialNetwork network);
        void EditSocialNetwork(SocialNetwork network);
        void DeleteNetwork(SocialNetwork network);
        SocialNetwork GetSocialNetwork(int netWorkId);


    }
}