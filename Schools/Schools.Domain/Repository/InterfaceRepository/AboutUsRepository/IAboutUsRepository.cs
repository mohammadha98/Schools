using Schools.Domain.Models.AboutUs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schools.Domain.Repository.InterfaceRepository.AboutUsRepository
{
    public interface IAboutUsRepository
    {
        IEnumerable<AboutUs> GetAllAboutUs();
        IEnumerable<AboutUs> GetLast();
        AboutUs GetAbouUsById(int id);
        void Insert(AboutUs aboutUs);
        void Update(AboutUs aboutUs);
    }
}
