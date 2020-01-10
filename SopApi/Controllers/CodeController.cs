using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SopApi.Model.Negocio;
using SopApi.Model.Entidades;
using Microsoft.AspNetCore.Authorization;

namespace SopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {

        //Proceso para codificar por medio de una descripcion
        [HttpGet("CodeByDescription")]
        [Authorize]
        public Task<List<SECode>> CodeByDescription(string Description)
        {
            return new SNCode(HttpContext).CodeByDescription(Description);
        }

        //Proceso para codificar de manera masiva por medio de descripciones
        [HttpGet("MassCodingByDescription")]
        [Authorize]
        public Task<List<SECode>> MassCodingByDescription(string Descriptions)
        {
            return new SNCode(HttpContext).MassCodingByDescription(Descriptions);
        }

        //Proceso para codificar por medio de parametros
        [HttpGet("CodeByParameter")]
        [Authorize]
        public Task<List<SECode>> CodeByParameter(string type, string cm, string color, string usp, string mm, string curvature, string crossSection)
        {
            return new SNCode(HttpContext).CodeByParameter(type, cm, color, usp, mm, curvature, crossSection);
        }

        //Proceso para codificar por medio de un codigo demetech
        [HttpGet("DecodeByCodeDeme")]
        [Authorize]
        public Task<List<SECode>> DeCodeByCodeDemetech(string Code)
        {
            return new SNCode(HttpContext).DeCodeByCodeDemetech(Code);
        }

        //Proceso para codificar de manera masiva para codigos demetech
        [HttpGet("MassDecodingByCodeDemetech")]
        [Authorize]
        public Task<List<SECode>> MassDecodingByCodeDemetech(string Codes)
        {
            return new SNCode(HttpContext).MassDecodingByCodeDemetech(Codes);
        }

    }
}