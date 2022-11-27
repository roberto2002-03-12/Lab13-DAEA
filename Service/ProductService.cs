using Domain;
using Infraestructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService
    {
        public List<Product> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Product.Where(x => x.Active == true).ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Product.Find(id);
            }
        }

        public void Insert(Product product)
        {
            using (var context = new ExampleContext())
            {
                product.CreationDate = DateTime.Today;
                product.Active = true;
                product.IGV = product.SellPrice * 0.18;
                context.Product.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (var context = new ExampleContext())
            {
                var existingProduct = context.Product.Where(x => x.ProductID == product.ProductID).FirstOrDefault<Product>();

                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.SellPrice = product.SellPrice;
                    existingProduct.Active = product.Active;
                    existingProduct.ExpirationDate = product.ExpirationDate;
                    existingProduct.IGV = product.SellPrice * 0.18;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("not found");
                }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new ExampleContext())
            {
                var product = context.Product.Find(id);
                context.Entry(product).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
