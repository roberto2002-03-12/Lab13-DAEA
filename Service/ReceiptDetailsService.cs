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
    public class ReceiptDetailsService
    {
        public List<ReceiptDetails> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.ReceiptDetail.ToList();
            }
        }

        public ReceiptDetails GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.ReceiptDetail.Find(id);
            }
        }

        public void Insert(ReceiptDetails receiptDetail)
        {
            using (var context = new ExampleContext())
            {
                context.ReceiptDetail.Add(receiptDetail);
                context.SaveChanges();
            }
        }

        public void Update(ReceiptDetails receiptDetail)
        {
            using (var context = new ExampleContext())
            {
                var existingReceiptDetail = context.ReceiptDetail.Where(x => x.ReceiptDetailsID == receiptDetail.ReceiptDetailsID).FirstOrDefault<ReceiptDetails>();

                if (existingReceiptDetail != null)
                {
                    existingReceiptDetail.Quantity = receiptDetail.Quantity;
                    existingReceiptDetail.Price = receiptDetail.Price;
                    existingReceiptDetail.Total = receiptDetail.Total;
                    existingReceiptDetail.ReceiptID = receiptDetail.ReceiptID;
                    existingReceiptDetail.Productv2ID = receiptDetail.Productv2ID;
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
                var receiptDetail = context.ReceiptDetail.Find(id);
                context.Entry(receiptDetail).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
