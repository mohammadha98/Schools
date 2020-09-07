using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Users.Permissions
{
    public class RolePermission
    {
        [Key]
        public int RP_ID { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool IsDelete { get; set; }

        #region Relations

        public Role Role { get; set; }
        public Permission Permission { get; set; }
        #endregion
    }
}