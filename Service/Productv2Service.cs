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
    public class Productv2Service
    {
        public List<Productv2> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Productv2.ToList();
            }
        }

        public Productv2 GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Productv2.Find(id);
            }
        }

        public void Insert(Productv2 productv2)
        {
            using (var context = new ExampleContext())
            {
                context.Productv2.Add(productv2);
                context.SaveChanges();
            }
        }

        public void Update(Productv2 productv2)
        {
            using (var context = new ExampleContext())
            {
                var existingProductv2 = context.Productv2.Where(x => x.Productv2ID == productv2.Productv2ID).FirstOrDefault<Productv2>();

                if (existingProductv2 != null)
                {
                    existingProductv2.Price = productv2.Price;
                    existingProductv2.Name = productv2.Name;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
        }

        public bool Delete(int id)
        {
            using (var context = new ExampleContext())
            {
                var productv2 = context.Productv2.Find(id);
                context.Entry(productv2).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
