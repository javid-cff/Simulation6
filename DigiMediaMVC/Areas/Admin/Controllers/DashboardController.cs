using Microsoft.AspNetCore.Mvc;

namespace DigiMediaMVC.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
