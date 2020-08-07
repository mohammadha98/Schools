using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Domain.Models.Users
{
   public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool IsDelete { get; set; }


        #region Relations

        public  User User { get; set; }
        public  Role Role { get; set; }

        #endregion
    }
}
