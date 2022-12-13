using APITecsup.Models.Request;
using APITecsup.Models.Response;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace APITecsup.Controllers
{
    public class ReceiptController : ApiController
    {
        public List<Receipt> Get()
        {
            var service = new ReceiptService();
            var receipts = service.Get();
            return receipts;
        }

        public Receipt GetById(int id)
        {
            var service = new ReceiptService();
            var receipts = service.GetById(id);
            return receipts;
        }

        [HttpPost]
        public bool Insert(Receipt request)
        {
            var response = true;
            try
            {
                var service = new ReceiptService();
                service.Insert(new Receipt
                {
                    Total = request.Total,
                    Date = request.Date,
                    PayOff = request.PayOff,
                    Client = request.Client,
                });
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        [HttpPut]
        public bool Update(Receipt request)
        {
            var response = true;
            try
            {
                var service = new ReceiptService();
                service.Update(new Receipt
                {
                    Total = request.Total,
                    Date = request.Date,
                    PayOff = request.PayOff,
                    Client = request.Client,
                });
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var response = true;
            try
            {
                var service = new ReceiptService();
                service.Delete(id);
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }
    }
}