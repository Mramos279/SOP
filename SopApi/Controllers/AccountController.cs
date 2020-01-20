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
    public class AccountController : ControllerBase
    {
        // GET: api/Account
        [HttpGet]
        public async Task<List<SEAccount>> Get()
        {
            SNAccount _SNAccount = new SNAccount(HttpContext);
            return await _SNAccount.GetAllAccount();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        public async Task<SEResponse> Post(SEAccount entity)
        {
             SNAccount _SNAccount = new SNAccount(HttpContext);
            return await _SNAccount.InsertAccount(entity);

        }

        // PUT: api/Account/5
        [HttpPut]
        public async Task<SEResponse> Put(SEAccount entity)
        {
            SNAccount _SNAccount = new SNAccount(HttpContext);
            return await _SNAccount.UpdateAccount(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
