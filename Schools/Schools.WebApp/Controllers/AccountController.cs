using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;

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
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
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
            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("Email", "نام کاربری معتبر نمی باشد");
                return View(register);
            }
            _userService.RegisterUser(register);
            TempData["Success"] = true;
            return Redirect("/Login");
        }

        [HttpPost]
        [Route("RegisterStep2")]
        public IActionResult RegisterStep2(RegisterStip2ViewModel registerStip2)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterStep2");
            }

            if (_userService.ActiveAccount(registerStip2.ActiveCode))
            {
                ViewData["UserId"] = registerStip2.UserId;
                return View("RegisterStep3");
            }

            return View();
        }

        [HttpPost]
        [Route("RegisterStep3")]
        public IActionResult RegisterStep3(RegisterStip3ViewModel registerStip3)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterStep3");
            }
            if (_userService.IsExistUserName(registerStip3.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وجود دارد");
                ViewData["UserId"] = registerStip3.UserId;
                return View("RegisterStep3", registerStip3);
            }
            var user = _userRepository.GetUserById(registerStip3.UserId);
            user.UserName = registerStip3.UserName;
            user.Password = PasswordHelper.EncodePasswordMd5(registerStip3.Password);
            var userRole = new UserRole()
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
        public IActionResult Login(string returnUrl = "/")
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }

            if (!ModelState.IsValid)
                return View(login);
            returnUrl ??= "/";
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
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما غیرفعال باشد");
                    return View(login);
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
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect(Request.Path);
            }
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        #endregion

        #region ForgotPassword
        [HttpGet]
        [Route("/ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }
        [HttpPost]
        [Route("/ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            var user = _userRepository.GetUserIdByEmail(email);
            if (user == null)
            {
                ModelState.AddModelError("email", "ایمیل وارد شده نا معتبر است");
                return View("ForgotPassword");
            }
            _userService.ForgotPassword(user, Request.Host.ToString());
            TempData["SendEmail"] = true;
            return Redirect("/Login");
        }
        #endregion

        #region ChangePassword
        [Route("/ChangePassword/{userId}/{oldPassword}/{code}")]
        public IActionResult ChangePassword(int userId, string oldPassword, string code)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            var user = _userRepository.GetUserById(userId);
            if (user.Password == oldPassword && user.ActiveCode == code)
            {
                ViewData["userId"] = userId;
                return View();
            }

            return NotFound();
        }
        [HttpPost]
        [Route("/ChangePassword/{userId}/{oldPassword}/{code}")]
        public IActionResult ChangePassword(ChangePasswordModel passwordModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            if (!ModelState.IsValid)
            {
                return View(passwordModel);
            }
            if (passwordModel.Password != passwordModel.RePassword)
            {
                ModelState.AddModelError("RePassword", "کلمع های عبور یکسان نیستند");
                return View("ChangePassword");
            }

            _userService.ChangePassword(passwordModel);
            TempData["ChangeSuccess"] = true;
            return Redirect("/Login");
        }

        #endregion
    }
}
