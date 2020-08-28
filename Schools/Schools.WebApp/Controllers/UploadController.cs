﻿using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schools.Application.Utilities;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Controllers
{
    public class UploadController : Controller
    {
        private IUserRepository _user;

        public UploadController(IUserRepository user)
        {
            _user = user;
        }
        [HttpPost]
        public IActionResult UploadTicketImages(IFormFile upload)
        {
            if (upload == null)
            {
                return null;
            }
            //برای تکراری نبودن عکس از  یک نام یکتا استفاده می کنیم که شامل عدد نباشد
            var guildName = String.Concat(Guid.NewGuid().ToString("N").Select(c => (char)(c + 17)));
            var fileName = guildName + Path.GetExtension(upload.FileName)?.ToLower();

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/images/ticketImages/", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            var url = $"/images/ticketImages/{fileName}";
            return Json(new { uploaded = true, url });
        }

        [HttpPost]
        public IActionResult ChangeUserAvatar(IFormFile avatar)
        {
            //اگر فایلی به  غییر از عکس وارد کنید وارد 
            if (!avatar.IsImage())
            {
                return Redirect("/UserPanel");
            }
            var user = _user.GetUserById(User.GetUserId());
            if (user == null)
            {
                return Redirect("/UserPanel");
            }

            var imageName = SaveFileInServer.SaveFile(avatar, "wwwroot/images/userAvatars");
            user.UserAvatar = imageName;
            _user.EditUser(user);
            TempData["EditSuccess"] = true;
            return Redirect("/UserPanel");

        }
    }
}