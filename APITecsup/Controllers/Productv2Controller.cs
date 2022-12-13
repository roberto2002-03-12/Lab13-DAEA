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
    public class Productv2Controller : ApiController
    {
        public List<Productv2> Get()
        {
            var service = new Productv2Service();
            var products = service.Get();
            return products;
        }

        public Productv2 GetById(int id)
        {
            var service = new Productv2Service();
            var product = service.GetById(id);
            return product;
        }

        [HttpPost]
        public bool Insert(Productv2 request)
        {
            var response = true;
            try
            {
                var service = new Productv2Service();
                service.Insert(new Productv2
                {
                    Name = request.Name,
                    Price = request.Price,
                });
            } catch (Exception)
            {
                response = false;
            }
            return response;
        }

        [HttpPut]
        public bool Update(Productv2 request)
        {
            var response = true;
            try
            {
                var service = new Productv2Service();
                service.Update(new Productv2
                {
                    Name = request.Name,
                    Price = request.Price,
                });

            } catch (Exception)
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
                var service = new Productv2Service();
                service.Delete(id);
            } catch (Exception)
            {
                response = false;
            }
            return response;
        }
    }
}