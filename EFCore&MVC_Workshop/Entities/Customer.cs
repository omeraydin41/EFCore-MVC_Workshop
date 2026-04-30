namespace EFCore_MVC_Workshop.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurName { get; set; }
        public string CustomerCity { get; set; }
        public string? CustomerDistrict { get; set; }//ilçe / null olabılır
        public decimal Balance { get; set; }//bakiye
        public string? CustomerImageUrl { get; set; }//bakiye
    }
}
