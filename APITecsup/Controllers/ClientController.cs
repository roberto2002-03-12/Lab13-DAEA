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
    public class ClientController : ApiController
    {
        public List<Client> Get()
        {
            var service = new ClientService();
            var clients = service.Get();
            return clients;
        }

        public Client GetById(int id)
        {
            var service = new ClientService();
            var client = service.GetById(id);
            return client;
        }

        [HttpPost]
        public bool Insert(Client request)
        {
            var response = true;
            try
            {
                var service = new ClientService();
                service.Insert(new Client
                {
                    name = request.name,
                    lastName = request.lastName,
                    cellPhone = request.cellPhone,
                    email = request.email,
                });
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        [HttpPut]
        public bool Update(Client request)
        {
            var response = true;
            try
            {
                var service = new ClientService();
                service.Update(new Client
                {
                    name = request.name,
                    lastName = request.lastName,
                    cellPhone = request.cellPhone,
                    email = request.email,
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
                var service = new ClientService();
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