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
    public class SNCode
    {

        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNCode(HttpContext HttpContext)
        {
            _Class = typeof(SNCode).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<List<SECode>> CodeByDescription(string Description)
        {
            List<SECode> resultado = new List<SECode>();

            _Method = "public async Task<List<SECode>> CodeByDescription(string Description)";
            string sp = "Sop.CodeByDescription";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {
                if (Description != null)
                {
                    Response<List<SECode>> Response = await database.QueryAsync<SECode>(sp, Description);

                    if (Response.StatusCode != "00")
                        throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                    else
                        resultado = Response.Result;
                }
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message);
            }

            return resultado;

        }

        public async Task<List<SECode>> MassCodingByDescription(string Descriptions)
        {
            List<SECode> resultado = new List<SECode>();

            _Method = "public async Task<List<SECode>> MassCodingByDescription(string Descriptions)";
            string sp = "Sop.MassCodingByDescription";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {
                if (Descriptions != null)
                {
                    Response<List<SECode>> Response = await database.QueryAsync<SECode>(sp, Descriptions);

                    if (Response.StatusCode != "00")
                        throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                    else
                        resultado = Response.Result;
                }
            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message);
            }

            return resultado;

        }

        public async Task<List<SECode>> CodeByParameter(string type, string cm, string color, string usp, string mm, string curvature, string crossSection)
        {
            List<SECode> resultado = new List<SECode>();

            type = (type == null) ? "" : type;
            cm = (cm == null) ? "" : cm;
            color = (color == null) ? "" : color;
            usp = (usp == null) ? "" : usp;
            mm = (mm == null) ? "" : mm;
            curvature = (curvature == null) ? "" : curvature;
            crossSection = (crossSection == null) ? "" : crossSection;

            _Method = "public async Task<List<SECode>> CodeByParameter(string type, string cm, string color, string usp, string mm, string curvature, string crossSection)";
            string sp = "Sop.CodeByParameter";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {

                Response<List<SECode>> Response = await database.QueryAsync<SECode>(sp, type, cm, color, usp, mm, curvature, crossSection);

                if (Response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                else
                    resultado = Response.Result;

            }
            catch (Exception ex)
            {

                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message);

            }

            return resultado;

        }

        public async Task<List<SECode>> DeCodeByCodeDemetech(string Code)
        {

            List<SECode> resultado = new List<SECode>();

            _Method = "public async Task<List<SECode>> DeCodeByCodeDemetech(string Code)";
            string sp = "Sop.DecodeByCodeDemetech";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {

                if (Code != null)
                {
                    Response<List<SECode>> Response = await database.QueryAsync<SECode>(sp, Code);

                    if (Response.StatusCode != "00")
                        throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                    else
                        resultado = Response.Result;
                }

            }
            catch (Exception ex)
            {

                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());

            }

            return resultado;

        }

        public async Task<List<SECode>> MassDecodingByCodeDemetech(string Codes)
        {

            List<SECode> resultado = new List<SECode>();

            _Method = "public async Task<List<SECode>> MassDecodingByCodeDemetech(string Codes)";
            string sp = "Sop.MassDecodingByCodeDemetech";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {

                if (Codes != null)
                {
                    Response<List<SECode>> Response = await database.QueryAsync<SECode>(sp, Codes);

                    if (Response.StatusCode != "00")
                        throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                    else
                        resultado = Response.Result;
                }

            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message);

            }

            return resultado;

        }

    }
}
