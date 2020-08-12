using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Areas.ManagementPanel.Pages.Users
{
    public class ShowProfileModel : PageModel
    {
        private IUserService _userService;
        private IUserRepository _UserRepository;

        public ShowProfileModel(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _UserRepository = userRepository;
        }

        public UserInfoViewModel UserInfoView { get; set; }

        public void OnGet(int id)
        {
            var user = _UserRepository.GetUserById(id);
            if (user != null)
                UserInfoView = _userService.GetUserInfoByUserId(user.UserId);

        }
    }
}
