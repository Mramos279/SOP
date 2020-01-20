using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEAccount
    {
        public Int16 IdAccount { get; set; }
        public Int16 IdBank { get; set; }
        public string Account { get; set; }
        public string ABA { get; set; }
        public string Swift { get; set; }
        public bool Active { get; set; }
    }
}
