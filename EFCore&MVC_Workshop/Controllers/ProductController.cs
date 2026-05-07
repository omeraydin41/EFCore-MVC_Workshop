using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context)//DI İÇİN 
        {
            _context = context;
        }

        public IActionResult ProductList()
        {
            var values=_context.Products.ToList();//product tablosunu liste olarak aldık.
            return View(values);
        }


        #region 
        //ÜRÜN EKLEME 
        [HttpGet]//sayfayı getirecek method 
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]//değişikliği yapacak olan method 
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("ProductList");//ProductList methodunun viewine (bu controllerdeki ana sayfamız)
        }
        #endregion

        //silme işlemi : id üzerinden yapılır 
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ProductList");
        }



        #region
        //ÜRÜN GÜNCELLEME
        [HttpGet] //sayfayı getirecek olan method
        public IActionResult UpdateProduct(int id)
        {
            var value= _context.Products.Find(id);//güncellenecek olan ürünü id üzerinden bulduk
            return View(value);//güncellenecek olan ürünü sayfaya taşıdık
        }
        [HttpPost]//değişikliği yapacak olan method
        public IActionResult UpdateProduct(Product product)
        {
            _context.Products.Update(product);//güncelleme işlemi
            _context.SaveChanges();
            return RedirectToAction("ProductList");//güncelleme işlemi tamamlandıktan sonra ürün listesine yönlendirme işlemi
        }


        #endregion
    }
}
