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
    public class SNClient
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNClient(HttpContext HttpContext)
        {
            _Class = typeof(SNClient).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<SEResponse> InsertClient(SEClient entity)
        {
            _Method = "public async Task<int> InsertClient(SEClient entity)";
            string sp = "spClientInsert";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.Client, entity.Contact, entity.Email, entity.Telephone, entity.Mobile, entity.Fax, entity.Address, entity.Note, entity.Especial, entity.IdCountry, entity.IdCurrency, entity.IdAccount, entity.Discount, entity.TotalDiscount, entity.Euroexchange, entity.CreditPeriod, 4);
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

        public async Task<SEResponse> UpdateClient(SEClient entity)
        {
            _Method = "public async Task<int> UpdateClient(SEClient entity)";
            string sp = "spClientUpdate";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdClient, entity.Client, entity.Contact, entity.Email, entity.Telephone, entity.Mobile, entity.Fax, entity.Address, entity.Note, entity.Especial, entity.IdCountry, entity.IdCurrency, entity.IdAccount, entity.Discount, entity.TotalDiscount, entity.Euroexchange, entity.CreditPeriod, entity.Active, 4);
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

        public async Task<List<SEClient>> GetAllClient()
        {
            _Method = "public async Task<List<SEClient>> GetAllClient()";
            string sp = "spClientGetAll";
            List<SEClient> result = new List<SEClient>();

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<List<SEClient>> response = await database.QueryAsync<SEClient>(sp);
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
