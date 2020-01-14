﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SopApi.Model.Datos;
using ApiConsumer.Entities;
using SopApi.Model.Entidades;

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

        public async Task<int> InsertAccount(SEAccount entity)
        {

            _Method = "public async Task<int> InsertAccount(SEAccount entity)";
            string sp = "spAccountInsert";

            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdBank, entity.Account, entity.ABA, entity.Swift, 4);
                if (response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                else
                    result =response.Result;
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex;
            }
            return result;
        }

        public async Task<int> UpdateAccount(SEAccount entity)
        {
            _Method = "public async Task<int> UpdateAccount(SEAccount entity)";
            string sp = "spAccountUpdate";

            int result = 0;
            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdAccount, entity.IdBank, entity.Account, entity.ABA, entity.Swift, entity.Active, 4);
                if (response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", response.StatusCode, response.Message));
                else
                    result= response.Result;
            } 
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw;
            }
            return result;
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
