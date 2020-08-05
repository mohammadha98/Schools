using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Models.Schools.TrainingTypes;

namespace Schools.Domain.Models.Schools
{
    public class School
    {
        [Key]
        public int SchoolId { get; set; }
        //UserId = SchoolManager
        [Required]
        public int SchoolManager { get; set; }
        [Required]
        public int GroupId { get; set; }
        public int? SubGroupId { get; set; }
        public int ShireId { get; set; }
        public int CityId { get; set; }
        public int? AreaId { get; set; }
        [Display(Name = "نام آموزشگاه")]
        [Required(ErrorMessage = "نام آموزشگاه را وارد کنید")]
        public string SchoolTitle { get; set; }
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
        [Display(Name = " تاریخ ثبت نام آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime RegisterDate { get; set; }
        [Display(Name = " تاریخ تأسیس آموزشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime BuildDate { get; set; }
        public bool IsDelete { get; set; }


        #region Relations
        [ForeignKey("ShireId")]
        public Shire Shire { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        [ForeignKey("GroupId")]
        public SchoolGroup SchoolGroup { get; set; }

        [ForeignKey("SubGroupId")]
        public SchoolGroup SchoolSubGroup { get; set; }

        public List<SchoolGallery> SchoolGalleries { get; set; }

        public List<SchoolComment> SchoolComments { get; set; }

        public List<SchoolTeacher> SchoolTeachers { get; set; }

        public List<SchoolTrainingType> SchoolTrainingTypes { get; set; }
        public List<SchoolCourse> SchoolCourses { get; set; }
        public List<SchoolVisit> SchoolVisits { get; set; }
        #endregion
    }
}