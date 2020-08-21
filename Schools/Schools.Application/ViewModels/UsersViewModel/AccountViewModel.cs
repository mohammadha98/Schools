using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Application.ViewModels.UsersViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
    }

    public class RegisterStip2ViewModel
    {
        public int UserId { get; set; }
        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ActiveCode { get; set; }
    }

    public class RegisterStip3ViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        //[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string UserName { get; set; }
        public int RoleId { get; set; }

        //public List<int>UserRoles { get; set; }
    }
}
