using LibraryMgmt.WebApp.MVC.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMgmt.WebApp.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<IActionResult> Index()
        {
            if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Cookies["jwtToken"]))
            {
                return View();
            }
            else
            {
                return View("AccessDenied");
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwtToken");
            Response.Cookies.Delete("MyCookieAuth");
            return RedirectToAction("Login", "Account");
        }
    }
}
