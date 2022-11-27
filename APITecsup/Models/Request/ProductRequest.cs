using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup.Models.Request
{
    public class ProductRequest
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double SellPrice { get; set; }
        public bool Active { get; set; }
        public string ExpirationDate { get; set; }
    }
}