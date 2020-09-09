using Schools.Application.ViewModels;

namespace Schools.Application.Service.Interfaces
{
    public interface IAdminMainPageService
    {
        AdminMainPageViewModel GetDataForMainPage();
    }
}