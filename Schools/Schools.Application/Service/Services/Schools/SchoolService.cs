using System;
using System.Globalization;
using System.Linq;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolService : ISchoolService
    {
        private ISchoolRepository _school;
        private ISchoolGalleryService _gallery;
        private ISchoolTrainingTypeService _typeService;
        private ILocationService _location;
        private ISchoolGroupsService _schoolGroups;

        public SchoolService(ISchoolRepository school, ISchoolGalleryService gallery, ISchoolTrainingTypeService typeService, ILocationService location, ISchoolGroupsService schoolGroups)
        {
            _school = school;
            _gallery = gallery;
            _typeService = typeService;
            _location = location;
            _schoolGroups = schoolGroups;
        }


        public GetAllSchoolForAdmin GetSchoolsForAdmin(int pageId, int take, string schoolName, int groupId, int subId, int shireId,
            int cityId)
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

            if (subId > 0)
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


            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);

            var schoolModel = new GetAllSchoolForAdmin()
            {
                Schools = result.Skip(skip).Take(take).ToList(),
                ShireId = shireId,
                CityId = cityId,
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

        public SchoolsCategoryViewModel GetSchoolsForCategory(int pageId, int take, string shireTitle, string cityTitle,
            string categoryTitle, string schoolName, string courseName, string teacherName, string orderBy)
        {
            var result = _school.GetAllSchools();
            //Filter
            if (!string.IsNullOrEmpty(shireTitle))
            {
                result = result.Where(r => r.Shire.ShireTitle.Contains(shireTitle));
            }
            if (!string.IsNullOrEmpty(cityTitle))
            {
                result = result.Where(r => r.City.CityTitle == cityTitle);

            }
            if (!string.IsNullOrEmpty(categoryTitle))
            {
                result = result.Where(r => r.SchoolGroup.GroupTitle == categoryTitle || r.SchoolSubGroup.GroupTitle == categoryTitle);

            }
            if (!string.IsNullOrEmpty(schoolName))
            {
                result = result.Where(r => r.SchoolTitle == schoolName);

            }
            if (!string.IsNullOrEmpty(courseName))
            {
                result = result.Where(r => r.SchoolCourses.Any(c => c.CourseTitle.Contains(courseName)));

            }
            if (!string.IsNullOrEmpty(teacherName))
            {
                result = result.Where(r => r.SchoolTeachers.Any(t => t.User.Name.Contains(teacherName) || t.User.Family.Contains(teacherName)));

            }

            switch (orderBy)
            {
                case "all":
                    {

                        break;
                    }
                case "popular":
                    {
                        result = result.OrderByDescending(r => r.UserLikes.Count);
                        break;
                    }
                case "topHistory":
                    {
                        result = result.OrderBy(r => r.BuildDate);
                        break;
                    }
                case "best":
                    {
                        result = result.OrderByDescending(r => r.SchoolRates.Sum(s => s.Rate) / r.SchoolRates.Count);
                        break;
                    }
            }

            //Paging
            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);
            var schoolsModel = result.Select(s => new SchoolCardViewModel()
            {
                ShireTitle = shireTitle,
                Rate = s.SchoolRates.Sum(r => r.Rate) / s.SchoolRates.Count,
                History = DateTime.Now.Year - s.BuildDate.Year,
                Like = s.UserLikes.Count,
                SchoolId = s.SchoolId,
                Title = s.SchoolTitle,
                ImageName = s.ImageName,
                CityTitle = s.City.CityTitle,
                CategoryTitle = s.SchoolSubGroup.GroupTitle ?? s.SchoolGroup.GroupTitle
            });
            var categoryModel=new SchoolsCategoryViewModel()
            {
                Schools = schoolsModel.Skip(skip).Take(take).ToList(),
                CategoryTitle = categoryTitle,
                ShireTitle = shireTitle,
                CityTitle = cityTitle,
                SchoolName = schoolName,
                OrderBy = orderBy,
                CourseName = courseName,
                TeacherName = teacherName,
                SchoolCount = result.Count(),
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                Shires = _location.GetAllShire(),
                SchoolGroups = _schoolGroups.GetSchoolGroups()
            };
            return categoryModel;
        }

        public MainPageViewModel GetSchoolsForMainPage(string shireTitle)
        {
            var result = _school.GetAllSchools();
            if (string.IsNullOrEmpty(shireTitle))
                return new MainPageViewModel();

            result = result.Where(r => r.Shire.ShireTitle == shireTitle);
            var last = result.OrderByDescending(r => r.RegisterDate).Take(16).Select(s => new SchoolCardViewModel()
            {
                ShireTitle = shireTitle,
                Rate = s.SchoolRates.Sum(r => r.Rate) / s.SchoolRates.Count,
                History = DateTime.Now.Year - s.BuildDate.Year,
                Like = s.UserLikes.Count,
                SchoolId = s.SchoolId,
                Title = s.SchoolTitle,
                ImageName = s.ImageName,
                CityTitle = s.City.CityTitle,
                CategoryTitle = s.SchoolSubGroup.GroupTitle ?? s.SchoolGroup.GroupTitle
            }).ToList();
            var popular = result.OrderByDescending(r => r.UserLikes.Count).Take(8).Select(s => new SchoolCardViewModel()
            {
                ShireTitle = shireTitle,
                Rate = s.SchoolRates.Sum(r => r.Rate) / s.SchoolRates.Count,
                History = DateTime.Now.Year - s.BuildDate.Year,
                Like = s.UserLikes.Count,
                SchoolId = s.SchoolId,
                Title = s.SchoolTitle,
                ImageName = s.ImageName,
                CityTitle = s.City.CityTitle,
                CategoryTitle = s.SchoolSubGroup.GroupTitle ?? s.SchoolGroup.GroupTitle
            }).ToList();
            var best = result.OrderByDescending(r => r.SchoolRates.Sum(s => s.Rate) / r.SchoolRates.Count).Take(8).Select(s => new SchoolCardViewModel()
            {
                ShireTitle = shireTitle,
                Rate = s.SchoolRates.Sum(r => r.Rate) / s.SchoolRates.Count,
                History = DateTime.Now.Year - s.BuildDate.Year,
                Like = s.UserLikes.Count,
                SchoolId = s.SchoolId,
                Title = s.SchoolTitle,
                ImageName = s.ImageName,
                CityTitle = s.City.CityTitle,
                CategoryTitle = s.SchoolSubGroup.GroupTitle ?? s.SchoolGroup.GroupTitle
            }).ToList();
            var schoolsModel = new MainPageViewModel()
            {
                SchoolsCount = result.Count(),
                LastRegisteredSchools = last,
                BestSchools = best,
                PopularSchools = popular,
                ShireCities = _location.GetAllCityByShireTitle(shireTitle),
                ShireTitle = shireTitle,
                SchoolGroups = _schoolGroups.GetSchoolGroupsByShireTitle(shireTitle),
                Shires = _location.GetAllShire().ToList()
            };
            return schoolsModel;
        }

        public bool AddNewSchool(AddSchoolViewModel school)
        {
            //اول فایل ها رو چک می کنیم که اگر عکس نبودند اعملیات انجام نشود
            if (!ImageValidator.IsImage(school.Avatar))
            {
                return false;
            }
            if (school.Gallery.Any(f => !ImageValidator.IsImage(f)))
            {
                return false;
            }
            //نام عکس آپلود شده
            var fileName = SaveFileInServer.SaveFile(school.Avatar, "wwwroot/images/Schools");

            // عضو اول سال ، عضو دوم ماه ، عضو سوم روز
            //std[0]=سال | std[1]= ماه | std[2]=روز
            string[] build = school.BuildDate.Split("/");
            //تبدیل تاریخ شمسی به میلادی
            var dateConverted = new DateTime(
                int.Parse(build[0]),//سال
                int.Parse(build[1]),//ماه
                int.Parse(build[2]),//روز
                new PersianCalendar()//نوع تاریخ
            );
            var schoolModel = new School()
            {
                GroupId = school.GroupId,
                ImageName = fileName,
                RegisterDate = DateTime.Now,
                BuildDate = dateConverted,
                Description = school.Description,
                MetaDescription = school.MetaDescription,
                CityId = school.CityId,
                SchoolFax = school.SchoolFax,
                IsActive = school.IsActive,
                SchoolAddress = school.SchoolAddress,
                IsDelete = false,
                SchoolManager = school.SchoolManager,
                SchoolPhone = school.SchoolPhone,
                SchoolEmail = school.SchoolEmail,
                SchoolTitle = school.SchoolTitle,
                ShireId = school.ShireId,
                SubGroupId = school.SubGroupId,
                Tags = school.Tags,
            };

            _school.AddSchool(schoolModel);
            //اگر اعملیات بالا به مشکل بر خورد نکند عکس های گالری رو اضافه می کنیم
            _gallery.AddGalleryForSchool(schoolModel.SchoolId, school.Gallery);
            foreach (var typeId in school.TrainingTypes)
            {
                _typeService.AddTrainingTypeForSchool(schoolModel.SchoolId, typeId);
            }
            return true;
        }

        public bool EditSchool(EditSchoolViewModel school)
        {
            // عضو اول سال ، عضو دوم ماه ، عضو سوم روز
            //std[0]=سال | std[1]= ماه | std[2]=روز
            string[] build = school.BuildDate.Split("/");
            //تبدیل تاریخ شمسی به میلادی
            var dateConverted = new DateTime(
                int.Parse(build[0]),//سال
                int.Parse(build[1]),//ماه
                int.Parse(build[2]),//روز
                new PersianCalendar()//نوع تاریخ
            );
            var schoolModel = new School()
            {
                GroupId = school.GroupId,
                ImageName = school.ImageName,
                RegisterDate = school.RegisterDate,
                BuildDate = dateConverted,
                Description = school.Description,
                MetaDescription = school.MetaDescription,
                CityId = school.CityId,
                SchoolFax = school.SchoolFax,
                IsActive = school.IsActive,
                SchoolAddress = school.SchoolAddress,
                IsDelete = false,
                SchoolManager = school.SchoolManager,
                SchoolPhone = school.SchoolPhone,
                SchoolEmail = school.SchoolEmail,
                SchoolTitle = school.SchoolTitle,
                ShireId = school.ShireId,
                SubGroupId = school.SubGroupId,
                Tags = school.Tags,
                SchoolId = school.SchoolId
            };
            //اگر عکسی انتخاب کرده باشه وارد شرط میشه
            if (school.Avatar != null)
            {
                //اول فایل  رو چک می کنیم که اگر عکس نبودند اعملیات انجام نشود
                if (!ImageValidator.IsImage(school.Avatar))
                {
                    return false;
                }
                //عکس قدیمی را از حافظه حذف می کنیم
                DeleteFileFromServer.DeleteFile(school.ImageName, "wwwroot/images/schools");
                //فایل جدید را ذخیره میکنیم
                var fileName = SaveFileInServer.SaveFile(school.Avatar, "wwwroot/images/Schools");
                schoolModel.ImageName = fileName;
            }
            _school.EditSchool(schoolModel);
            if (school.Gallery != null)
            {
                if (school.Gallery.Any(f => !ImageValidator.IsImage(f)))
                {
                    return false;
                }
                //اول عکس های قدیمی را حذف میکنیم
                _gallery.DeleteSchoolGalleries(school.SchoolId);
                //اگر اعملیات بالا به مشکل بر خورد نکند عکس های گالری رو اضافه می کنیم
                _gallery.AddGalleryForSchool(school.SchoolId, school.Gallery);
            }
            //نوع های قبلی رو حذف می کنیم و دوباره اضافه می کنیم
            _typeService.DeleteSchoolTrainingTypes(schoolModel.SchoolId);
            foreach (var typeId in school.TrainingTypes)
            {
                _typeService.AddTrainingTypeForSchool(schoolModel.SchoolId, typeId);
            }
            return true;
        }

        public void AddVisitForSchool(School school)
        {
            school.Visit += 1;
            _school.EditSchool(school);
        }

      
        public EditSchoolViewModel GetSchoolForEdit(int schoolId)
        {
            var mainSchool = _school.GetSchoolBySchoolId(schoolId);
            if (mainSchool == null)
            {
                return new EditSchoolViewModel();
            }
            var schoolModel = new EditSchoolViewModel()
            {
                SchoolId = mainSchool.SchoolId,
                GroupId = mainSchool.GroupId,
                IsActive = mainSchool.IsActive,
                ShireId = mainSchool.ShireId,
                MetaDescription = mainSchool.MetaDescription,
                SchoolEmail = mainSchool.SchoolEmail,
                Description = mainSchool.Description,
                ImageName = mainSchool.ImageName,
                CityId = mainSchool.CityId,
                RegisterDate = mainSchool.RegisterDate,
                SchoolAddress = mainSchool.SchoolAddress,
                SchoolManager = mainSchool.SchoolManager,
                SchoolFax = mainSchool.SchoolFax,
                SchoolPhone = mainSchool.SchoolPhone,
                SchoolTitle = mainSchool.SchoolTitle,
                SubGroupId = mainSchool.SubGroupId,
                Tags = mainSchool.Tags,
                BuildDate = mainSchool.BuildDate.ToShamsi(),
                TrainingTypes = _typeService.GetSchoolTrainingTypeId(schoolId)
            };

            return schoolModel;
        }

        public School GetSchoolById(int schoolId)
        {
            return _school.GetSchoolBySchoolId(schoolId);
        }
    }
}