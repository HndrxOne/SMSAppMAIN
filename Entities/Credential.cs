using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Credential
    {
        public int Cre_codcredential { get; set; }
        public string Cre_projectid { get; set; }
        public string Cre_token { get; set; }
        public string Cre_domain { get; set; }
        public string Cre_phone { get; set; }
        public string Cre_status { get; set; }
        public string Cre_insertuser { get; set; }
        public Nullable<System.DateTime> Cre_insertdate { get; set; }
        public string Cre_insertterminal { get; set; }
        public string Cre_updateuser { get; set; }
        public Nullable<System.DateTime> Cre_updatedate { get; set; }
        public string Cre_updateterminal { get; set; }
    }
}
