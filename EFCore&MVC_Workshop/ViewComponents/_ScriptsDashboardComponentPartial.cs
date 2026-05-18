using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    // Bu satırı ekleyerek ismi kesin olarak kilitliyoruz:
    [ViewComponent(Name = "_ScriptsDashboardComponentPartial")]
    public class _ScriptsDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}