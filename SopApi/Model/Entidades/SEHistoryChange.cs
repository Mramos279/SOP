using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEHistoryChange
    {
        public long IdHistory { get; set; }
        public string TableName { get; set; }
        public int TableId { get; set; }
        public string Changes { get; set; }
        public byte IdAction { get; set; }
        public int UserId { get; set; }
        public DateTime RegistDate { get; set; }
        public int RegistDateNum { get; set; }
    }
}
