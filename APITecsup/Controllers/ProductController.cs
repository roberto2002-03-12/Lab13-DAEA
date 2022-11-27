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
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            var service = new ProductService();
            var products = service.Get();

            return products;
        }
        public Product GetById(int id)
        {
            var service = new ProductService();
            var product = service.GetById(id);

            return product;
        }

        [HttpPost]
        public bool Insert(ProductRequest request)
        {
            var response = true;
            try
            {
                var service = new ProductService();
                service.Insert(new Product
                {
                    Name = request.Name,
                    Description = request.Description,
                    SellPrice = request.SellPrice,
                    ExpirationDate = request.ExpirationDate
                });
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }
        [HttpPut]
        public bool Update(ProductRequest request)
        {
            var response = true;
            try
            {
                var service = new ProductService();
                service.Update(new Product
                {
                    ProductID = request.ProductID,
                    Name = request.Name,
                    Description = request.Description,
                    SellPrice = request.SellPrice,
                    Active = request.Active,
                    ExpirationDate = request.ExpirationDate
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
                var service = new ProductService();
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