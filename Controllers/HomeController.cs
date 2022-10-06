using Callcenter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Callcenter.Controllers
{
    public class HomeController : Controller
    {

        #region IOndex

        public ActionResult Index(string cedula)
        {

            //Si la cedula viene vacia, pasamos la palabra null al procedimiento de almacenado
            if (string.IsNullOrEmpty(cedula))
            {
                cedula = "1";
            }

            var client = new HttpClient();

            ///Se define la Url y se agregan los parametros
            var uriBuilder = new UriBuilder("http://localhost:44386/api/WebService");

            var paramValues = HttpUtility.ParseQueryString(uriBuilder.Query);

            paramValues.Add("cedula", cedula);

            uriBuilder.Query = paramValues.ToString();

            //ejecutamos el WebService
            var response = client.GetAsync(uriBuilder.Uri).Result;

            //Obtenemos el jsonresult
            var result = response.Content.ReadAsStringAsync().Result;

            List<consulta> consulta = JsonConvert.DeserializeObject<List<consulta>>(result);

            return View(consulta);
        }

        #endregion
    }
}