using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    // Bu satır, sistemdeki tüm harf/alt çizgi karmaşasını çözer ve klasörle eşleştirir:
    [ViewComponent(Name = "_FooterDashboardComponentPartial")]
    public class _FooterDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}