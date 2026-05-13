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


        #region
        // APPENT KULLANIMI :Veritabanına yeni bir veri eklemek için kullanılır.
        // Örneğin, var olan bir ToDo kaydına yeni bir açıklama eklemek istediğimizde Append kullanabiliriz.Liste değimez her veri eklenirken yeni bir kayıt oluşturulur.

        //satausu false olan  bır liste 
        public IActionResult InomplateTask()
        {
            var values = _contex.ToDos
                .Where(x => !x.Status)       //statusu false olanları seç
                .Select(y => y.Description)   //sadece description alanını al
                .ToList()                           //sonuçları bir listeye dönüştür
                .Append("Gün sonunda tum gorevleri kontrol etemeyı unutma !!")
                .ToList();                          //append ile eklenen değeri de listeye dönüştür
            return View(values);
        }

        //PEREPEND : APPENDİN AKSINE YENI LISTE OLUŞTURUR VE GIRILEN DEĞERİ LİSTENIN EN BAŞINA EKLER 
        public IActionResult InomplateTaskPrepend()
        {
            var values = _contex.ToDos
                .Where(x => !x.Status)       //statusu false olanları seç
                .Select(y => y.Description)   //sadece description alanını al
                .ToList()                           //sonuçları bir listeye dönüştür
                .Prepend("Güne başlamadan tum gorevleri kontrol etemeyı unutma !!")
                .ToList();                          //append ile eklenen değeri de listeye dönüştür
            return View(values);
        }
        #endregion


        //CHUNK :Bir koleksiyonu belirli boyutlarda parçalara bölmeye yarar.Örneğin,
        //bir ToDo listesini 3'erli gruplara bölmek istediğimizde Chunk kullanabiliriz.
        public IActionResult TodoChunk()
        {
            var values = _contex.ToDos
                .Where(x => !x.Status)
                .ToList()
                .Chunk(3) // ToDo nesnelerini 3'erli gruplara (ToDo[]) böler.
                .ToList(); // IEnumerable'ı View'ın beklediği List türüne dönüştürür.

            return View(values);
        }


        //CONCAT : Birden fazla koleksiyonu uç uca ekleyerek tek bir koleksiyon haline getirmeye yarar.Örneğin,
        //tamamlanmış ve tamamlanmamış ToDo listelerini birleştirmek istediğimizde Concat kullanabiliriz.
        //orjinal liste değişmez yenı bir ENUMARBLE geriye doner
        //ADDRANGE LİSTEYİ DEĞİŞİR 

        public IActionResult TodosConcat()
        {
            var values = _contex.ToDos
                .Where(x => x.Priority == "Birincil")
                .ToList()
                .Concat(
                        _contex.ToDos.Where(y => y.Priority == "İkincil").ToList()
                        ) // İki listeyi birleştirir
                .ToList(); // Sonuçları bir listeye dönüştür
            return View(values);
        }

        //UNİON : ıkı kolaksıyonu bırleştırır ama farkı aynı eleman varsa sadece bır kere alır yani çiftleri otomatık eler.
        //Concat hepsini arka arkaya ekler.

        public IActionResult TodosUnion()
        {
            var values1=_contex.ToDos.Where(x=>x.Priority=="Birincil").ToList();
            var values2=_contex.ToDos.Where(x=>x.Priority=="İkincil").ToList();
            var result=values1.UnionBy(values2,x=>x.Description).ToList(); // İki listeyi DESCRİPTİON ALANINA GORE TEKİL ŞEKİLDE birleştirir ve tekrar edenleri kaldırır
            return View(result);

        }
    }
}
