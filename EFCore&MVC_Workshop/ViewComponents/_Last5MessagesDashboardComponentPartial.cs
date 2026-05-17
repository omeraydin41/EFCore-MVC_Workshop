using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _Last5MessagesDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _Last5MessagesDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        /*Skıplast : koleeksıyoun sı-onundakı n tane elemanı atlar ver geri kalanı getirir.
        Take last : koleksıyoun sonundakı n tane elelamnı alır ve baştakılerı yok sayar.
        */

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages
                .OrderBy(x => x.MessageId)
                .ToList()
                .TakeLast(5)
                .ToList();
            return View(values);
        }
    }
}
