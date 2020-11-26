using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kırtasiyemalzemem.Identity
{
    public class User:IdentityUser
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int identityNumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
