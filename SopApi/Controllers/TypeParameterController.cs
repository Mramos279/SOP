using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SopApi.Model.Entidades;
using SopApi.Model.Negocio;

namespace SopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeParameterController : ControllerBase
    {
        // GET: api/TypeParameter
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TypeParameter/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TypeParameter
        [HttpPost]
        public async Task<int> Post(SETypeParameter entity)
        {
            SNTypeParameter _SNTypeParameter = new SNTypeParameter(HttpContext);
            return await _SNTypeParameter.InsertTypeParameter(entity);
        }

        // PUT: api/TypeParameter/5
        [HttpPut]
        public async Task<int> Put(SETypeParameter entity)
        {
            SNTypeParameter _SNTypeParameter = new SNTypeParameter(HttpContext);
            return await _SNTypeParameter.UpdateTypeParameter(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
