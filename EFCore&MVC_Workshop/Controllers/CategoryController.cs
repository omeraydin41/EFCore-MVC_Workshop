using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreContext _context;

        public CategoryController(StoreContext context)//DI UYGULAMAK ADINA CTOR EKLENDİ
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();//ToList() ile cATEGORİES tablsundaki verileri liste halınde aldık 
            return View(values);
        }

        //yenı kategori ekleme işlemi
        [HttpGet]// get isteği ile çalışacak bir aksiyon metodu olduğunu belirtir // sayfa ilk açıldığında boş bir formun gelmesini sağlar
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)//CreateCategory adı Categoryist ana viewinde buton linki olarak verilmişti
        {
            category.CategoryStatus = false;
            _context.Categories.Add(category);//veri tabanına ekleme işlemi
            _context.SaveChanges();//değişiklikleri kaydetme işlemi
            return RedirectToAction("CategoryList");//ekleme işlemi tamamlandıktan sonra kategori listesine yönlendirme işlemi
        }

        //silme işlemi attribute yerine link alır 
        //silme işlemi ID ye göre yapılır

        //ID BULUNMALI - 
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);//veri tabanında id ye göre arama işlemi
            _context.Categories.Remove(value);//veri tabanından silme işlemi
            _context.SaveChanges();//değişiklikleri kaydetme işlemi
            return RedirectToAction("CategoryList");//silme işlemi tamamlandıktan sonra kategori listesine yönlendirme işlemi
        }



        [HttpGet]//guncelleme işlemi ıs değeri uzerinden yapılır
        public IActionResult UpdateCategory(int id)
        {
            //guncellenecek olan veri sayfaya taşınır
            var value = _context.Categories.Find(id);//veri tabanında id ye göre arama işlemi
            return View(value);//guncellenecek olan veri sayfaya taşınır
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);//guncelleme işlemi
            _context.SaveChanges();//değişiklikleri kaydetme işlemi
            return RedirectToAction("CategoryList");//guncelleme işlemi tamamlandıktan sonra kategori listesine yönlendirme işlemi
        }
    }
}
