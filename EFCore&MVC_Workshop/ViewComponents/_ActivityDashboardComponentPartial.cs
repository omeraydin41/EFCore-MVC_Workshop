using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _ActivityDashboardComponentPartial : ViewComponent
    {
        private readonly StoreContext _context;

        public _ActivityDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            //tolist : hazırlanan bir sorgunun veritabanında çalıştırılmasını ve sonuçların belleğe (RAM) bir liste olarak aktarılmasını sağlar.
            var values = _context.Activities.ToList();//tablonun tum verilerin çağırıyoruz ve values a atıyoruz
            return View(values);
    
         
        }
    }
}
