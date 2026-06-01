using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.DashboardChartsComponents
{
    public class _DashboardDateChartComponenetPartial: ViewComponent
    {
        private readonly StoreContext _context;
        public _DashboardDateChartComponenetPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Orders
                .GroupBy(o => o.OrderDate.Date)
                .Select(g => new
                {
                    RawDate = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.RawDate)
                .ToList()
                .Select(x => new OrderDateViewModel
                {
                    Date = x.RawDate.ToString("yyyy-MM-dd"),
                    Count = x.Count
                }).ToList();
            return View(data);
        }
    }
}
