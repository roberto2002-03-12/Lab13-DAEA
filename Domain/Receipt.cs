using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public int Total { get; set; }
        public DateTime Date { get; set; }
        public bool PayOff { get; set; }
        public Client Client { get; set; }
    }
}
