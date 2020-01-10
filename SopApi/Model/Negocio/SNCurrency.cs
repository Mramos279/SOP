using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SopApi.Model.Entidades;
using SopApi.Model.Datos;
using Microsoft.AspNetCore.Http;
using ApiConsumer.Entities;

namespace SopApi.Model.Negocio
{
    public class SNCurrency
    {

        private HttpContext _HttpContext = null;

        private string _TableName = "Sop.Currency";
        private string _Class = null;
        private string _Method = null;
        private SNHistoryChange _SNHistoryChange = null;

        public SNCurrency(HttpContext HttpContext)
        {
            _SNHistoryChange = new SNHistoryChange();
            _Class = typeof(SNCurrency).Name.ToString();
            _HttpContext = HttpContext;
        }

        public async Task<List<SECurrency>> ShowCurrency()
        {

            List<SECurrency> resultado = new List<SECurrency>();

            _Method = "public async Task<List<SECurrency>> ShowCurrency()";
            string sp = "Sop.ShowCurrency";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {
                Response<List<SECurrency>> Response = await database.QueryAsync<SECurrency>(sp);

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

        public async Task<bool> ValidCurrency(SECurrency Obj)
        {

            bool resultado = false;

            _Method = "public async Task<bool> ValidCurrency(SECurrency Obj)";
            string sp = string.Format("SELECT Sop.ValidateCurrency({0},'{1}','{2}') AS Existe", Obj.IdCurrency, Obj.Currency, Obj.TypePrice);

            SDConexion database = new SDConexion(_HttpContext);

            try
            {
                Response<object> Response = await database.ExecuteScalarAsync(sp);

                if (Response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                else
                    resultado = (bool)Response.Result;

            }
            catch (Exception ex)
            {
                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
            }

            return resultado;
        }

        public async Task<int> InsertCurrency(SECurrency Obj)
        {


            List<SECurrency> listCurrency = new List<SECurrency>();
            List<SEHistoryChange> listHistory = new List<SEHistoryChange>();

            int resultado = 0; // Resultado final de las filas totales afectadas

            _Method = "public async Task<int> InsertCurrency(SECurrency Obj)";
            string sp = "Sop.InsertCurrency";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {

                // se registra el nuevo currency
                Response<List<SECurrency>> Response = await database.QueryAsync<SECurrency>(sp, Obj.Currency, Obj.TypePrice);

                if (Response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                else
                {
                    listCurrency = Response.Result;

                    resultado = listCurrency.Count(); // obteniendo las filas afectadas

                    if (resultado > 0) //si es mayor que cero se inserta el log en la tabla de historial de cambios
                    {

                        //se obtiene el primer elemento de la lista de la insercion
                        var item = listCurrency.FirstOrDefault();

                        //se agrega a la lista de historial de cambios para luego guardar en base de datos
                        listHistory.Add(new SEHistoryChange() { TableName = _TableName, TableId = item.IdCurrency.ToString(), ColumnName = "Currency", Before = null, After = item.Currency, Action = "Insert", IdUser = 1, IP = null, ComputerName = null, ChangeNote = null });
                        listHistory.Add(new SEHistoryChange() { TableName = _TableName, TableId = item.IdCurrency.ToString(), ColumnName = "TypePrice", Before = null, After = item.TypePrice, Action = "Insert", IdUser = 1, IP = null, ComputerName = null, ChangeNote = null });

                        //se pasa la lista al proceso que registra el historial de cambios para luego ser guardada en base de datos
                        sp = _SNHistoryChange.InsertHistoryChanges(listHistory, database);

                        if (sp.Trim() != string.Empty)
                            database.TransactionSql(sp);

                    }

                }

            }
            catch (Exception ex)
            {

                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());

                throw ex; //para mandar a imprimir el error en el metodo principal
            }

            return resultado;
        }

        public async Task<int> UpdateCurrency(SECurrency Obj)
        {

            int resultado = 0;

            List<SECurrency> listCurrency = new List<SECurrency>();
            List<SEHistoryChange> listHistory = new List<SEHistoryChange>();

            _Method = "public async Task<int> UpdateCurrency(SECurrency Obj)";
            string sp = "Sop.UpdateCurrency";

            SDConexion database = new SDConexion(_HttpContext);

            try
            {

                //Obteniendo el Currency antes de insertar para validar que registros se van a modificar y mandar a registrar en el historial de registro
                Response<List<SECurrency>> Response = await database.QueryAsync<SECurrency>("ShowCurrencyById", Obj.IdCurrency);

                if (Response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                else
                {
                    listCurrency = Response.Result;

                    resultado = listCurrency.Count();

                    if (resultado > 0)
                    {

                        //se obtiene el primer elemento de la lista antes de insertar
                        var item = listCurrency.FirstOrDefault();

                        //se agrega a la lista de historial de cambios para luego guardar en base de datos    
                        if (Obj.Currency != item.Currency)
                            listHistory.Add(new SEHistoryChange() { TableName = _TableName, TableId = item.IdCurrency.ToString(), ColumnName = "Currency", Before = item.Currency, After = Obj.Currency, Action = "Update", IdUser = 1, IP = null, ComputerName = "", ChangeNote = null });


                        if (Obj.TypePrice != item.TypePrice)
                            listHistory.Add(new SEHistoryChange() { TableName = _TableName, TableId = item.IdCurrency.ToString(), ColumnName = "TypePrice", Before = item.TypePrice, After = Obj.TypePrice, Action = "Update", IdUser = 1, IP = null, ComputerName = null, ChangeNote = null });


                        Response = await database.QueryAsync<SECurrency>(sp, Obj.IdCurrency, Obj.Currency, Obj.TypePrice);

                        if (Response.StatusCode != "00") // Resultado de la actualizacion
                            throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));
                        else
                        {
                            resultado = listCurrency.Count(); // obteniendo las filas afectadas

                            if (resultado > 0) //si es mayor que cero se inserta el log en la tabla de historial de cambios
                            {

                                if (listHistory.Count > 0)
                                {
                                    //se pasa la lista al proceso que registra el historial de cambios para luego ser guardada en base de datos
                                    sp = _SNHistoryChange.InsertHistoryChanges(listHistory, database);
                                    if (sp.Trim() != string.Empty)
                                        database.TransactionSql(sp);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                database.InsertErrorAsyc(_Class, _Method, sp, ex.Message.ToString());
                throw ex; //para mandar a imprimir el error en el metodo principal

            }

            return resultado;
        }


    }
}
