using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public class SECode
    {       
        public string Code { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public string Color { get; set; }
        public string Diameter { get; set; }
        public string NeedleLength { get; set; }
        public string Curvature { get; set; }
        public string CrossSection { get; set; }
    }
}
