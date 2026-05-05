using EFCore_MVC_Workshop.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EFCore_MVC_Workshop.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsViewComponentPartial:ViewComponent
    {
        private readonly StoreContext _context;//her db işlemşnde classlarda bır bağlantı nesnesi alınmalıdır.

        public _StatisticsViewComponentPartial(StoreContext context)//Bu kodda constructor kullanılmasının temel sebebi Dependency Injection (Bağımlılık Enjeksiyonu)'dur.
        {//bağlantı hazır alınmaz veya manuel olarak oluşturulmaz, ASP.NET Core'un DI konteyneri tarafından sağlanır.
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            //toplam urun sayısı 
            ViewBag.categoryCount= _context.Categories.Count();//ViewBag : backendden uı ye data taşır.//count satır sayısı alır 

            //en pahalı ürünün fiyatı
            ViewBag.productMaxPrice = _context.Products.Max(p => p.ProductPrice);//max kolonda en yuksek datayı verir.satırlar arası işlem lamda(isimsiz fonk) kullanıldı 

            //en düşük ürün fiyatı
            ViewBag.productMinPrice = _context.Products.Min(p => p.ProductPrice);


            //ALT SORGULAR
            //max fiaytlı urunun adı :UI de productMaxPrice altına gelecek 
            ViewBag.productMaxPriceProductName = _context.Products
                .Where(x=>x.ProductPrice == (_context.Products.Max(p => p.ProductPrice)))//en yuksek fıyatlı urunun tum bilgilerini aldık 
                .Select(z=>z.ProductName).FirstOrDefault();//select ile gelen biligilerden isim  kısmını aldık 

            ViewBag.productMinPriceProductName = _context.Products
                .Where(x=>x.ProductPrice == (_context.Products.Min(y=>y.ProductPrice)))//buraya kadar en düşk fiyatlı ürünün tum bilgileri geldi;
                .Select(z=>z.ProductName).FirstOrDefault();//burda ise gelen bilgilerden isim değerini yakaladık 



            //stoklardaki toplam urun sayısı.
            ViewBag.totalSumProductStock=_context.Products.Sum(x=>x.ProductStock);//sum : ProductStock alınındakı tum satırları toplar

            //ortalama ürünü stoğu 
            ViewBag.averageProductStock = _context.Products.Average(x => x.ProductStock);//avg : ProductStock alanındakı değerlerin ortalamasını alır 

            //ortalama ürün fiyatı 
            ViewBag.averageProductPrice = _context.Products.Average(x=>x.ProductPrice);


            //where :EF de SORGULAMAK için kullanılan methoddur. Koşula uyan kayıtları filtreler ve döndürür.
            //x=>x. lamda : ilgili methoddan(burda where) once gelen entitiynın içindeki(burda Product) propertylere erişmek için kullanılır.

            //ToList : mesela price =50 olan tum urunlerı getirir.
            //firstordefault : price =50 sonuçlardan ilkini verir. eğer hiç sonuç gelmezse null döner.
            //select() : sorgu sonucundan belirli bir alanı seçmek için kullanılır. Örneğin, sadece ürün bilgilerinden isim kısmını almak istediğimizde kullanılır.
            return View();
        }
    }

    /*Program.cs'de kayıt
    builder.Services.AddDbContext<StoreContext>()
        ↓
    ASP.NET Core otomatik inject eder
        ↓
    Constructor karşılar → _context'e atar
        ↓
    Invoke() metodu _context'i kullanabilir*/
}
