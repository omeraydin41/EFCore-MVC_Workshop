using EFCore_MVC_Workshop.Context;
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
            var values= _context.Categories.ToList();//ToList() ile cATEGORİES tablsundaki verileri liste halınde aldık 
            return View(values);
        }
    }
}
