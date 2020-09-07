using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Schools.Application.Service.Interfaces.Schools;
using Schools.Application.Utilities;
using Schools.Application.Utilities.Security;
using Schools.Application.ViewModels.UsersViewModel;

namespace Schools.WebApp.Pages.UserPanel.RegisterSchool
{
    //2 =  دانشجو
    [PermissionsChecker(2)]
    public class IndexModel : PageModel
    {
        private ISchoolRequestService _request;

        public IndexModel(ISchoolRequestService request)
        {
            _request = request;
        }
        [BindProperty]
        public RegisterSchoolViewModel RegisterModel { get; set; }
        public void OnGet()
        {
            var request = _request.GetSchoolRequestByUserId(User.GetUserId());
            if (request != null)
            {
                TempData["RequestExist"] = true;
                Response.Redirect("/UserPanel");
            }
        }

        public IActionResult OnPost(string[] types)
        {

            if (types != null && types.Length >=1)
            {
                RegisterModel.TrainingTypes = types;
            }
            else
            {
                ModelState.AddModelError("TrainingTypes","نوع آموزش را مشخس کنید");
                return Page();

            }
            RegisterModel.UserId = User.GetUserId();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (!RegisterModel.IsAcceptRole)
            {
                ModelState.AddModelError("IsAcceptRole", "برای ثبت اموزشگاه باید قوانین را بپذیرید");
                RegisterModel.TrainingTypes = types;
                return Page();
            }
            var result = _request.AddRequest(RegisterModel);
            if (result == false)
            {
                ModelState.AddModelError("ImagesName", "اطلاعات وارد شده نا معتبر است");
                return Page();
            }
            TempData["RegisterSuccess"] = true;
            return Redirect("/UserPanel");
        }
    }
}
