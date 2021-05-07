using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sent
    {
        public int Sen_codsent { get; set; }
        public Nullable<int> Sen_codmessage { get; set; }
        public Nullable<System.DateTime> Sen_sent { get; set; }
        public string Sen_twiliocode { get; set; }
        public string Sen_status { get; set; }
        public string Sen_insertuser { get; set; }
        public Nullable<System.DateTime> Sen_insertdate { get; set; }
        public string Sen_insertterminal { get; set; }
        public string Sen_updateuser { get; set; }
        public Nullable<System.DateTime> Sen_updatedate { get; set; }
        public string Sen_updateterminal { get; set; }
    }
}
