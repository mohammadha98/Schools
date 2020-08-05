using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schools.Domain.Models.Users
{
   public class UserRole
    {
        public UserRole()
        {

        }
        [Key]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }


        #region Relations

        public virtual Users User { get; set; }
        public virtual Role Role { get; set; }

        #endregion
    }
}
