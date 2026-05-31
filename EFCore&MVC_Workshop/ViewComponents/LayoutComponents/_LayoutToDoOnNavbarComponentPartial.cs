using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.LayoutComponents
{
    public class _LayoutToDoOnNavbarComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _LayoutToDoOnNavbarComponentPartial(StoreContext context)//DI içinn uretıldı
        {
            _context = context;
        }
        public IViewComponentResult Invoke()//burda usttekı bildirim panelinden yapılacaklar lıstesındekı 5 değer alınıp Layoutta kullanılacak 
        {
            var values =_context.ToDos.Where(y=>y.Status==false).OrderByDescending(x=>x.ToDoId).Take(5).ToList();
            ViewBag.todoToatalCount = _context.ToDos.Count();
            return View(values);
        }
    }
}
