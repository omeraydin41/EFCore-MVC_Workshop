namespace EFCore_MVC_Workshop.Entities
{
    public class Product//ürün
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductStock { get; set; }
       
    }
}
