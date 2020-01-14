using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEEquivalence
    {
        public int IdEquivalence { get; set; }
        public Int16 IdParameter { get; set; }
        public Int16 IdEntity { get; set; }
        public Int16 IdCode { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
