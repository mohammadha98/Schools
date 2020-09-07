using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Domain.Models.ContactUs
{
    public class ContactUsForm
    {
        [Key]
        public int ContactId { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} خود را وارد کنید")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800)]
        public string Description { get; set; }

        [Display(Name ="وضعیت")]
        public bool IsPosted { get; set; }
        public bool IsDelete { get; set; }
    }
}
