using System.Collections.Generic;

namespace Schools.Application.ViewModels
{
    public class AddRoleViewModel
    {
        public string RoleTitle { get; set; }
        public List<int> Permissions { get; set; }

    }
}