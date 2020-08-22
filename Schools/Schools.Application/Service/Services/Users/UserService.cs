using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Application.Service.Interfaces.Users;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.Generator;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Users;
using Schools.Infra.Data.Context;
using Schools.Infra.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Schools.Application.Service.Services.Users
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private SchoolsDbContext _context;
        public UserService(IUserRepository userRepository,SchoolsDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);

            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _context.SaveChanges();
            return true;
        }

        public UserInfoViewModel GetUserInfoByUserId(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            UserInfoViewModel info = new UserInfoViewModel();
            info.User = user;
            info.userRoles = _userRepository.GetAllUserRolesByUserId(user.UserId);
            info.Schools = _userRepository.GetAllSchoolInUserLikesByUserId(user.UserId);
            return info;
        }

        public UsersForAdminPanelViewModel GetUsersByFilter(string username = "", int pageId = 1)
        {
            var list = _userRepository.GetUsers();

            if (!string.IsNullOrEmpty(username))
                list = list.Where(u => u.UserName.Contains(username));

            int take = 15;
            int skip = (pageId - 1) * take;

            UsersForAdminPanelViewModel result = new UsersForAdminPanelViewModel();
            result.CurrentPage = pageId;
            result.PageCount = list.Count() / take;
            result.GetUsers = list.OrderByDescending(u => u.RegisterDate).Take(take).Skip(skip).ToList();

            return result;
        }

        public bool IsExistEmail(string email)
        {
            var users = _userRepository.GetUsers();
            return users.Any(u => u.Email == email);
        }

        public bool IsExistPassword(int userId,string password)
        {
            var user = _userRepository.GetUsers();
            if (password != null)
            {
                var hashPassword = PasswordHelper.EncodePasswordMd5(password);
                return user.Any(u => u.UserId == userId && u.Password == hashPassword);
            }
            return true;
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
    }
}
