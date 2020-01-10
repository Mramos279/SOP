using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SEMenu
    {
        public Int16 MenuId { get; set; }
        public string MenuName { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public Int16 Position { get; set; }
        public Int16? FatherMenuId { get; set; }
    }
}
