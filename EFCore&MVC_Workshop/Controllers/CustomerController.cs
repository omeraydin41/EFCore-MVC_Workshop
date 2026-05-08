using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)//DI UYGULAMAK ADINA CTOR EKLENDİ
        {
            _context = context;
        }

        // A-Z ye sıralama yapar 
        public IActionResult CustomerListOrderByCustomerName()//OrderBy kullanıllarak müşteri adına göre sıralama işlemi yapılır
        {
            var values = _context.Customers.OrderBy(x=>x.CustomerName).ToList();
            return View(values);
        }

        //Z-A  ya sıralama yapar
        public IActionResult CustomerListOrderByDescBalance()
        {
            var values = _context.Customers.OrderByDescending(x => x.Balance).ToList();
            return View(values);
        }

        #region

        //any kullanımı :
        public IActionResult CustomerGetByCity(string city)
        {
            var exist = _context.Customers.Any(x=>x.CustomerCity==city);
            if (exist)
            {
                ViewBag.message = $"{city} şehrinde en az bir tane müşteri vardır.";
            }
            else
            {
                ViewBag.message = $"{city} şehrinde hiç müşteri yok.";

            }
            return View();
        }

       //yenı Müşteri ekleme işlemi
       [HttpGet]// get isteği ile çalışacak bir aksiyon metodu olduğunu belirtir // sayfa ilk açıldığında boş bir formun gelmesini sağlar
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)//CreateCustomer adı Customerist ana viewinde buton linki olarak verilmişti
        {
           
            _context.Customers.Add(customer);//veri tabanına ekleme işlemi
            _context.SaveChanges();//değişiklikleri kaydetme işlemi
            return RedirectToAction("CustomerList");//ekleme işlemi tamamlandıktan sonra kategori listesine yönlendirme işlemi
        }
        #endregion




        //silme işlemi attribute yerine link alır 
        //silme işlemi ID ye göre yapılır

        //ID BULUNMALI - 
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id);//veri tabanında id ye göre arama işlemi
            _context.Customers.Remove(value);//veri tabanından silme işlemi
            _context.SaveChanges();//değişiklikleri kaydetme işlemi
            return RedirectToAction("CustomerList");//silme işlemi tamamlandıktan sonra kategori listesine yönlendirme işlemi
        }



        [HttpGet]//guncelleme işlemi ıs değeri uzerinden yapılır
        public IActionResult UpdateCustomer(int id)
        {
            //guncellenecek olan veri sayfaya taşınır
            var value = _context.Customers.Find(id);//veri tabanında id ye göre arama işlemi
            return View(value);//guncellenecek olan veri sayfaya taşınır
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);//guncelleme işlemi
            _context.SaveChanges();//değişiklikleri kaydetme işlemi
            return RedirectToAction("CustomerList");//guncelleme işlemi tamamlandıktan sonra kategori listesine yönlendirme işlemi
        }
    }
}
