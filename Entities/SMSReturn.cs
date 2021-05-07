using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SMSReturn

    {
        public string Status { get; set;}
        public DateTime? DateSent { get; set;}
        public DateTime? DateUpdated { get; set;}
        public DateTime? DateCreated { get; set;}
        public string Body { get; set;}
        public string ApiVersion { get; set;}
        public string AccountSid { get; set;}
        public string ErrorMessage { get; set;}
        public string From { get; set;}
        public string MessagingServiceSid { get; set;}
        public string NumMedia { get; set;}
        public string NumSegments { get; set;}
        public decimal? Price { get; set;}
        public string PriceUnit { get; set;}
        public string Sid { get; set;}
        public int? ErrorCode { get; set;}
        public Dictionary<string, string> SubresourceUris { get; set;}
        public string To { get; set;}
        public string Uri { get; set;}
        public string Direction { get; set;}

    }
}
