using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEHistoryChange
    {
        public string TableName { get; set; }
        public string TableId { get; set; }
        public string ColumnName { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public string Action { get; set; }
        public int IdUser { get; set; }
        public string IP { get; set; }
        public string ComputerName { get; set; }
        public string ChangeNote { get; set; }

    }
}
