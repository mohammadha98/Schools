using Schools.Domain.Models.AboutUs;


namespace Schools.Domain.Repository.InterfaceRepository.AboutUsRepository
{
    public interface IAboutUsRepository
    {
        AboutUs GetLast();
        AboutUs GetAboutUsById(int id);
        void Insert(AboutUs aboutUs);
        void Update(AboutUs aboutUs);
    }
}
