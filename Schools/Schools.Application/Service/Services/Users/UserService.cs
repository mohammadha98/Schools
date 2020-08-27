﻿using Microsoft.EntityFrameworkCore;
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
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
