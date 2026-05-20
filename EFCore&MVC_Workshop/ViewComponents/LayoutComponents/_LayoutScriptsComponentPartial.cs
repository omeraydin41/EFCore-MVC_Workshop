using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.LayoutComponents
{
    public class _LayoutScriptsComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
