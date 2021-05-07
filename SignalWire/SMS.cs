using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Linq;
using SignalWire.Relay.Messaging;

namespace SignalWire
{
    public class SMS
    {
        public List<Entities.SMSReturn> Send(string strTo, string strMessage, Entities.Credential objCredential)
        {
            try
            {

                string[] arrTo = strTo.Split(';');
                var objReturn = new List<Entities.SMSReturn>();

                TwilioClient.Init(
                      objCredential.Cre_projectid
                    , objCredential.Cre_token
                    , new Dictionary<string, object> { ["signalwireSpaceUrl"] = objCredential.Cre_domain });

                foreach(var item in arrTo)
                {
                    var message = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber(objCredential.Cre_phone),
                        body: strMessage,
                        to: new Twilio.Types.PhoneNumber("+" + item.Trim())
                    );
                    objReturn.Add(Map(message));
                }

                return objReturn;

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Entities.SMSReturn Map (MessageResource objMsg)
        {
            var objReturn = new Entities.SMSReturn();

            objReturn.Status = objMsg.Status.ToString();
            objReturn.DateSent = objMsg.DateSent;
            objReturn.DateUpdated = objMsg.DateUpdated;
            objReturn.DateCreated = objMsg.DateCreated;
            objReturn.Body = objMsg.Body;
            objReturn.ApiVersion = objMsg.ApiVersion;
            objReturn.AccountSid = objMsg.AccountSid;
            objReturn.ErrorMessage = objMsg.ErrorMessage;
            objReturn.From = objMsg.From.ToString();
            objReturn.MessagingServiceSid = objMsg.MessagingServiceSid;
            objReturn.NumMedia = objMsg.NumMedia;
            objReturn.NumSegments = objMsg.NumSegments;
            objReturn.Price = objMsg.Price;
            objReturn.PriceUnit = objMsg.PriceUnit;
            objReturn.Sid = objMsg.Sid;
            objReturn.ErrorCode = objMsg.ErrorCode;
            objReturn.SubresourceUris = objMsg.SubresourceUris;
            objReturn.To = objMsg.To;
            objReturn.Uri = objMsg.Uri;
            objReturn.Direction = objMsg.Direction.ToString();

            return objReturn;
        }
    }
}
