using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents
{
    public class _CardStatisticDashboardComponentPartial :ViewComponent
    {
        private readonly StoreContext _context;//DI ya uygun olarak Bağlantı addresını tutan StoreContext classından nesne aldık db ile bağlantı için.

        public _CardStatisticDashboardComponentPartial(StoreContext storeContext)// CTRL . ile constructor alındı 
        {
            this._context = storeContext;
        }

        public IViewComponentResult Invoke()
        {
            //COUNT 
            ViewBag.totalCustomerCount  = _context.Customers.Count(); //Customer tablosu toplam satır sayısı 
            ViewBag.totalCategoryCount  =_context.Categories.Count(); //Categories tablosu satır sayısını verir
            ViewBag.totalProductCount   =_context.Products.Count();   //Product tablosu toplam satır sayısı 
            //ViewBag : Backend tarfından UI tarafına veri taşınmasını sağlar . veri tekıl değil liste halındede olabılır.
            //count : tablodaki  veri sayısını getiren EF methodudur

            //AVG : sütün ortalaması veriri
            ViewBag.avgCustomerBalance = _context.Customers.Average(x => x.Balance).ToString("N2") + " TL";
            //Customers tablosu Balance(bakiye) alnının(sütun) ortalamsını verir ve , den sonra son ıkı basamağı sadece verir.
            //x=>x : LAMBDA anonim fonksion tanımlama .fonksiyon tanımlama ona isim verip çağırmak yerine Lambda ise bu süreci kısaltır.


            ViewBag.totalOrderCount=_context.Orders.Count();

            //SUM : toplam verir .lamda kullanımında eğer çoklu satırlar arası işlem varsa adsız fonksiyon olarak kullanılır.
            ViewBag.sumOrderProductCount = _context.Orders.Sum(x => x.OrderCount);
            return View();
        }
    }
}
