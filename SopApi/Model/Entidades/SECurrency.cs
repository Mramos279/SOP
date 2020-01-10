using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SECurrency
    {
        [Key]

        public Int16 IdCurrency { get; set; }
        public string Currency { get; set; }
        public string TypePrice { get; set; }
    }
}
