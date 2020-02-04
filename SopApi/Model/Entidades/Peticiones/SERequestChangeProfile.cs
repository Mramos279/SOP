using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SERequestChangeProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
