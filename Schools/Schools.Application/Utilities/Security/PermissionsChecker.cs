using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Schools.Domain.Repository.InterfaceRepository.Users;

namespace Schools.Application.Utilities.Security
{

    public class PermissionsChecker : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserRoleRepository _roleService;
        private int _permissionId;

        public PermissionsChecker(int permissionId)
        {
            _permissionId = permissionId;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _roleService = (IUserRoleRepository)context.HttpContext.RequestServices.GetService(typeof(IUserRoleRepository));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                int userId = context.HttpContext.User.GetUserId();
                //اگر کاربر مجوز ورود به بخش مورد نظر را نداشت به آدرس زیر منتقل میشه
                if (!_roleService.CheckPermission(userId, _permissionId))
                {
                    context.Result = new RedirectResult("/Unauthorized");
                }
            }
            else
            {
                //اگر کاربر لاگین نباشه واررد آدرس زیر میشه
                context.Result = new RedirectResult("/Auth/Login?ReturnTo=" + context.HttpContext.Request.Path, false);
            }
        }
    }
}
