using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using SopApi.Model.Datos;
using SopApi.Model.Entidades;
using Microsoft.EntityFrameworkCore;
using ApiConsumer.Entities;
using Microsoft.AspNetCore.Http;

namespace SopApi.Model.Negocio
{
    public class SNHistoryChange
    {
        private HttpContext _HttpContext = null;
        private string _Class = null;
        private string _Method = null;

        public SNHistoryChange(HttpContext HttpContext)
        {
            _HttpContext = HttpContext;
            _Class = typeof(SNHistoryChange).Name.ToString();
        }

        public async Task<string> GetAllHitoryChangeByTableNameAndUserId(SEHistoryChange entity)
        {
            _Method = "public async Task<string> GetAllHitoryChangesByTableNameAndUserId(SEHistoryChange entity)";
            string sp = "spHistoryChangeByTableAndUserId";
            string result = "";

            SDConexion database = new SDConexion(_HttpContext);
            try
            {
                Response<string> response = await database.QueryAsync(sp, entity.TableName, entity.TableId, entity.UserId);
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

        //public string InsertHistoryChanges(List<SEHistoryChange> List, SDConexion Database)
        //{

        //    string resultado = "";

        //    _Method = "public async Task<int> InsertHistoryChanges(List<SEHistoryChange> List, SDConexion Conexion)";
        //    string sp = "EXEC InsertHistoryChanges {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9};";

        //    try
        //    {
        //        foreach (var item in List)
        //        {
        //            resultado += string.Format(sp, sp, item.TableName, item.TableId, item.ColumnName, item.Before, item.After, item.Action, item.IdUser, item.IP, item.ComputerName, item.ChangeNote);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Database.InsertErrorAsyc(_Class, _Method, sp, ex.Message);
        //    }

        //    return resultado;

        //}

    }
}
