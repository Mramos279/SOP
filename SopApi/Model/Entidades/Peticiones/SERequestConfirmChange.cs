using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SERequestConfirmChange
    {
        public string UserName { get; set; }
        public string RecoveryCode { get; set; }
        public string NewPassword { get; set; }
        public string Url { get; set; }
    }
}
