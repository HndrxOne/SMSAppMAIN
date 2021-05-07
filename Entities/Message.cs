using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Message
    {
        public int Mes_codmessage { get; set; }
        public Nullable<System.DateTime> Mes_created { get; set; }
        public string Mes_to { get; set; }
        public string Mes_message { get; set; }
        public string Mes_status { get; set; }
        public string Mes_insertuser { get; set; }
        public Nullable<System.DateTime> Mes_insertdate { get; set; }
        public string Mes_insertterminal { get; set; }
        public string Mes_updateuser { get; set; }
        public Nullable<System.DateTime> Mes_updatedate { get; set; }
        public string Mes_updateterminal { get; set; }
    }
}
