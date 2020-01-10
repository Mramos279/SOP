using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SERequestNewPassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
