using System;
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
    public class SNEntity
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNEntity(HttpContext HttpContext)
        {
            _Class = typeof(SNEntity).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<int> InsertEntity(SEEntity entity)
        {
            _Method = "public async Task<int> InsertEntity(SEEntity entity)";
            string sp = "spEntityInsert";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.Description, 4);
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

        public async Task<int> UpdateEntity(SEEntity entity)
        {
            _Method = "public async Task<int> UpdateEntity(SEEntity entity)";
            string sp = "spEntityUpdate";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdEntity, entity.Description, entity.Active, 4);
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

        public async Task<List<SEEntity>> GetAllEntity()
        {
            _Method = "public async Task<List<SEEntity>> GetAllEntity()";
            string sp = "spEntityGetAll";
            List<SEEntity> result = new List<SEEntity>();

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<List<SEEntity>> response = await database.QueryAsync<SEEntity>(sp);
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
