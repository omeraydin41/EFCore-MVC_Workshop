using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MVC_Workshop.Controllers
{
    public class MessageController : Controller
    {
        private readonly StoreContext _context;

        public MessageController(StoreContext context)//DI için gerekli
        {
            _context = context;
        }

        /*Sadece veri okunup guncelleme yağpılmayacaksa bu işlem bosşuna kaynak tuketir
        Burda as no trackink kullanılır 
        Ef gelen nesleri izlemesinı sağlar  : yanı veri Listelenecek ama db de değişiklik olmayacağından takıp edilmesıne gerek yok 
        Bellek kullanımı duser performans artar 
        Readonly için kullanılır.
        */
        public IActionResult MessageList()
        {
            var values = _context.Messages.AsNoTracking().ToList();
            return View(values);
        }




    }
}
