using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SopApi.Model.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SopApi.Model.Negocio
{
    public class SNError
    {

        private Int16 _ApplicationId = 0;

        public SNError()
        {
            _ApplicationId = SNUtility.GetKey<Int16>("ApplicationId");
        }

        public async void InserErrorLog(string Class, string Method, string StoredProcedure, string ErrorMessage)
        {

            string sp = "Logger.spErrorInsert {0}, {1}, {2}, {3}, {4}";


            try
            {
                using (SDConexion cn = new SDConexion())
                {
                    await cn.Database.ExecuteSqlRawAsync(sp, _ApplicationId, Class, Method, StoredProcedure, ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
