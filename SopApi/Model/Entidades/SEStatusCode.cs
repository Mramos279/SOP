using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SopApi.Model.Entidades
{
    public enum  SEStatusCode
    {
        //Status code que se utilizará en caso de error
        Error = 0, 
        
        //Informacion que detalla del porque no se actualizo o insertó el registro cuando no es un error (internal server error) Valor = 1
        Info,

        //Status code que se utilizará en caso de Insert exitoso valor = 2
        Insert, 

        //status code que se utilizara en caseo de Update exitoso valor = 3
        Update, 

        //status code que se utilizará en caso que el registro ya exista, 
        //tanto en actualizacion o insercion de registros valor = 4
        Exist
    }
}
