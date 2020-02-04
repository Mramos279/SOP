using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SopApi.Model.Servicios;
using ApiConsumer;
using ApiConsumer.Entities;
using Microsoft.AspNetCore.Http;

namespace SopApi.Model.Datos
{
    public class SDConexion : Consumer
    {

        public SDConexion(HttpContext HttpContext) : base(HttpContext, Utility.GetKey<Int16>("ConnectionId"), Utility.GetKey<Int16>("ApplicationId"))
        {
        }

        //Metodo para registrar en el log de errores
        public async void InsertErrorAsyc(string Class, string Method, string StoredProcedure, string ErrorMessage)
        {

            Response<int> Response = new Response<int>();
            string sp = "Logger.spErrorInsert";

            try
            {
                Response = await this.ExecuteAsync(sp, Utility.GetKey<Int16>("ApplicationId"), Class, Method, StoredProcedure, ErrorMessage);

                if (Response.StatusCode != "00")
                    throw new Exception(string.Format("{0}, {1}", Response.StatusCode, Response.Message));

            }
            catch (Exception)
            {

            }
        }

        //#region Configuracion de conexion Entity Framework

        //protected override void OnConfiguring(DbContextOptionsBuilder _dbContext)
        //{

        //   // _dbContext.UseSqlServer(DemetechLibrary.Connection.ConnectionManager.ConectionString);
        //    //_dbContext.UseSqlServer(configuration.GetConnectionString("Conexion"));
        //}

        //public virtual DbSet<Entidades.SECurrency> SECurrency { get; set; }

        //#endregion


        //#region Consulta con ADO.NET

        //private SqlCommand _sqlComand = null;
        //private DataSet _DataSet = null;
        //private SqlDataAdapter _sqlDataAdapter = null;       


        ////Metodo generico que retorna una lista de tipo T (Generic) desde un datatable
        //private static List<T> ConvertDataTable<T>(DataTable dt)
        //{
        //    List<T> data = new List<T>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        T item = GetItem<T>(row);
        //        data.Add(item);
        //    }
        //    return data;
        //}


        ////Metodo generico que retorna un objeto de tipo Generic desde un datarow
        //private static T GetItem<T>(DataRow dr)
        //{
        //    Type temp = typeof(T);
        //    T obj = Activator.CreateInstance<T>();

        //    foreach (DataColumn column in dr.Table.Columns)
        //    {
        //        foreach (PropertyInfo pro in temp.GetProperties())
        //        {
        //            try
        //            {
        //                if (pro.Name == column.ColumnName)
        //                    pro.SetValue(obj, dr[column.ColumnName], null);
        //                else
        //                    continue;
        //            }
        //            catch (Exception)
        //            {

        //            }

        //        }
        //    }
        //    return obj;
        //}


        //public async Task<object> SqlExecuteScalar(string Query)
        //{

        //    using (SqlConnection cn = (SqlConnection)Database.GetDbConnection())
        //    {
        //        _sqlComand = new SqlCommand();
        //        _sqlComand.CommandText = Query;
        //        _sqlComand.CommandType = CommandType.Text;
        //        _sqlComand.Connection = cn;

        //        if (cn.State != ConnectionState.Open)
        //        {
        //            cn.Open();
        //        }

        //        return await _sqlComand.ExecuteScalarAsync();
        //    }

        //}

        //public async Task<object> SqlExecuteScalar(string sp, params object[] args)
        //{

        //    using (SqlConnection cn = (SqlConnection)Database.GetDbConnection())
        //    {

        //        _sqlComand = new SqlCommand();
        //        _sqlComand.CommandText = sp;
        //        _sqlComand.CommandType = CommandType.StoredProcedure;
        //        _sqlComand.Connection = cn;

        //        if (cn.State != ConnectionState.Open)
        //        {
        //            cn.Open();
        //        }

        //        SqlCommandBuilder.DeriveParameters(_sqlComand);

        //        for (int i = 1; i < _sqlComand.Parameters.Count; i++)
        //        {
        //            _sqlComand.Parameters[i].Value = args[i - 1];
        //        }


        //        return await _sqlComand.ExecuteScalarAsync();

        //    }

        //}

        //public List<T> SqlQuery<T>(string Query)
        //{

        //    using (SqlConnection cn = (SqlConnection)Database.GetDbConnection())
        //    {
        //        _sqlComand = new SqlCommand();
        //        _sqlComand.CommandText = Query;
        //        _sqlComand.CommandType = CommandType.Text;
        //        _sqlComand.Connection = cn;

        //        if (cn.State != ConnectionState.Open)
        //        {
        //            cn.Open();
        //        }

        //        _DataSet = new DataSet();
        //        _sqlDataAdapter = new SqlDataAdapter(_sqlComand);
        //        _sqlDataAdapter.Fill(_DataSet);

        //        return ConvertDataTable<T>(_DataSet.Tables[0].Copy());
        //    }

        //}


        //public List<T> SqlQuery<T>(string sp, params object[] args)
        //{

        //    using (SqlConnection cn = (SqlConnection)Database.GetDbConnection())
        //    {

        //        _sqlComand = new SqlCommand();
        //        _sqlComand.CommandText = sp;
        //        _sqlComand.CommandType = CommandType.StoredProcedure;
        //        _sqlComand.Connection = cn;

        //        if (cn.State != ConnectionState.Open)
        //        {
        //            cn.Open();
        //        }

        //        SqlCommandBuilder.DeriveParameters(_sqlComand);

        //        for (int i = 1; i < _sqlComand.Parameters.Count; i++)
        //        {
        //            _sqlComand.Parameters[i].Value = args[i - 1];
        //        }

        //        _DataSet = new DataSet();
        //        _sqlDataAdapter = new SqlDataAdapter(_sqlComand);
        //        _sqlDataAdapter.Fill(_DataSet);


        //        return ConvertDataTable<T>(_DataSet.Tables[0].Copy());

        //    }

        //}

        //#endregion

    }

}
