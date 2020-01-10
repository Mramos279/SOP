using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{    
    public class SEResponse
    {
        public SEStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
