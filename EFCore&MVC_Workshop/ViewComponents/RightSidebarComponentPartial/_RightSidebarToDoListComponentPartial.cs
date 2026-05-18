using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.ViewComponents.RightSidebarComponentPartial
{
    public class _RightSidebarToDoListComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;

        public _RightSidebarToDoListComponentPartial(StoreContext context)//DI ile StoreContext nesnesini alıyoruz
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.ToDos
                .OrderByDescending(x=>x.ToDoId)
                .ToList()//ToDos tablosundaki verileri ToDoId'ye göre sıralıyoruz
                .Take(10)//ToDos tablosundaki verileri ToDoId'ye göre sıralayıp son 10 kaydı alıyoruz
                .ToList();
            return View(values);
        }
    }
}
