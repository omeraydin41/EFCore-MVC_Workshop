using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _DailySalesDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _DailySalesDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data =_context.ToDos
                .GroupBy(x => x.Priority)
                .Select(x => new ToDoStatusChartViewModel
                {
                    Status = x.Key,
                    Count = x.Count()
                }).ToList();
            return View(data);
        }
    }
}
