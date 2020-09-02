using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.Generator;
using Schools.Application.Utilities.Security;
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
        private IUserRoleRepository _role;

        public AccountController(IUserRepository userRepository, IUserService userService, IUserRoleRepository role)
        {
            _userRepository = userRepository;
            _userService = userService;
            _role = role;
        }
     
        #region Register
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

            if (_userService.ActiveAccount(registerStip2.ActiveCode))
            {
                ViewData["UserId"] = registerStip2.UserId;
                return View("RegisterStip3");
            }

            return View();
        }

        [HttpPost]
        [Route("RegisterStip3")]
        public IActionResult RegisterStip3(RegisterStip3ViewModel registerStip3)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterStip3");
            }
            if (_userService.IsExistUserName(registerStip3.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وجود دارد");
                ViewData["UserId"] = registerStip3.UserId;
                return View("RegisterStip3", registerStip3);
            }
            var user = _userRepository.GetUserById(registerStip3.UserId);
            user.UserName = registerStip3.UserName;
            user.Password = PasswordHelper.EncodePasswordMd5(registerStip3.Password);
            var userRole=new UserRole()
            {
                IsDelete = false,
                RoleId = 1,
                UserId = registerStip3.UserId
            };
            _role.AddUserRole(userRole);

            return Redirect("/UserPanel/Edit");
        }
        #endregion

        #region Login
        [Route("Login")]
        public IActionResult Login(string returnTo = "/")
        {
            ViewData["returnTo"] = returnTo;
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login, string returnTo)
        {
            if (!ModelState.IsValid)
                return View(login);
            returnTo ??= "/";
            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.MobilePhone,user.PhoneNumber)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe,

                    };
                    HttpContext.SignInAsync(principal, properties);
                    return Redirect(returnTo);
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد");
                }
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
            return View();
        }
        #endregion

        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }
        #endregion
    }
}
