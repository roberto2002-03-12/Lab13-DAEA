using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        public int ClientID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public int cellPhone { get; set; }
        public string email { get; set; }
        public ICollection<Receipt> receipts { get; set; }
    }
}