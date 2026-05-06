using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
