using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entities;
using Domain;
using SignalWire;
using System.Data.Entity.Core.Objects;

namespace SMSApi.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser(string User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var objUser = new Domain.User().getAllRecordsByQuery(x =>
                    x.usr_status == "A"
                    && x.usr_username == User).FirstOrDefault();

                    return Created("Records", objUser);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
