using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using SopApi.Model.Datos;
using SopApi.Model.Entidades;
using Microsoft.EntityFrameworkCore;
using ApiConsumer.Entities;

namespace SopApi.Model.Negocio
{
    public class SNHistoryChange
    {

        private string _Class = null;
        private string _Method = null;

        public SNHistoryChange()
        {
            _Class = typeof(SNHistoryChange).Name;
        }

        public string InsertHistoryChanges(List<SEHistoryChange> List, SDConexion Database)
        {

            string resultado = "";

            _Method = "public async Task<int> InsertHistoryChanges(List<SEHistoryChange> List, SDConexion Conexion)";
            string sp = "EXEC InsertHistoryChanges {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9};";

            try
            {
                foreach (var item in List)
                {
                    resultado += string.Format(sp, sp, item.TableName, item.TableId, item.ColumnName, item.Before, item.After, item.Action, item.IdUser, item.IP, item.ComputerName, item.ChangeNote);
                }

            }
            catch (Exception ex)
            {
                Database.InsertErrorAsyc(_Class, _Method, sp, ex.Message);
            }

            return resultado;

        }

    }
}
