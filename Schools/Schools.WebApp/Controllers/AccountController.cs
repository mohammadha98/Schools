using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.Generator;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Repository.ServiceRepository.Users;

namespace Schools.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private IUserService _userService;
        public AccountController(IUserRepository userRepository,IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userService.IsExistEmail(FixedText.FixedEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return View(register);
            }
            User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Email = FixedText.FixedEmail(register.Email),
                PhoneNumber = register.PhoneNumber,
                IsActive = false,
                RegisterDate = DateTime.Now,
                UserAvatar = "default.png"
            };
            _userRepository.AddUser(user);
            ViewData["UserId"] = user.UserId;
            return View("RegisterStip2");
        }

        [HttpPost]
        [Route("RegisterStip2")]
        public IActionResult RegisterStip2(RegisterStip2ViewModel registerStip2)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterStip2");
            }

            if (_userService.ActiveAccount(registerStip2.ActiveCode) == true)
            {
                ViewData["UserId"] = registerStip2.UserId;
                return View("RegisterStip3");
            }
            return View();
        }

        [HttpPost]
        [Route("RegisterStip3")]
        public IActionResult RegisterStip3( RegisterStip3ViewModel registerStip3)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterStip3");
            }
            var user = _userRepository.GetUserById(registerStip3.UserId);
            user.UserName = registerStip3.UserName;

            _userRepository.AddRoleUserForRegister(registerStip3.RoleId, registerStip3.UserId);


            return View("Home/Index");
        }
    }
}
