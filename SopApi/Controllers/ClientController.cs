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
    public class ClientController : ControllerBase
    {
        // GET: api/Client
        [HttpGet]
        public async Task<List<SEClient>> Get()
        {
            SNClient _SNClient = new SNClient(HttpContext);
            return await _SNClient.GetAllClient();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        [HttpPost]
        public async Task<SEResponse> Post(SEClient entity)
        {
            SNClient _SNClient = new SNClient(HttpContext);
            return await _SNClient.InsertClient(entity);
        }

        // PUT: api/Client/5
        [HttpPut]
        public async Task<SEResponse> Put(SEClient entity)
        {
            SNClient _SNClient = new SNClient(HttpContext);
            return await _SNClient.UpdateClient(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
