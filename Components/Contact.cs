using Microsoft.AspNetCore.Mvc;

namespace LibraryMgmt.WebApp.MVC.Components
{
    public class Contact:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
