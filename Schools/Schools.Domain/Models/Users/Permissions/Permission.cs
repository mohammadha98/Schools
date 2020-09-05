using System.ComponentModel.DataAnnotations;

namespace Schools.Domain.Models.Users.Permissions
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }
        public int? Parent { get; set; }

    }
}