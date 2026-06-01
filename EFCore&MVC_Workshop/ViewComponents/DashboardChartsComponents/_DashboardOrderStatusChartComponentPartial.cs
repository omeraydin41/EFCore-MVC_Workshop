using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.DashboardChartsComponents
{
    public class _DashboardOrderStatusChartComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _DashboardOrderStatusChartComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {//CTRL + BOŞLUK : ONERME AÇAR
            var result = _context.Orders
                .GroupBy(o => o.Status)
                .Select(g => new Models.OrderStatusChartViewModel
                {
                    Status = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToList();
            return View(result);
        }
    }
}
