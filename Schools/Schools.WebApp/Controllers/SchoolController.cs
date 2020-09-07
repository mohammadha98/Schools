using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schools.Application.Service.Interfaces.Locations;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Service.Interfaces.Schools.Teacher;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Convertors;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Models.Users;
using Schools.Domain.Repository.InterfaceRepository.Schools;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.WebApp.Controllers
{
    public class SchoolController : Controller
    {
        private ISchoolService _school;
        private ILocationService _locationService;
        private ISchoolCommentService _comment;
        private IUserLikeRepository _like;
        private ISchoolRateRepository _rate;
        private ITeacherRateRepository _teacherRate;
        private ISchoolTeacherRepository _teacher;

        public SchoolController(ISchoolService school, ILocationService locationService, ISchoolCommentService comment, IUserLikeRepository like, ISchoolRateRepository rate, ITeacherRateRepository teacherRate, ISchoolTeacherRepository teacher)
        {
            _school = school;
            _locationService = locationService;
            _comment = comment;
            _like = like;
            _rate = rate;
            _teacherRate = teacherRate;
            _teacher = teacher;
        }

        [Route("/School/{schoolId}/{schoolTitle}")]
        public IActionResult SinglePage(int schoolId, string schoolTitle)
        {
            var school = _school.GetSchoolById(schoolId);
            if (school == null || school.IsActive==false)
            {
                return NotFound();
            }
            //Khili shooloogh shode vali Hosele nadaram ViewModel Besazam :D
            ViewData["Shires"] = _locationService.GetAllShire();
            ViewData["Cities"] = _locationService.GetAllCityByShireId(school.ShireId);
            ViewData["SimilarSchools"] = _school.GetSimilarSchools(school.GroupId);
            //پر کردن اولیه بخش نظرات
            ViewData["Comments"] = _comment.GetSchoolComments(1, 7, schoolId);
            ViewData["IsUserLikeSchool"] = false;
            if (User.Identity.IsAuthenticated)
            {
                ViewData["IsUserLikeSchool"] = _like.IsUserLikeSchool(User.GetUserId(), schoolId);
            }
            _school.AddVisitForSchool(school);
            return View(school);
        }
        [Route("/Schools")]
        public IActionResult SchoolCategory(int page = 1, string shireTitle = "", string cityTitle = "", string categoryTitle = "", string schoolName = "", string courseName = "", string teacherName = "", string orderBy = "all")
        {
            var model = _school.GetSchoolsForCategory(page, 20, shireTitle, cityTitle, categoryTitle, schoolName,
                courseName, teacherName, orderBy);
            if (!string.IsNullOrEmpty(shireTitle))
            {
                model.Cities = _locationService.GetAllCityByShireTitle(shireTitle);
            }
            return View("SchoolsCategory", model);
        }
        [Route("/GetComments/{pageId}/{schoolId}")]
        public IActionResult GetSchoolComments(int pageId, int schoolId)
        {
            var school = _comment.GetSchoolComments(pageId, 7, schoolId);
            if (school == null)
            {
                return NotFound();
            }
            return PartialView("School/_SchoolComments", school);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddComment(SchoolComment comment)
        {

            comment.UserId = User.GetUserId();
            if (string.IsNullOrEmpty(comment.Text))
            {
                return Content("Error");
            }
            var resultComment = _comment.AddComment(comment);
            var userName = $"{resultComment.User.Name} {resultComment.User.Family}";
            var res = $"<div class='comment-box'><div class='img-layer'><img src='/images/userAvatars/{resultComment.User.UserAvatar}'/></div><div class='left'><span>{userName}</span><i>ارسال شده در {resultComment.CreateDate.ToShamsi()}</i><p>{comment.Text}</p></div></div>";
            //اگر این نظر یک پاسخ برای یک نظر دیگه باشد وارد شرط میشه و بعد سمت کلاینت صفحه را رفرش میکنیم
            if (comment.Answer != null)
            {
                return Content("Success");
            }
            return Content(res);
        }
        [Authorize]
        public IActionResult DeleteComment(int commentId, int schoolId)
        {

            var comment = _comment.GetSchoolCommentById(commentId);
            if (comment != null)
            {
                if (comment.SchoolId == schoolId)
                {
                    if (comment.UserId == User.GetUserId())
                    {
                        _comment.DeleteComment(comment);
                        return Content("Deleted");
                    }
                }

            }
            return Content("Error");

        }
        [Authorize]
        public IActionResult TeacherRating(int schoolId, float rate, int teacherId)
        {
            var teacher = _teacher.GetTeacherById(teacherId);

            if (teacher == null) return NotFound();
            if (teacher.SchoolId != schoolId)
                return NotFound();

            var rateModel = _teacherRate.GetTeacherRate(User.GetUserId(), teacherId);
            if (rateModel != null)
            {
                return BadRequest("Error");
            }
            var newRate = new TeacherRate()
            {
                IsDelete = false,
                Rate = rate,
                TeacherId = teacherId,
                UserId = User.GetUserId()
            };
            _teacherRate.AddRateForTeacher(newRate);
            return Content("Success");

        }
        [Authorize]
        public IActionResult Rating(int schoolId, float rate)
        {
            var rateModel = _rate.GetSchoolRate(User.GetUserId(), schoolId);
            if (rateModel != null)
            {
                return BadRequest("Error");
            }
            var newRate = new SchoolRate()
            {
                IsDelete = false,
                Rate = rate,
                SchoolId = schoolId,
                UserId = User.GetUserId()
            };
            _rate.AddRate(newRate);
            return Content("Success");
        }
        [Authorize]
        public IActionResult LikeSchool(int schoolId)
        {

            //اگر نال نباشه یعنی باید حذفش کنیم
            var like = _like.GetUserLike(schoolId, User.GetUserId());
            if (like != null)
            {
                like.IsDelete = true;
                _like.EditUserLike(like);
                return Content("Removed");
            }

            var userLike = new UserLike()
            {
                IsDelete = false,
                SchoolId = schoolId,
                UserId = User.GetUserId()
            };
            _like.AddUserLike(userLike);
            return Content("Added");
        }

    }

}