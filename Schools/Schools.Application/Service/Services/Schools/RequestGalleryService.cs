using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class RequestGalleryService:IRequestGalleryService
    {
        private IRequestGalleryRepository _gallery;

        public RequestGalleryService(IRequestGalleryRepository gallery)
        {
            _gallery = gallery;
        }
        public bool AddGallery(List<IFormFile> galleries, int requestId)
        {
            if (galleries == null || galleries.Count < 1) return false;

            if (galleries.Any(g=>!g.IsImage()))
            {
                return false;
            }

            foreach (var item in galleries)
            {
                var fileName = SaveFileInServer.SaveFile(item, "wwwroot/images/Requests/Gallery");
                var gallery=new RequestGallery()
                {
                    IsDelete = false,
                    RequestId = requestId,
                    ImageName = fileName
                };
                _gallery.AddGallery(gallery);
            }
            _gallery.SaveChange();
            return true;

        }

        public void DeleteGallery(int galleryId)
        {
            var gallery = _gallery.GetRequestGallery(galleryId);
            DeleteFileFromServer.DeleteFile(gallery.ImageName, "wwwroot/images/Requests/Gallery");
            _gallery.DeleteRequestGallery(gallery);
        }
    }
}