using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Controllers.Resorces
{
    public class UserResorce
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Password { get; set; }
        public bool IsManager { get; set; }
    }
        
}
