using System;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Linq;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities.Convertors;
using Schools.Application.Utilities.SaveAndDelete;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.SchoolsViewModels.SchoolRequest;
using Schools.Application.ViewModels.UsersViewModel;
using Schools.Domain.Models.Schools;
using Schools.Domain.Repository.InterfaceRepository.Schools;

namespace Schools.Application.Service.Services.Schools
{
    public class SchoolRequestService : ISchoolRequestService
    {
        private ISchoolRequestRepository _request;
        private IRequestGalleryService _gallery;

        public SchoolRequestService(ISchoolRequestRepository request, IRequestGalleryService gallery)
        {
            _request = request;
            _gallery = gallery;
        }
        public bool AddRequest(RegisterSchoolViewModel request)
        {
            //اگر فایل های وارد شده عکس نبودند عملیات متوقف میشه
            if (!request.SchoolImage.IsImage()) return false;
            if (request.Documents.Any(d => !d.IsImage())) return false;
            if (request.Galleries.Any(g => !g.IsImage())) return false;


            
            var requestModel = new SchoolRequest()
            {
                CellPhone = request.CellPhone,
                CityId = request.CityId,
                Email = request.Email,
                Description = request.Description,
                Fax = request.Fax,
                IsDelete = false,
                TelePhone = request.TelePhone,
                SchoolName = request.SchoolName,
                ShireId = request.ShireId,
                UserId = request.UserId,
                CreateDate = DateTime.Now,
                IsAccept = false,
                CategoryId = request.CategoryId,
                Address = request.Address
            };
            var counter = 1;
            foreach (var types in request.TrainingTypes)
            {
                if (counter>1)
                {
                    requestModel.TrainingTypes += $"{types}-";
                }
                else
                {
                    requestModel.TrainingTypes += $"{types}";
                }
                counter += 1;
            }
            //ممکنه فرمت تاریخ سمت کلاینت دستکاری شده باشه
            try
            {
                string[] bld = request.BuildDate.Split("/");
                requestModel.BuildDate = new DateTime(
                   int.Parse(bld[0].PersianToEnglish()),//سال
                   int.Parse(bld[1].PersianToEnglish()),//ماه
                   int.Parse(bld[2].PersianToEnglish()),//روز
                   new PersianCalendar()//نوع تاریخ
               );
            }
            catch (Exception e)
            {
                return false;
            }
            //ذخیره عکس ها
            var imageName = SaveFileInServer.SaveFile(request.SchoolImage, "wwwroot/images/Requests");
            foreach (var document in request.Documents)
            {
                var fileName = SaveFileInServer.SaveFile(document, "wwwroot/images/Requests/Documents");
                requestModel.DocumentsImage += fileName + "&";
            }
            //حذف علامت & اضافی از متن
            requestModel.DocumentsImage = requestModel.DocumentsImage.Remove(requestModel.DocumentsImage.Length-1, 1);
            requestModel.ImageName = imageName;

            _request.AddRequest(requestModel);
            try
            {
                _gallery.AddGallery(request.Galleries, requestModel.RequestId);
            }
            catch (Exception e)
            {
                return true;
            }
            return true;
        }

        public SchoolRequestsViewModel GetSchoolRequests(int pageId, int take, string managerName, bool isAccept)
        {
            var result = _request.GetAllRequest();

            if (!string.IsNullOrEmpty(managerName))
            {
                result = result.Where(r => r.User.Name.Contains(managerName) || r.User.Family.Contains(managerName));
            }

            if (isAccept)
            {
                result = result.Where(r => r.IsAccept);
            }
            else
            {
                result = result.Where(r => r.IsAccept == false);
            }

            var skip = (pageId - 1) * take;
            var pageCount = (int)Math.Ceiling(result.Count() / (double)take);
            var requestModel = new SchoolRequestsViewModel()
            {
                CurrentPage = pageId,
                PageCount = pageCount,
                StartPage = (pageId - 4 <= 0) ? 1 : pageId - 4,
                EndPage = (pageId + 5 > pageCount) ? pageCount : pageId + 5,
                SchoolRequests = result.Skip(skip).Take(take).ToList()
            };
            return requestModel;
        }

        public SchoolRequest GetSchoolRequest(int requestId)
        {
            return _request.GetRequestById(requestId);

        }

        public SchoolRequest GetSchoolRequestByUserId(int userId)
        {
            return _request.GetRequestByUserId(userId);
        }

        public void RejectRequest(SchoolRequest request)
        {
            if (request==null)
                return;

            //حذف عکس های آپلود شده
            foreach (var gallery in request.Galleries)
            {
                DeleteFileFromServer.DeleteFile(gallery.ImageName, "wwwroot/images/Requests/Gallery");
            }
            foreach (var item in request.DocumentsImage.Split('&'))
            {
                DeleteFileFromServer.DeleteFile(item, "wwwroot/images/Requests/Documents");
            }
            DeleteFileFromServer.DeleteFile(request.ImageName, "wwwroot/images/Requests");
            //<-//
            request.IsDelete = true;
            _request.EditRequest(request);
        }

        public void AcceptRequest(SchoolRequest request)
        {
            if (request == null) return;

            request.IsAccept = true;
            _request.EditRequest(request);
        }
    }
}