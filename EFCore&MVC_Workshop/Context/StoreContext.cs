using EFCore_MVC_Workshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_MVC_Workshop.Context
{
    public class StoreContext: DbContext//DbContext EntityFrameworkCore den gelir
    //DbContext, uygulamanız ile veritabanı arasındaki iletişimi yöneten, sorgulama ve veri kaydetme işlemlerini yürüten temel bir köprü görevi görür.
    {
        //connection string buraya yazılmalı 
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MD57CH6; initial Catalog=WorkshopDb;integrated Security=true;trust server certificate =true");
        }

        //sql ye yansıtılacak tablolar alt kısma yazılmalı 
        public DbSet<Category> Categories { get; set; }//Categories tablo adımız oldu db de 
        public DbSet<Product> Products { get; set; }//Products tablo adımız  oldu db de 
        public DbSet<Customer> Customers { get; set; }//Customers tablo adımız  oldu db de
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Message> Messages { get; set; }

       
    }

}
