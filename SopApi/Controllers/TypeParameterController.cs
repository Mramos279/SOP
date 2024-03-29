﻿using System;
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
        public async Task<List<SETypeParameter>> Get()
        {
            SNTypeParameter _SNTypeParameter = new SNTypeParameter(HttpContext);
            return await _SNTypeParameter.GetAllTypeParameter();
        }

        // GET: api/TypeParameter/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TypeParameter
        [HttpPost]
        public async Task<SEResponse> Post(SETypeParameter entity)
        {
            SNTypeParameter _SNTypeParameter = new SNTypeParameter(HttpContext);
            return await _SNTypeParameter.InsertTypeParameter(entity);
        }

        // PUT: api/TypeParameter/5
        [HttpPut]
        public async Task<SEResponse> Put(SETypeParameter entity)
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
