using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SopApi.Model.Negocio;
using SopApi.Model.Entidades;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace SopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {

        [HttpGet("ShowCurrency")]
        [Authorize]
        public async Task<List<SECurrency>> Get()
        {
            return await new SNCurrency(HttpContext).ShowCurrency();
        }

        [HttpPost("InsertCurrency")]
        [Authorize]
        public async Task<SEResponse> Post(SECurrency Currency)
        {

            SEResponse _SEResponse = new SEResponse();
            SNCurrency _SNCurrency = new SNCurrency(HttpContext);

            int resultado = 0;

            try
            {

                bool exist = await _SNCurrency.ValidCurrency(Currency);

                if (!exist)
                {
                    resultado = await _SNCurrency.InsertCurrency(Currency);

                    if (resultado > 0)
                    {
                        _SEResponse.StatusCode = SEStatusCode.Insert;
                        _SEResponse.Message = "Registro Exitoso";
                    }
                    else
                    {
                        _SEResponse.StatusCode = SEStatusCode.Info;
                        _SEResponse.Message = "El Registro no se insertó, verifique los datos";
                    }
                }
                else
                {
                    _SEResponse.StatusCode = SEStatusCode.Exist;
                    _SEResponse.Message = "Los datos ya existen";
                }

            }
            catch (Exception ex)
            {
                _SEResponse.StatusCode = SEStatusCode.Error;
                _SEResponse.Message = ex.Message;
            }


            return _SEResponse;
        }

        [HttpPut("UpdateCurrency")]
        [Authorize]
        public async Task<SEResponse> Put(SECurrency Currency)
        {

            SEResponse _SEResponse = new SEResponse();
            SNCurrency _SNCurrency = new SNCurrency(HttpContext);

            int resultado = 0;

            try
            {

                bool exist = await _SNCurrency.ValidCurrency(Currency);

                if (!exist)
                {
                    resultado = await _SNCurrency.UpdateCurrency(Currency);

                    if (resultado > 0)
                    {
                        _SEResponse.StatusCode = SEStatusCode.Update;
                        _SEResponse.Message = "Registro Actualizado";
                    }
                    else
                    {
                        _SEResponse.StatusCode = SEStatusCode.Info;
                        _SEResponse.Message = "El Registro no se modificó, verifique los datos";
                    }
                }
                else
                {
                    _SEResponse.StatusCode = SEStatusCode.Exist;
                    _SEResponse.Message = "Los datos ya existen";
                }

            }
            catch (Exception ex)
            {
                _SEResponse.StatusCode = SEStatusCode.Error;
                _SEResponse.Message = ex.Message;
            }

            return _SEResponse;
        }
    }

}