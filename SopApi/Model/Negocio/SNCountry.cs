using ApiConsumer.Entities;
using Microsoft.AspNetCore.Http;
using SopApi.Model.Datos;
using SopApi.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Negocio
{
    public class SNCountry
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNCountry(HttpContext HttpContext)
        {
            _Class = typeof(SNCountry).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<int> InsertCountry(SECountry entity)
        {
            _Method = "public async Task<int> InsertCountry(SECountry entity)";
            string sp = "spCountryInsert";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.CountryName, 4);
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

        public async Task<int> UpdateCountry(SECountry entity)
        {
            _Method = "public async Task<int> UpdateCountry(SECountry entity)";
            string sp = "spCountryUpdate";
            int result = 0;

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<int> response = await database.ExecuteAsync(sp, entity.IdCountry, entity.CountryName, entity.Active, 4);
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
