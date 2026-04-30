using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.Controllers
{
    public class DashboardController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
