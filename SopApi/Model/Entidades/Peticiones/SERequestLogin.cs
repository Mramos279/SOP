using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SERequestLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Int16 ApplicationId { get; set; }
    }
}
