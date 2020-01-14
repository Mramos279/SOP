using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEClient
    {
        public int IdClient { get; set; }
        public string Client { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public bool Especial { get; set; }
        public Int16 IdCountry { get; set; }
        public Int16 IdCurrency { get; set; }
        public Int16 IdAccount { get; set; }
        public byte Discount { get; set; }
        public byte TotalDiscount { get; set; }
        public decimal Euroexchange { get; set; }
        public string CreditPeriod { get; set; }
        public bool Active { get; set; }
    }
}
