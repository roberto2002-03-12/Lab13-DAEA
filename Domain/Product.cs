using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public string ExpirationDate { get; set; }
        public double IGV { get; set; }
    }
}
