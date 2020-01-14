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
    public class EntityController : ControllerBase
    {
        // GET: api/Entity
        [HttpGet]
        public async Task<List<SEEntity>> Get()
        {
            SNEntity _SNEntity = new SNEntity(HttpContext);
            return await _SNEntity.GetAllEntity();
        }

        // GET: api/Entity/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Entity
        [HttpPost]
        public async Task<int> Post(SEEntity entity)
        {
            SNEntity _SNEntity = new SNEntity(HttpContext);
            return await _SNEntity.InsertEntity(entity);
        }

        // PUT: api/Entity/5
        [HttpPut]
        public async Task<int> Put(SEEntity entity)
        {
            SNEntity _SNEntity = new SNEntity(HttpContext);
            return await _SNEntity.UpdateEntity(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
