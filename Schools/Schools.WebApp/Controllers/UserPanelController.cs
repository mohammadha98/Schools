using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Controllers
{
    public class UserPanelController : Controller
    {
        private IUserRepository _userRepository;
        private IUserService _userService;
        public UserPanelController(IUserRepository userRepository,IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("UserPanel/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var user = _userRepository.GetUserById(id);
            return View(user);
        }
        [HttpPost]
        [Route("UserPanel/Edit/{id}")]
        public IActionResult Edit(int id,User user)
        {
            if (!ModelState.IsValid)
                return View();

                var User = _userRepository.GetUserById(id);
                User.Name = user.Name;
                User.Family = user.Family;
                User.NatinalCode = user.NatinalCode;
                User.TelNumber = user.TelNumber;
                User.PhoneNumber = user.PhoneNumber;
                User.Description = user.Description;

                _userRepository.EditUser(User);
            return View();
        }

        [Route("UserPanel/EditPassword/{id}")]
        public IActionResult EditPassword(int id)
        {
            
            return View();
        }

        [HttpPost]
        [Route("UserPanel/EditPassword/{id}")]
        public IActionResult EditPassword(int id, EditPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            ViewData["Sucsses"] = _userService.IsExistPassword(id, model.CurentPassword);
            if (_userService.IsExistPassword(id,model.CurentPassword))
            {
                var user = _userRepository.GetUserById(id);
                user.Password =PasswordHelper.EncodePasswordMd5(model.NewPassword);
                _userRepository.Save();
            }
            return View();
        }

    }
}
