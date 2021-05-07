using SMSWeb.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguridad;

namespace SMSWeb.Controllers
{
    public class UserController : Controller
    {
        static WebApiRepository objService = new WebApiRepository();

        [Route("User")]

        [Route("User/Verication/")]
        [HttpPost]
        public JsonResult Verication(string Usr, string Psw)
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();
            objReturn.Add("ErrorMessage", "");

            HttpResponseMessage response = objService.GetResponse("api/GetUser?User=" + Usr);
            response.EnsureSuccessStatusCode();
            Entities.User objUser = response.Content.ReadAsAsync<Entities.User>().Result;

            var seg = new Seguridad.Seg();

            if(Psw != seg.DesEncriptaPlus(objUser.Usr_pws)) {
                objReturn["ErrorMessage"] = "User or password incorrect!";
            }

            return Json(objReturn);

        }
    }
}