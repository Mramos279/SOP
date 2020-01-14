using System;
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
    public class SNBank
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;
        private string _TableName = "Sop.Bank";

        public SNBank(HttpContext HttpContext)
        {
            _Class = typeof(SNBank).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<int> InsertBank(SEBank entity)
        {
            _Method = "public async Task<int> InsertBank(SEBank entity)";
            string sp = "spBankInsert";

            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.BankName, entity.Address, entity.Phone, 4);
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

        public async Task<int> UpdateBank(SEBank entity)
        {
            _Method = "public async Task<int> UpdateBank(SEBank entity)";
            string sp = "spBankUpdate";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdBank, entity.BankName, entity.Address, entity.Phone, entity.Active, 4);
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

        public async Task<List<SEBank>> GetAllBank()
        {
            _Method = "public async Task<List<SEBank>> GetAllBank()";
            string sp = "spBankGetAll";
            List<SEBank> result = new List<SEBank>();

            SDConexion database = new SDConexion(_HttpContext);

            try
            {
                Response<List<SEBank>> response = await database.QueryAsync<SEBank>(sp);
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
