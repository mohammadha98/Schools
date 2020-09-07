﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Schools.Domain.Models.Users.Permissions;

namespace Schools.Domain.Models.Users
{
   public class Role
    {
        
        [Key]
        public int RoleId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string RoleTitle { get; set; }

        public bool IsDelete { get; set; }

        #region Relations

        public  List<UserRole> UserRoles { get; set; }
        public  List<RolePermission> RolePermissions { get; set; }
       
        #endregion

    }
}
