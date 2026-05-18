using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.RightSidebarComponentPartial
{
    public class _RightSidebarMessageComponentPartial :ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarMessageComponentPartial(StoreContext context)//DI ile StoreContext nesnesini alıyoruz
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Messages.Where(x=>x.IsRead==false).ToList();//Messages tablosundaki okunmamış mesajları alıyoruz
            return View(values);
        }
    }
}
