﻿using ApiConsumer.Entities;
using Microsoft.AspNetCore.Http;
using SopApi.Model.Datos;
using SopApi.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Negocio
{
    public class SNTypeParameter
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNTypeParameter( HttpContext HttpContext)
        {
            _Class = typeof(SNTypeParameter).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<SEResponse> InsertTypeParameter(SETypeParameter entity)
        {
            _Method = "public async Task<int> InsertTypeParameter(SETypeParameter entity)";
            string sp = "spTypeParameterInsert";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.Description, 4);
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

        public async Task<SEResponse> UpdateTypeParameter(SETypeParameter entity)
        {
            _Method = "public async Task<int> UpdateTypeParameter(SETypeParameter entity)";
            string sp = "spTypeParameterUpdate";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdParameter, entity.Description, entity.Active, 4);
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

        public async Task<List<SETypeParameter>> GetAllTypeParameter()
        {
            _Method = "public async Task<List<SETypeParameter>> GetAllTypeParameter()";
            string sp = "spTypeParameterGetAll";
            List<SETypeParameter> result = new List<SETypeParameter>();

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<List<SETypeParameter>> response = await database.QueryAsync<SETypeParameter>(sp);
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
