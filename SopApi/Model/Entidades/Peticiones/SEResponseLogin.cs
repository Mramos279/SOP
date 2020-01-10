using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEResponseLogin
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
