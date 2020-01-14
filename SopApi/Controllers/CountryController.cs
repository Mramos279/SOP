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
    public class CountryController : ControllerBase
    {
        // GET: api/Country
        [HttpGet]
        public async Task<List<SECountry>> Get()
        {
            SNCountry _SNCountry = new SNCountry(HttpContext);
            return await _SNCountry.GetAllCountry();
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Country
        [HttpPost]
        public async Task<int> Post(SECountry entity)
        {
            SNCountry _SNCountry = new SNCountry(HttpContext);
            return await _SNCountry.InsertCountry(entity);
        }

        // PUT: api/Country/5
        [HttpPut]
        public async Task<int> Put(SECountry entity)
        {
            SNCountry _SNCountry = new SNCountry(HttpContext);
            return await _SNCountry.UpdateCountry(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
