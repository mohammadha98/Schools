using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Application.ViewModels.UsersViewModel
{
    public class EditPasswordViewModel
    {
        

        [Display(Name ="رمز عبور فعلی")]
        [Required(ErrorMessage ="لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        public string CurentPassword { get; set; }

        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(50)]

        [Compare("NewPassword", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string ReNewPassword { get; set; }
    }
}
