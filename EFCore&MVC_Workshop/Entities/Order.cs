namespace EFCore_MVC_Workshop.Entities
{
    public class Order//satışlar 
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }//satışatıkı urun ID
        public int CustomerId { get; set; }//satıştıkı müşteri ID
        public int OrderCount { get; set; }//kaç adet satıldı 
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
