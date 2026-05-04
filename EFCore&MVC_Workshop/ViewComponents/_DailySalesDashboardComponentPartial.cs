using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _DailySalesDashboardComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
