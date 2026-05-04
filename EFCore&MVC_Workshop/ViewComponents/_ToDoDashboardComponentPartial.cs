using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _ToDoDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _ToDoDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
          var values =_context.ToDos.OrderByDescending(x=>x.ToDoId).Take(6).ToList();//Z den A ya sırala / liste olarak ver
            return View(values);
        }
    }
}
