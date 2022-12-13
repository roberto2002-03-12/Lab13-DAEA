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
    public class ReceiptService
    {
        public List<Receipt> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Receipt.ToList();
            }
        }

        public Receipt GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Receipt.Find(id);
            }
        }

        public void Insert(Receipt receipt)
        {
            using (var context = new ExampleContext())
            {
                context.Receipt.Add(receipt);
                context.SaveChanges();
            }
        }

        public void Update(Receipt receipt)
        {
            using (var context = new ExampleContext())
            {
                var existingReceipt = context.Receipt.Where(x => x.ReceiptID == receipt.ReceiptID).FirstOrDefault<Receipt>();

                if (existingReceipt != null)
                {
                    existingReceipt.Total = receipt.Total;
                    existingReceipt.Date = receipt.Date;
                    existingReceipt.PayOff = receipt.PayOff;
                    existingReceipt.Client = receipt.Client;
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
                var receipt = context.Receipt.Find(id);
                context.Entry(receipt).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
