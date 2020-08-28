using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Schools.WebApp.Controllers
{
    public class UploadController : Controller
    {
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
    }
}