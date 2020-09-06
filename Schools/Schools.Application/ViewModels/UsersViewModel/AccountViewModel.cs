using Schools.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Application.ViewModels.UsersViewModel
{
    #region Register
    public class RegisterViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "شماره تلفن نا معتبر است")]
        [MinLength(11, ErrorMessage = "شماره تلفن نا معتبر است")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [MinLength(5, ErrorMessage = "نام کاربری کوتاه است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "کلمه عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 6 کاراکتر باشد")]
        [MaxLength(30, ErrorMessage = "کلمه عبور باید کمتر از30 کاراکتر باشد")]
        public string Password { get; set; }
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
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
    #endregion

    public class ChangePasswordModel
    {
        public int UserId { get; set; }

        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        [MinLength(6, ErrorMessage = "رمز عبور باید بیشتر از 6 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        [Compare("Password", ErrorMessage = "کلمه های عبور یکسان نیستند")]
        public string RePassword { get; set; }
    }
    #region Login
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر به سپار")]
        public bool RememberMe { get; set; }
    }
    #endregion
}