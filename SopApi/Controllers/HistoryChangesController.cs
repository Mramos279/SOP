using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SopApi.Model.Entidades;
using SopApi.Model.Negocio;

namespace SopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryChangesController : ControllerBase
    {
        // GET: api/HistoryChanges
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HistoryChanges/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/HistoryChanges
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/HistoryChanges/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("/api/HistoryChanges/GetHistory")]
        [HttpGet]
        public async Task<IActionResult> GetHistoryChangesByTableNameAndUserId(SEHistoryChange entity)
        {
            SNHistoryChange _SNHistoryChange = new SNHistoryChange(HttpContext);
            string result = await _SNHistoryChange.GetAllHitoryChangeByTableNameAndUserId(entity);
            JArray parseArray = JArray.Parse(result);

            return Ok(JsonConvert.SerializeObject(parseArray));
        }
    }
}
