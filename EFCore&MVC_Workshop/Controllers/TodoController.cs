using EFCore_MVC_Workshop.Context;
using EFCore_MVC_Workshop.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EFCore_MVC_Workshop.Controllers
{
    public class TodoController : Controller
    {
        private readonly StoreContext _contex;

        public TodoController(StoreContext contex)//DI ile StoreContext nesnesini alır ve _contex_ alanına atar
        {
            _contex = contex;
        }

        public IActionResult Index()
        {           
            return View();
        }


        //Addrange  :birden fazla datayıaynı anda db ye eklemeye yarar.tek tek add kullanmak yerıne bır koleksiyonu topluca eklemeye yarar.
        [HttpGet]
        public async Task<ActionResult> CreateToDo()
        {
            var todos = new List<ToDo>
            {
             new ToDo{ Description="Mail Gönder",Status=true,Priority="Birincil"},
             new ToDo{ Description="Rapor Hazırla",Status=true,Priority="İkincil"},
             new ToDo{ Description="Toplantıya Katıl",Status=true,Priority="Üçüncül"}
            };
            await _contex.ToDos.AddRangeAsync(todos);
            await _contex.SaveChangesAsync();
            return View();
        }


        ////////////////////
        //Aggregate :# LİNQ da kullanılan bir koleksşyounun elemanlarını belirli bir kurala gore tek bir sonuca indirgemeye yarar.
        //Bir koleksiyondakı değerleri sırayla işleyerek bir oncekının sonucunu diğerine birleştirerek tekbir sounç elde eder.

        public IActionResult TodoAggregatePriority()
        {
            var priorityFirstlyTodo = _contex.ToDos
                .Where(x => x.Priority == "Birincil") // Önceliği birincil olanları seç
                .Select(y => y.Description)           // Sadece Description alanını al
                .ToList();                            // Sonuçları bir listeye dönüştür

            // Liste olarak View'a gönderiyoruz
            ViewBag.results = priorityFirstlyTodo;
            return View();
        }
    }
}
