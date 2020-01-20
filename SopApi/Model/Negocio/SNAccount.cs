using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SopApi.Model.Datos;
using ApiConsumer.Entities;
using SopApi.Model.Entidades;
using Microsoft.Data.SqlClient;

namespace SopApi.Model.Negocio
{
    public class SNAccount
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;
        //private string _TableName = "Sop.Account";

        public SNAccount(HttpContext HttpContext)
        {
            _Class = typeof(SNAccount).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<SEResponse> InsertAccount(SEAccount entity)
        {

            _Method = "public async Task<int> InsertAccount(SEAccount entity)";
            string sp = "spAccountInsert";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdBank, entity.Account, entity.ABA, entity.Swift, 4);
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

        public async Task<SEResponse> UpdateAccount(SEAccount entity)
        {
            _Method = "public async Task<int> UpdateAccount(SEAccount entity)";
            string sp = "spAccountUpdate";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdAccount, entity.IdBank, entity.Account, entity.ABA, entity.Swift, entity.Active, 4);
                if (response.StatusCode != "00")
                    if (response.StatusCode == "03" && response.Message.Contains("ERROR CONTROLADO:"))
                    {
                        SEResponse result = new SEResponse() { Message = response.Message, StatusCode = SEStatusCode.Info };
                        if (response.Message.Contains("El registro ya existe")) result.StatusCode = SEStatusCode.Exist;
                        return result;
                    }
                    else
                        throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                else
                    return new SEResponse() { Message = response.Message, StatusCode = SEStatusCode.Update };
            } 
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex;
            }
        }

        public async Task<List<SEAccount>> GetAllAccount()
        {
            _Method = "public async Task<List<SEAccount>> GetAllAccount()";
            string sp = "Sop.spAccountGetAll";

            List<SEAccount> result = new List<SEAccount>();

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<List<SEAccount>> response = await database.QueryAsync<SEAccount>(sp);
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
