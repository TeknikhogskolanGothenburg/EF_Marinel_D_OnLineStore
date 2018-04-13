using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLineStore.Domain
{
    public class Login
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
