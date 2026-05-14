using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Entities;
using EFCore_MVC_Workshop.Models;
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
            var values = _context.Customers.OrderBy(x => x.CustomerName).ToList();
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
            var exist = _context.Customers.Any(x => x.CustomerCity == city);
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

        public IActionResult CustomerrListByCity()
        {
            var gruopedCustomers = _context.Customers
                .ToList()//önce liste haline getiriyoruz çünkü groupby yaparken sql e çevrilmeye çalışır ve hata verir bu yüzden önce liste haline getirip sonra groupby yapıyoruz
                .GroupBy(c => c.CustomerCity)//müşterileri şehirlerine göre gruplayarak sıralama işlemi yapılır
                .ToList();//gruplama işlemi yapıldıktan sonra tekrar liste haline getiriyoruz çünkü view de foreach ile dönmek istediğimizde liste olması gerekiyor
            return View(gruopedCustomers);
        }



        //LINQ :  farklı veri kaynaklarından (koleksiyonlar, veritabanları, XML dosyaları vb.) ortak, standart ve tip güvenli (strongly-typed) bir şekilde sorgulama yapmanı sağlayan güçlü bir C# özelliğidir.
        public IActionResult CustomerByCityCount()
        {
            //LINQ ile şehir adına göre guruplama yapıp her guruptak müşteri sayısını hesaplama işlemi yapılacak

            var query =
                from c in _context.Customers //işin içine from girerse LINQ olur . c uzerınden Customers tablosuna erişilir
                group c by c.CustomerCity into groupCity //groupCity geçici değişken olarak kullanılır ve c.CustomerCity ye göre gruplama işlemi yapılır
                select new CustomerCityGroup
                {
                   City = groupCity.Key, //gruplama işlemi yaparken kullandığımız şehir adına göre gruplama yapar ve o şehri City özelliğine atar .KEY gruplama işlemi yaparken kullandığımız değerdir(CustomerCity)
                   CustomerCount = groupCity.Count()//gruplama işlemi yaparken her guruptaki müşteri sayısını hesaplar ve CustomerCount özelliğine atar
                };
            var model = query.ToList();//sorgu sonucunu liste haline getiriyoruz çünkü view de foreach ile dönmek istediğimizde liste olması gerekiyor
            return View(model);
        }


        //DİSTİNCT : veri setınde bulunan ve tekrar eden verileri tekıl hale getirir .VERİLERİ TEKILLEŞTIRIR.
        public IActionResult CustomerCityList()
        {
            var values
                =_context.Customers.Select(x => x.CustomerCity)
                .Distinct()
                .ToList();//müşteri şehirlerini seçer ve tekrar eden şehirleri tekilleştirir ve liste haline getirir
            return View(values);
        }


        //ASPARALLEL : büyük veri setlerinde işlemi paralel olarak yaparak performansı artırır .VERİLERİ PARALLEL OLARAK İŞLEMEK İÇİN KULLANILIR. aynı anda veri işler çok çekirdek kullanır .
        public IActionResult ParallelCustomers()///A hafi ile başlayan müşterileri paralel olarak işleyerek listeleme işlemi yapılır
        {
            var customers = _context.Customers.ToList();
            var result = customers
                .AsParallel()//where şaru yazmak için once listeyı customers deişkenıne ordan asparallel yaparak paralel hale getiriyoruz. bu ramı daha  verimli kullanır.
                .Where(c => c.CustomerCity.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                .ToList();
            return View(result);
        }


        //EXCEPT METHODU: Bir koleksiyondadan başka koleksiyonda olan elemanları çıkarırı ve geriye kalanarı doner .
        public IActionResult CustomerListExceptCityİstabul()
        {
            var allCustomers = _context.Customers.ToList();
            var CustomerListInİstabul = _context.Customers
                .Where(x => x.CustomerCity == "İstanbul")
                .Select(c => c.CustomerCity)
                .ToList();
            var result = allCustomers
                .ExceptBy(CustomerListInİstabul,m=>m.CustomerCity)
                .ToList();

            return View(result);
        }
    }
}
