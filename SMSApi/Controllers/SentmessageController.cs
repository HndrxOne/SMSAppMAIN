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
    public class SentmessageController : ApiController
    {
        [Route("api/SetMessage")]
        [HttpGet]
        public IHttpActionResult SetMessage(string To, string Message)
        {
            int objRecords = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    var objCredential = new Domain.Credential().getSpecificRecord(1);
                    var objResponse = new SMS().Send(To, Message, objCredential);

                    if (objResponse.Count > 0)
                        objRecords = fnSetData(objResponse);

                    return Created("Records", objRecords);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Route("api/GetMessage")]
        [HttpGet]
        public IHttpActionResult GetMessage()
        {
            Dictionary<string, object> objReturn = new Dictionary<string, object>();
            objReturn.Add("ErrorMessage", "");

            try
            {
                if (ModelState.IsValid)
                {
                    var ienMessage = new Domain.Message().getAllRecordsByQuery(x => x.mes_status == "A");
                    var lstMessage = ienMessage.Select(x => x.Mes_codmessage).ToList();
                    var ienSent = new Domain.Sent().getAllRecordsByQuery(x => lstMessage.Contains((int)x.sen_codmessage));

                    var objMessageGrid = (
                            from mes in ienMessage
                            join sen in ienSent
                            on mes.Mes_codmessage equals sen.Sen_codmessage
                            orderby mes.Mes_codmessage descending
                            select new Entities.MessageGrid()
                            {
                                Mes_codmessage = mes.Mes_codmessage,
                                Mes_message = mes.Mes_message,
                                Mes_to = mes.Mes_to,
                                Sen_sent = sen.Sen_sent,
                                Sen_twiliocode = sen.Sen_twiliocode
                            }
                        );

                    return Created("Records", objMessageGrid);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private int fnSetData(IEnumerable<Entities.SMSReturn> objSMSReturn)
        {
            try
            {
                foreach (var Item in objSMSReturn)
                {
                    var objMsg = new Entities.Message();
                    var objSent = new Entities.Sent();

                    objMsg.Mes_codmessage = 0;
                    objMsg.Mes_created = Item.DateCreated;
                    objMsg.Mes_to = Item.To;
                    objMsg.Mes_message = Item.Body;
                    objMsg.Mes_status = "A";
                    objMsg.Mes_insertuser = "UsrApp";
                    objMsg.Mes_insertdate = DateTime.Now;
                    objMsg.Mes_insertterminal = "Local01";

                    var intCodeMsg = new Domain.Message().Add(objMsg);

                    objSent.Sen_codsent = 0;
                    objSent.Sen_codmessage = intCodeMsg;
                    objSent.Sen_sent = DateTime.Now;
                    objSent.Sen_twiliocode = Item.Sid;
                    objSent.Sen_status = "A";
                    objSent.Sen_insertuser = "UsrApp";
                    objSent.Sen_insertdate = DateTime.Now;
                    objSent.Sen_insertterminal = "Local01";

                    var intCodeSent = new Domain.Sent().Add(objSent);

                }

                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
