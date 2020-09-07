using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.Generator;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Schools.Application.Utilities;
using Schools.Application.Utilities.SaveAndDelete;

namespace Schools.Application.Service.Services.Users
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUserRoleRepository _role;

        public UserService(IUserRepository userRepository, IUserRoleRepository role)
        {
            _userRepository = userRepository;
            _role = role;
        }
        
        public bool ActiveAccount(string activeCode)
        {
            var users = _userRepository.GetUsers();
            var user = users.SingleOrDefault(u => u.ActiveCode == activeCode);

            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _userRepository.Save();
            return true;
        }

        public UserInfoViewModel GetUserInfoByUserId(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            UserInfoViewModel info = new UserInfoViewModel();
            info.User = user;
            info.userRoles = _role.GetUserRoles().Where(r=>r.UserId==userId).Select(r=>r.Role.RoleTitle).ToList();
            info.Schools = _userRepository.GetAllSchoolInUserLikesByUserId(user.UserId);
            return info;
        }

        public bool AddUser(User user, IFormFile imageAvatar)
        {
            if (imageAvatar == null) return false;
            if (!imageAvatar.IsImage()) return false;

            var fileName = SaveFileInServer.SaveFile(imageAvatar, "wwwroot/images/userAvatars");

            user.UserAvatar = fileName;
            user.RegisterDate=DateTime.Now;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            user.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            _userRepository.AddUser(user);
            return true;
        }

        public bool EditUser(User user, IFormFile imageAvatar)
        {
            if (imageAvatar != null)
            {
                if (!imageAvatar.IsImage()) return false;
                if (user.UserAvatar!="Default.png")
                {
                    DeleteFileFromServer.DeleteFile(user.UserAvatar, "wwwroot/images/userAvatars");
                }
                var fileName = SaveFileInServer.SaveFile(imageAvatar, "wwwroot/images/userAvatars");
                user.UserAvatar = fileName;
            }
          
        
            _userRepository.EditUser(user);
            return true;
        }

        public UsersForAdminPanelViewModel GetUsersByFilter(string username = "", int pageId = 1)
        {
            var result = _userRepository.GetUsers();

            if (!string.IsNullOrEmpty(username))
                result = result.Where(u => u.UserName.Contains(username));

            int take = 10;
            int skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var userModel=new UsersForAdminPanelViewModel()
            {
                Users = result.OrderByDescending(u=>u.RegisterDate).Skip(skip).Take(take).ToList(),
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5
            };

            return userModel;
        }

        public bool IsExistEmail(string email)
        {
            var users = _userRepository.GetUsers();
            return users.Any(u => u.Email == email);
        }

        public bool IsExistPassword(int userId,string password)
        {
            var user = _userRepository.GetUsers();
                var hashPassword = PasswordHelper.EncodePasswordMd5(password);
                return user.Any(u => u.UserId == userId && u.Password == hashPassword);
        }

        public bool IsExistUserName(string userName)
        {
            var users = _userRepository.GetUsers();
            return users.Any(u => u.UserName == userName);
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixedEmail(login.Email);
            var users = _userRepository.GetUsers();
            return users.SingleOrDefault(u => u.Email == email && u.Password == hashPassword);
        }

        public void RegisterUser(RegisterViewModel register)
        {
            var user = new User()
            {
                IsDelete = false,
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                IsActive = true,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                UserName = register.UserName,
                UserAvatar = "Default.png",
                RegisterDate = DateTime.Now
            };
            var userId=_userRepository.AddUser(user);
            //RoleId 2 = دانشجو
            var userRole=new UserRole()
            {
                IsDelete = false,
                RoleId = 2,
                UserId = userId
            };
            _role.AddUserRole(userRole);
        }

        public void ForgotPassword(User user,string hostName)
        {
            //First Send Email For User
            var body = $"<h2>بازیابی کلمه عبور</h2><h3><p>جناب {user.Name} {user.Family} عزیز ، با استفاده از لینک زیر میتوانید نسبت به تغییر و بازیابی کلمه عیور خود اقدام نمایید.</p></h3><p>برای تغییر کلمه عبور برروی لینک زیر کلیک کنید.</p><h3><a href='https://{hostName}/ChangePassword/{user.UserId}/{user.Password}/{user.ActiveCode}'>تغببر کلمه عبور</a></h3>";
            SendEmail.Send(user.Email,"بازیابی رمز عبور",body.BuildView());
        }

        public bool ChangePassword(ChangePasswordModel passwordModel)
        {
            var user = _userRepository.GetUserById(passwordModel.UserId);
            if (user==null)
            {
                return false;
            }

            var newPassword = PasswordHelper.EncodePasswordMd5(passwordModel.Password);
            user.Password = newPassword;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _userRepository.EditUser(user);
            return true;
        }

        public void EditUserInfo(EditUserInfoViewModel editModel)
        {
            var user = _userRepository.GetUserById(editModel.UserId);
            user.Family = editModel.Family;
            user.Name = editModel.Name;
            user.PhoneNumber = editModel.Phone;
            user.TelNumber = editModel.TelNumber;
            user.Description = editModel.AboutMe;
            user.NationalCode = editModel.NationalCode;
            _userRepository.EditUser(user);
        }

        public bool ChangePassword(ChangePasswordViewModel password)
        {
            var user = _userRepository.GetUserById(password.UserId);

            if (password.NewPassword != password.ReNewPassword)
            {
                return false;
            }

            var oldPassword = PasswordHelper.EncodePasswordMd5(password.CurrentPassword);
            if (oldPassword != user.Password)
            {
                return false;
            }

            var newPassword = PasswordHelper.EncodePasswordMd5(password.NewPassword);
            user.Password = newPassword;
            return true;
        }
    }
}
