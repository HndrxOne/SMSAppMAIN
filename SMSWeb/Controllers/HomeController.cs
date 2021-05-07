using SMSWeb.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSWeb.Controllers
{
    public class HomeController : Controller
    {
        static WebApiRepository objService = new WebApiRepository();

        [Route("Textmessage")]
        public ActionResult Index()
        {
            return View(Grid());
        }

        [HttpPost]
        public ActionResult Send(string To, string Message)
        {
            HttpResponseMessage response = objService.GetResponse("api/SetMessage?To=" + To + "&Message=" + Message);
            response.EnsureSuccessStatusCode();
            int Success = response.Content.ReadAsAsync<int>().Result;
            
            return View("Index",Grid());

        }

        private IEnumerable<Entities.MessageGrid> Grid()
        {
            HttpResponseMessage response = objService.GetResponse("api/GetMessage");
            response.EnsureSuccessStatusCode();
            IEnumerable<Entities.MessageGrid> Grid = response.Content.ReadAsAsync<IEnumerable<Entities.MessageGrid>>().Result;

            return Grid;

        }
    }
}