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
    public class BankController : ControllerBase
    {
        // GET: api/Bank
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Bank/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bank
        [HttpPost]
        public async Task<int> Post(SEBank entity)
        {
            SNBank _SNBank = new SNBank(HttpContext);
            return await _SNBank.InsertBank(entity);
        }

        // PUT: api/Bank/5
        [HttpPut]
        public async Task<int> Put(SEBank entity)
        {
            SNBank _SNBank = new SNBank(HttpContext);
            return await _SNBank.UpdateBank(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
