﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SopApi.Model.Entidades;
using SopApi.Model.Datos;
using Microsoft.AspNetCore.Http;
using ApiConsumer.Entities;

namespace SopApi.Model.Negocio
{
    public class SNEquivalence
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNEquivalence(HttpContext HttpContext)
        {
            _Class = typeof(SNEquivalence).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<int> InsertEquivalence(SEEquivalence entity)
        {
            _Method = "public async Task<int> InsertEquivalence(SEEquivalence entity)";
            string sp = "spEquivalenceInsert";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdParameter, entity.IdEntity, entity.IdCode, entity.Description, 4);
                if (response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                else
                    result = response.Result;
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex;
            }

            return result;
        }

        public async Task<int> UpdateEquivalence(SEEquivalence entity)
        {
            _Method = "public async Task<int> UpdateEquivalence(SEEquivalence entity)";
            string sp = "spEquivalenceUpdate";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdEquivalence, entity.IdParameter, entity.IdEntity, entity.IdCode, entity.Description, entity.Active, 4);
                if (response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                else
                    result = response.Result;
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex;
            }


            return result;
        }
    }
}