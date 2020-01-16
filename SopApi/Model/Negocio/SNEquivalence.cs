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

        public async Task<SEResponse> InsertEquivalence(SEEquivalence entity)
        {
            _Method = "public async Task<int> InsertEquivalence(SEEquivalence entity)";
            string sp = "spEquivalenceInsert";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdParameter, entity.IdEntity, entity.IdCode, entity.Description, 4);
                if (response.StatusCode != "00")
                {
                    if (response.StatusCode == "03" && response.Message.Contains("ERROR CONTROLADO:"))
                    {
                        SEResponse result = new SEResponse() { Message = response.Message, StatusCode = SEStatusCode.Info };
                        if (response.Message.Contains("El registro ya existe")) result.StatusCode = SEStatusCode.Exist;
                        return result;
                    }
                    else
                        throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                }
                else
                    return new SEResponse() { Message = response.Message, StatusCode = SEStatusCode.Insert };
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex;
            }
        }

        public async Task<SEResponse> UpdateEquivalence(SEEquivalence entity)
        {
            _Method = "public async Task<int> UpdateEquivalence(SEEquivalence entity)";
            string sp = "spEquivalenceUpdate";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdEquivalence, entity.IdParameter, entity.IdEntity, entity.IdCode, entity.Description, entity.Active, 4);
                if (response.StatusCode != "00")
                {
                    if (response.StatusCode == "03" && response.Message.Contains("ERROR CONTROLADO:"))
                    {
                        SEResponse result = new SEResponse() { Message = response.Message, StatusCode = SEStatusCode.Info };
                        if (response.Message.Contains("El registro ya existe")) result.StatusCode = SEStatusCode.Exist;
                        return result;
                    }
                    else
                        throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                }
                else
                    return new SEResponse() { Message = response.Message, StatusCode = SEStatusCode.Update };
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex;
            }
        }

        public async Task<List<SEEquivalence>> GetAllEquivalence()
        {
            _Method = "public async Task<List<SEEquivalence>> GetAllEquivalence()";
            string sp = "spEquivalenceGetAll";
            List<SEEquivalence> result = new List<SEEquivalence>();

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<List<SEEquivalence>> response = await database.QueryAsync<SEEquivalence>(sp);
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
