using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiConsumer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SopApi.Model.Entidades;
using SopApi.Model.Servicios;

namespace SopApi.Controllers
{
    [Route("Services")]
    [ApiController]
    public class SecurityController : ControllerBase
    {

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SERequestLogin User)
        {

            SEResponseLogin Response = new SEResponseLogin();

            try
            {
                RequestApi _RequestApi = new RequestApi();
                string Url = Utility.GetKey<string>("Url");

                Response = await _RequestApi.SendRequestAsync<SEResponseLogin>(Url, "Login", RequestApi.MethodType.POST, RequestApi.ContentType.JSON, User);

                switch (Response.StatusCode)
                {
                    case "03":
                        return StatusCode(500, Response);
                    case "04":
                    case "05":
                        return Unauthorized(Response);
                    default:
                        return Ok(Response);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = "03";
                Response.Message = ex.Message;

                return StatusCode(500, Response);
            }

        }

        [HttpPost("GetMenu")]
        public async Task<IActionResult> GetMenu()
        {

            Response<List<SEMenu>> Response = new Response<List<SEMenu>>();

            try
            {
                RequestApi _RequestApi = new RequestApi();
                string Url = Utility.GetKey<string>("Url");

                System.Collections.Specialized.ListDictionary Header = new System.Collections.Specialized.ListDictionary();

                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var Token))
                {
                    Header.Add("Authorization", Token);
                }

                Response = await _RequestApi.SendRequestAsync<Response<List<SEMenu>>>(Url, "GetMenu", RequestApi.MethodType.POST, RequestApi.ContentType.JSON, null, Header);

                switch (Response.StatusCode)
                {
                    case "03":
                        return StatusCode(500, Response);
                    case "04":
                    case "05":
                        return Unauthorized(Response);
                    default:
                        return Ok(Response);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = "03";
                Response.Message = ex.Message;

                return StatusCode(500, Response);
            }

        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser()
        {

            Response<SEUser> Response = new Response<SEUser>();

            try
            {
                RequestApi _RequestApi = new RequestApi();
                string Url = Utility.GetKey<string>("Url");

                System.Collections.Specialized.ListDictionary Header = new System.Collections.Specialized.ListDictionary();

                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var Token))
                {
                    Header.Add("Authorization", Token);
                }

                Response = await _RequestApi.SendRequestAsync<Response<SEUser>>(Url, "GetUser", RequestApi.MethodType.POST, RequestApi.ContentType.JSON, null, Header);

                switch (Response.StatusCode)
                {
                    case "03":
                        return StatusCode(500, Response);
                    case "04":
                    case "05":
                        return Unauthorized(Response);
                    default:
                        return Ok(Response);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = "03";
                Response.Message = ex.Message;

                return StatusCode(500, Response);
            }

        }

        [HttpPost("RequestChange")]
        public async Task<IActionResult> RequestChange(SERequestChangePassword Request)
        {

            SEResponseChangePassword Response = new SEResponseChangePassword();

            try
            {
                RequestApi _RequestApi = new RequestApi();
                string Url = Utility.GetKey<string>("Url");

                Response = await _RequestApi.SendRequestAsync<SEResponseChangePassword>(Url, "RequestChange", RequestApi.MethodType.POST, RequestApi.ContentType.JSON, Request);

                switch (Response.StatusCode)
                {
                    case "03":
                        return StatusCode(500, Response);
                    default:
                        return Ok(Response);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = "03";
                Response.Message = ex.Message;

                return StatusCode(500, Response);
            }

        }

        [HttpPost("ConfirmChange")]
        public async Task<IActionResult> ConfirmChange(SERequestConfirmChange Request)
        {

            SEResponseConfirmChange Response = new SEResponseConfirmChange();

            try
            {
                RequestApi _RequestApi = new RequestApi();
                string Url = Utility.GetKey<string>("Url");

                Response = await _RequestApi.SendRequestAsync<SEResponseConfirmChange>(Url, "ConfirmChange", RequestApi.MethodType.POST, RequestApi.ContentType.JSON, Request);

                switch (Response.StatusCode)
                {
                    case "03":
                        return StatusCode(500, Response);
                    default:
                        return Ok(Response);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = "03";
                Response.Message = ex.Message;

                return StatusCode(500, Response);
            }

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(SERequestNewPassword Request)
        {

            SEResponseNewPassword Response = new SEResponseNewPassword();

            try
            {
                RequestApi _RequestApi = new RequestApi();
                string Url = Utility.GetKey<string>("Url");

                System.Collections.Specialized.ListDictionary Header = new System.Collections.Specialized.ListDictionary();

                if (HttpContext.Request.Headers.TryGetValue("Authorization", out var Token))
                {
                    Header.Add("Authorization", Token);
                }

                Response = await _RequestApi.SendRequestAsync<SEResponseNewPassword>(Url, "ChangePassword", RequestApi.MethodType.POST, RequestApi.ContentType.JSON, Request, Header);

                switch (Response.StatusCode)
                {
                    case "03":
                        return StatusCode(500, Response);
                    case "04":
                    case "05":
                        return Unauthorized(Response);
                    default:
                        return Ok(Response);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = "03";
                Response.Message = ex.Message;

                return StatusCode(500, Response);
            }

        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile()
        {

            string ImagenUrl = "";

            try
            {
                //UrlMultimedia donde se guardará la imagen
                string UrlMultimedia = Utility.GetKey<string>("UrlMultimedia");

                //Obtenemos el archivo
                var _File = HttpContext.Request.Form.Files.Count > 0 ?
                    HttpContext.Request.Form.Files[0] : null;

                if (_File != null && _File.Length > 0)
                {

                    //si no existe el directorio se crea
                    if (!System.IO.Directory.Exists(Path.Combine(UrlMultimedia)))
                    {
                        System.IO.Directory.CreateDirectory(Path.Combine(UrlMultimedia));
                    }

                    //Obtenemos la informacion del archivo
                    FileInfo FileInfo = new FileInfo(_File.FileName);

                    //Definimos un nombre
                    DateTime GetDate = DateTime.Now;

                    string NombreArchivo = GetDate.Year.ToString().PadLeft(4, '0')
                                         + GetDate.Month.ToString().PadLeft(2, '0')
                                         + GetDate.Day.ToString().PadLeft(2, '0')
                                         + GetDate.Hour.ToString().PadLeft(2, '0')
                                         + GetDate.Minute.ToString().PadLeft(2, '0')
                                         + GetDate.Second.ToString().PadLeft(2, '0');

                    //creamos la ruta destino con el nuevo nombre y la extencion
                    ImagenUrl = Path.Combine(UrlMultimedia, string.Format("{0}{1}", NombreArchivo, FileInfo.Extension));

                    using (var stream = System.IO.File.Create(ImagenUrl))
                    {
                       await _File.CopyToAsync(stream);                        
                    }
                }
            }
            catch (Exception ex)
            {
                SopApi.Model.Datos.SDConexion cn = new Model.Datos.SDConexion(HttpContext);
                cn.InsertErrorAsyc("SecurityController", "public Task<string> UploadFile()", "", ex.Message);
                throw ex;
            }

            return ImagenUrl;

        }

    }
}