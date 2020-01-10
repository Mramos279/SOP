using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SopApi.Model.Servicios
{
    public class RequestApi
    {
        //Enumeradores
        public enum MethodType : byte { GET = 0, POST, PUT, DELETE };
        public enum ContentType : byte { JSON = 0, OCTET_STREAM, HTML, XML };

        //Metodo Asyncrono 
        public async Task<T> SendRequestAsync<T>(string Url, string Method, MethodType MethodType, ContentType ContentType, object Data = null, IDictionary Headers = null)
        {

            T resultado = default(T);
            string _MethodType = null;
            string _ContentType = null;

            try
            {

                //Creamos el Objeto HttpRequest con la url Raiz y metodo
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", Url, Method)));


                //Definiendo el tipo de metodo
                switch ((byte)MethodType)
                {
                    case 0:
                        _MethodType = "GET";
                        break;
                    case 1:
                        _MethodType = "POST";
                        break;
                    case 2:
                        _MethodType = "PUT";
                        break;
                    case 3:
                        _MethodType = "DELETE";
                        break;
                }

                httpRequest.Method = _MethodType;

                //Definiendo el tipo de contenido que retornará la peticion
                switch ((byte)ContentType)
                {
                    case 0:
                        _ContentType = "application/json";
                        break;
                    case 1:
                        _ContentType = "application/octet-stream";
                        break;
                    case 2:
                        _ContentType = "text/html";
                        break;
                    case 3:
                        _ContentType = "application/xml";
                        break;
                }

                httpRequest.ContentType = _ContentType;


                //Agregando los header al httpRequest
                if (Headers != null && Headers.Count > 0)
                    foreach (DictionaryEntry item in Headers)
                        httpRequest.Headers.Add(item.Key.ToString(), item.Value.ToString());


                //Serializamos el objeto en formato json
                string dataJason = JsonConvert.SerializeObject(Data, Formatting.Indented);

                byte[] bytes = Encoding.UTF8.GetBytes(dataJason);

                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }

                //Definimos el httpwebResponse
                using (HttpWebResponse httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync())
                {
                    using (Stream stream = httpResponse.GetResponseStream())
                    {
                        string json = await (new StreamReader(stream)).ReadToEndAsync();

                        resultado = JsonConvert.DeserializeObject<T>(json);

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return resultado;

        }
    }
}
