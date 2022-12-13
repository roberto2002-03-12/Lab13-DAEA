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
    public class ClientService
    {
        public List<Client> Get()
        {
            using (var context = new ExampleContext())
            {
                return context.Client.ToList();
            }
        }

        public Client GetById(int id)
        {
            using (var context = new ExampleContext())
            {
                return context.Client.Find(id);
            }
        }

        public void Insert(Client client)
        {
            using (var context = new ExampleContext())
            {
                context.Client.Add(client);
                context.SaveChanges();
            }
        }

        public void Update(Client client)
        {
            using (var context = new ExampleContext())
            {
                var existingClient = context.Client.Where(x => x.ClientID == client.ClientID).FirstOrDefault<Client>();

                if (existingClient != null)
                {
                    existingClient.name = client.name;
                    existingClient.lastName = client.lastName;
                    existingClient.cellPhone = client.cellPhone;
                    existingClient.email = client.email;
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
                var client = context.Client.Find(id);
                context.Entry(client).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
    }
}
