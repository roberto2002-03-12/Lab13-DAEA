using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;

namespace Infraestructure
{
    public class ExampleContext : DbContext
    {

        public ExampleContext() : base("name = MyContextDB")
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Productv2> Productv2 { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<ReceiptDetails> ReceiptDetail { get; set; }
    }
}
