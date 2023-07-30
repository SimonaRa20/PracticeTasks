using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity8
{
    public class CustomerInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public CustomerInfo(int id, string name, string address, string email)
        {
            ID = id;
            Name = name;
            Address = address;
            Email = email;
        }
    }
}
