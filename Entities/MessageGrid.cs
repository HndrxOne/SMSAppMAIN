using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MessageGrid
    {
        [DisplayName("Code message")]
        public int Mes_codmessage { get; set; }
        
        [DisplayName("Phone number")]
        public string Mes_to { get; set; }
        
        [DisplayName("Message")]
        public string Mes_message { get; set; }
        
        [DisplayName("Sent")]
        public Nullable<System.DateTime> Sen_sent { get; set; }

        [DisplayName("Twilio")]
        public string Sen_twiliocode { get; set; }

    }
}
