using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MVC_Workshop.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)//DI için gereklı 
        {
            _context = context;
        }

        public IActionResult AllStockSmollerThan5()
        {
            //ALL METHODU : EF TUM ŞARTLARI SAĞLAYAN DEĞERLERİ GETİRİR
            bool orderStockCount = _context.Orders.All(x => x.OrderCount <= 5);//TÜM STOK SAYILARI 5 TEN KÜÇÜK OLDUĞUNDAN TRUE 
                                                                                        //AMA 1 TANE BİLE UYGUN OLMASAYDI FALSE GELECEKTİ
            if (orderStockCount==true) 
            {
                ViewBag.V = "tüm siparişler 5 adetten küçüktür";
            }
            else
            {
                ViewBag.V = "tüm siparişler 5 adetten küçük değildir";

            }
            return View();
        }

        // CONTAİN METHODU : İÇEREN KISIMLARI GETİRİR . SQL-LİKE : İÇİNDE A OLANLARI TAMAMYLA GETİRİR STATUS SORGULAMADA
        public IActionResult OrderListByStatus(string status)//Status durumunu yazıp ona gore liste yapan method
        {
            var values = _context.Orders.Where(x=>x.Status.Contains(status)).ToList();
            if (!values.Any())//valuenin içi boşsa
            {
                ViewBag.V = "bu statuse uygun veri bulunamadı";
            }
            return View(values);
        }


        //StartsWith - AndsWith
        public IActionResult OrderListSearch(string name,string filterType)
        {
            if (filterType=="start") // birşeyle başlayan 
            {
                var values = _context.Orders.Where(x=>x.Status.StartsWith(name)).ToList();
                return View(values);
            }
            else if (filterType=="end")//birşeyle biten
            {
                var values = _context.Orders.Where(x => x.Status.EndsWith(name)).ToList();
                return View(values);
            }
            var orderValues=_context.Orders.ToList();
            return View(orderValues);
        }

        public async Task<IActionResult> OrderLiasAsync()
        {
            var values=await _context.Orders
                .Include(x=>x.Product)
                .Include(y=> y.Customer)
                .ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> OrderListAsync2()
        {
            var values =await  _context.Orders
               .Include(x => x.Product)
               .Include(y => y.Customer)
               .ToListAsync();
            return View(values);
        }
    }
}
