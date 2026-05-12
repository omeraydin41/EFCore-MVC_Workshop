using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        //public async Task<IActionResult> OrderLiasAsync()
        //{
        //    var values=await _context.Orders
        //        .Include(x=>x.Product)
        //        .Include(y=> y.Customer)
        //        .ToListAsync();
        //    return View(values);
        //}
        public async Task<IActionResult> OrderList() //asenkron  kullanımında async ve task kullanılır
        {
            var values =await  _context.Orders //işlem bitene kadar beklemesi için await kullanılır
               .Include(x => x.Product)
               .Include(y => y.Customer)
               .ToListAsync();
            return View(values);
        }
        /*METHOD ADLARININ SONUNDA ASYNC OLURSA ROUTİNG LE ÇAKIŞMAYA SEBEBP OLUR */




        #region Ekleme İşlemi
        // ekleme işlemi için get ve post methodları oluşturulmalı birisi sayfayı getirir diğeri işlemi yapar.
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var products =await _context.Products
                                     .Select(p => new SelectListItem
                                     { //burda 2 tane parametre alınmalı //gorulecek değer ve arka planda tutulacak değer

                                         Value = p.ProductId.ToString(),//arka planda tutulacak değer
                                         Text =  p.ProductName           //gorulecek değer
                                     }).ToListAsync();
            ViewBag.products = products;//viewbag ile sayfaya taşıdık


            var customers =await _context.Customers
                                     .Select(c => new SelectListItem
                                     { //burda 2 tane parametre alınmalı //gorulecek değer ve arka planda tutulacak değer

                                         Value = c.CustomerId.ToString(),                        //arka planda tutulacak değer
                                         Text = c.CustomerName  +" " + c.CustomerSurName         //gorulecek değer
                                     }).ToListAsync();
            ViewBag.customers = customers;//viewbag ile sayfaya taşıdık
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            order.Status = "Spariş alındı";
            order.OrderDate = DateTime.Now;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }
        #endregion


        //SİLME İŞLEMİ : VİEW YOK BUTONA LİNK ATAMASI YAPILACAK 
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var values=await _context.Orders.FindAsync(id);//değer bulundu
            _context.Orders.Remove(values); //değeri sil 
           await  _context.SaveChangesAsync();     // db ye kaydet
            return RedirectToAction("OrderList"); //sayfaya yınlendir
        }





        #region
        //UPDATE İŞLEMİ : HEM GET HEMDE POST İÇİN İKİ AYRI METHOD BİRİ SAYFAYI GETİRECEK DİĞERİ İŞLEMİ YAPACAK İSİMLERİ AYNI OLMALI.

        public async Task<IActionResult> UpdateOrder(int id)
        {
            var products = await _context.Products
                                    .Select(p => new SelectListItem
                                    { //burda 2 tane parametre alınmalı //gorulecek değer ve arka planda tutulacak değer

                                        Value = p.ProductId.ToString(),//arka planda tutulacak değer
                                        Text = p.ProductName           //gorulecek değer
                                    }).ToListAsync();
            ViewBag.products = products;//viewbag ile sayfaya taşıdık


            var customers = await _context.Customers
                                     .Select(c => new SelectListItem
                                     { //burda 2 tane parametre alınmalı //gorulecek değer ve arka planda tutulacak değer

                                         Value = c.CustomerId.ToString(),                        //arka planda tutulacak değer
                                         Text = c.CustomerName + " " + c.CustomerSurName         //gorulecek değer
                                     }).ToListAsync();
            ViewBag.customers = customers;//viewbag ile sayfaya taşıdık

            var value = await _context.Orders.FindAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("OrderList");
        }

        #endregion
    }
}
