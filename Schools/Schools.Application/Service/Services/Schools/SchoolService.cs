using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Schools.Application.Service.Interfaces;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolService:ISchoolService
    {
        private ISchoolRepository _school;
        private ISchoolGalleryService _gallery;

        public SchoolService(ISchoolRepository school, ISchoolGalleryService gallery)
        {
            _school = school;
            _gallery = gallery;
        }
        public SchoolService(ISchoolRepository school)
        {
            _school = school;
        }
        public GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId, int shireId,
            int cityId, int areaId)
        {
            var result = _school.GetAllSchools();

            //Filtering

            if (!string.IsNullOrEmpty(schoolName))
            {
                result = result.Where(r => r.SchoolTitle.Contains(schoolName));
            }

            if (groupId > 0)
            {
                result = result.Where(r => r.GroupId == groupId);
            }

            if (subId >0)
            {
                result = result.Where(r => r.SubGroupId == subId);
            }
            if (shireId > 0)
            {
                result = result.Where(r => r.ShireId == shireId);
            }
            if (cityId > 0)
            {
                result = result.Where(r => r.CityId == cityId);
            }
            if (areaId > 0 )
            {
                result = result.Where(r => r.AreaId == areaId);
            }

            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var schoolModel=new GetAllSchoolForAdmin()
            {
                Schools = result.Skip(skip).Take(take).ToList(),
                ShireId = shireId,
                CityId = cityId,
                AreaId = areaId,
                GroupId = groupId,
                ParentId = subId,
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                SchoolName = schoolName
            };
            return schoolModel;
        }

        public bool AddNewSchool(School school, List<IFormFile> gallery, IFormFile avatar)
        {
            //اول فایل ها رو چک می کنیم که اگر عکس نبودند اعملیات انجام نشود
            if (!ImageValidator.IsImage(avatar))
            {
                return false;
            }
            if (gallery.Any(f=>!ImageValidator.IsImage(f)))
            {
                return false;
            }

            var fileName = SaveFileInServer.SaveFile(avatar, "wwwroot/images/Schools");
            school.ImageName = fileName;
            school.RegisterDate=DateTime.Now;
            school.IsDelete = false;
            _school.AddSchool(school);
            //اگر اعملیات بالا به مشکل بر خورد نکند عکس های گالری رو اضافه می کنیم
           _gallery.AddGalleryForSchool(school.SchoolId, gallery);
            return true;
        }

        public bool EditSchool(School school, List<IFormFile> gallery, IFormFile avatar)
        {
            //اگر عکسی انتخاب کرده باشه وارد شرط میشه
            if (avatar !=null)
            {
                //اول فایل  رو چک می کنیم که اگر عکس نبودند اعملیات انجام نشود
                if (!ImageValidator.IsImage(avatar))
                {
                    return false;
                }
                //عکس قدیمی را از حافظه حذف می کنیم
                DeleteFileFromServer.DeleteFile(school.ImageName,"wwwroot/images/schools");
                //فایل جدید را ذخیره میکنیم
                var fileName = SaveFileInServer.SaveFile(avatar, "wwwroot/images/Schools");
                school.ImageName = fileName;
            }
            _school.EditSchool(school);
            if (gallery.Count >1)
            {
                if (gallery.Any(f => !ImageValidator.IsImage(f)))
                {
                    return false;
                }
                //اول عکس های قدیمی را حذف میکنیم
                _gallery.DeleteSchoolGalleries(school.SchoolId);
                //اگر اعملیات بالا به مشکل بر خورد نکند عکس های گالری رو اضافه می کنیم
                _gallery.AddGalleryForSchool(school.SchoolId, gallery);
            }

            return true;
        }
    }
}