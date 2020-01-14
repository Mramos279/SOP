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
    public class EquivalenceController : ControllerBase
    {
        // GET: api/Equivalence
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Equivalence/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equivalence
        [HttpPost]
        public async Task<int> Post(SEEquivalence entity)
        {
            SNEquivalence _SNEquivalence = new SNEquivalence(HttpContext);
            return await _SNEquivalence.InsertEquivalence(entity);
        }

        // PUT: api/Equivalence/5
        [HttpPut]
        public async Task<int> Put(SEEquivalence entity)
        {
            SNEquivalence _SNEquivalence = new SNEquivalence(HttpContext);
            return await _SNEquivalence.UpdateEquivalence(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
