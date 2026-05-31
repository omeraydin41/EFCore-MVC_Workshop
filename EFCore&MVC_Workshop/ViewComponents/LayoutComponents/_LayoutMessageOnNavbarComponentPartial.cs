using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.LayoutComponents
{
    public class _LayoutMessageOnNavbarComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutMessageOnNavbarComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages
                .Where(y=>y.IsRead==false)
                .OrderByDescending(x => x.MessageId)
                .Take(3)
                .ToList();

            ViewBag.messageCount = _context.Messages.Where(y => y.IsRead == false).Count();//okunmayan mesajların sayısını getirecek.
            return View(values);
        }
    }
}
