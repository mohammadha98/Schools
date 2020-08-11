using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Schools.Domain.Models.Schools;

namespace Schools.Application.ViewModels.SchoolsViewModels
{
    public class GetAllSchoolForAdmin
    {
        public List<School> Schools { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int ShireId { get; set; }
        public int CityId { get; set; }
        public int AreaId { get; set; }
        public string SchoolName { get; set; }
        public int GroupId { get; set; }
        public int ParentId { get; set; }


    }

    public class AddSchoolViewModel
    {
        [Display(Name = "Meta Description")]
        [Required(ErrorMessage = "لطفا متا دیسکریپشن را وارد کنید")]
        public string MetaDescription { get; set; }

        [Display(Name = "نام آموزشگاه")]
        [Required(ErrorMessage = "نام آموزشگاه را وارد کنید")]
        public string SchoolTitle { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = " کلمات کلیدی را وارد کنید")]
        public string Tags { get; set; }

        [Display(Name = "توضیح درمورد آموزشگاه")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "شماره تلفن آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolPhone { get; set; }

        [Display(Name = "ایمیل آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolEmail { get; set; }

        [Display(Name = " فکس آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolFax { get; set; }

        [Display(Name = " آدرس آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolAddress { get; set; }

        [Required] public bool IsActive { get; set; }

        [Required(ErrorMessage = "مدیر آموزشگاه را مشخص کنید")]
        public int SchoolManager { get; set; }

        [Required(ErrorMessage = "گروه آموزشگاه را مشحص کنید")]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }

        [Required(ErrorMessage = "استان آموزشگاه را مشحص کنید")]
        public int ShireId { get; set; }

        [Required(ErrorMessage = "استان آموزشگاه را مشحص کنید")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "تاریخ تاسیس آموزشگاه را مشحص کنید")]
        public string BuildDate { get; set; }
        [Required(ErrorMessage = "نوع آموزش را مشحص کنید")]
        public List<int> TrainingTypes { get; set; }

        [Required(ErrorMessage = "گالری عکس را وارد کنید")]
        public List<IFormFile> Gallery { get; set; }

        [Required(ErrorMessage = "عکس اصلی آموزشگاه را انتخاب کنید")]
        public IFormFile Avatar { get; set; }
    }
    public class EditSchoolViewModel
    {
        public string ImageName { get; set; }
        [Required]
        public int SchoolId { get; set; }
        [Display(Name = "Meta Description")]
        [Required(ErrorMessage = "لطفا متا دیسکریپشن را وارد کنید")]
        public string MetaDescription { get; set; }

        [Display(Name = "نام آموزشگاه")]
        [Required(ErrorMessage = "نام آموزشگاه را وارد کنید")]
        public string SchoolTitle { get; set; }

        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = " کلمات کلیدی را وارد کنید")]
        public string Tags { get; set; }

        [Display(Name = "توضیح درمورد آموزشگاه")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "شماره تلفن آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolPhone { get; set; }

        [Display(Name = "ایمیل آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolEmail { get; set; }

        [Display(Name = " فکس آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolFax { get; set; }

        [Display(Name = " آدرس آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string SchoolAddress { get; set; }

        [Required] public bool IsActive { get; set; }

        [Required(ErrorMessage = "مدیر آموزشگاه را مشخص کنید")]
        public int SchoolManager { get; set; }

        [Required(ErrorMessage = "گروه آموزشگاه را مشحص کنید")]
        public int GroupId { get; set; }

        public int? SubGroupId { get; set; }

        [Required(ErrorMessage = "استان آموزشگاه را مشحص کنید")]
        public int ShireId { get; set; }

        [Required(ErrorMessage = "استان آموزشگاه را مشحص کنید")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "تاریخ تاسیس آموزشگاه را مشحص کنید")]
        public string BuildDate { get; set; }

        public List<int> TrainingTypes { get; set; }

        public List<IFormFile> Gallery { get; set; }

        public IFormFile Avatar { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}