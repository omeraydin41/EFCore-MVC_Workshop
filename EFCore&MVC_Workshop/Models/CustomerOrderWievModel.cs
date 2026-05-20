using EFCore_MVC_Workshop.Entities;

namespace EFCore_MVC_Workshop.Models
{
    public class CustomerOrderWievModel
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
