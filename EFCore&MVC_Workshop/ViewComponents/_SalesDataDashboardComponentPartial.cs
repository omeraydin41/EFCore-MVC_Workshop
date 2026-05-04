using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _SalesDataDashboardComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _SalesDataDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            //_context.Orders.ToList(); tum tabloyu lısteler
            var values =_context.Orders
                .Include(x=>x.Customer)//orders tablosu ile customer tablosu INCULDE ile birlestırılır
                .Include(y=>y.Product) //orders tablosu ile product tablosu INCULDE ile birlestırılır
                .OrderByDescending(z=>z.OrderId)//orders tablosunu OrderId'ye göre büyükten küçüğe sıralar
                .Take(5)//ilk 5 kaydı getirecek 
                .ToList();
            return View(values);

            //Include : bızım yerımıze DB JOIN İŞLEMI YAPAR ve
            //Order tablosundakı CustomerId ile Customer tablosundakı Id'yi eslestırır ve
            //o eslesmeye gore Customer tablosundakı verileri Order tablosuna ekler
        }
    }
}
