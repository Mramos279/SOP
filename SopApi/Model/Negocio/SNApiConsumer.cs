using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SopApi.Model.Negocio
{
    public class SNApiConsumer
    {

        public enum TypeRequest {
            GET,
            POST,
            PUT,
            DELETE
        } 

        public T Request<T>(string RequestUrl, string Method, TypeRequest Type)
        {
            T temp = default(T);

            string url = string.Format("{0}, {1}", RequestUrl, Method);

            string method = "";

            switch (Type)
            {
                case TypeRequest.GET:
                    method = "GET";
                    break;
                case TypeRequest.POST:
                    method = "POST";
                    break;
                case TypeRequest.PUT:
                    method = "PUT";
                    break;
                case TypeRequest.DELETE:
                    method = "DELETE";
                    break;
                default:
                    break;
            }


            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.google.com");
            req.Method = method;
            var response = req.GetResponse();
            string webcontent;
            using (var strm = new StreamReader(response.GetResponseStream()))
            {
                webcontent = strm.ReadToEnd();
            }


            return temp;

        }

    }
}
