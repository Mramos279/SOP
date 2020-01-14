using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SECountry
    {
        public Int16 IdCountry { get; set; }
        public string CountryName { get; set; }
        public bool Active { get; set; }
    }
}
