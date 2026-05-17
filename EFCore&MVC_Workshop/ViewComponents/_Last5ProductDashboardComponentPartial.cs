using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _Last5ProductDashboardComponentPartial :ViewComponent
    {
        public StoreContext _context;

        public _Last5ProductDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Products
                .OrderBy(p => p.ProductId)
                .ToList()
                .SkipLast(5)//5 tanesini atla 
                .ToList()
                .TakeLast(5)
                .ToList();
            return View(values);
        }


    }
}
