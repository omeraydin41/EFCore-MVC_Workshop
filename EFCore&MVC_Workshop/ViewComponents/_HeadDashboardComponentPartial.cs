using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _HeadDashboardComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke() 
        {  
            return View(); 

        }
    }
}
