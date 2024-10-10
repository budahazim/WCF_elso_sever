using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCF_elso_sever.Models
{
    [DataContract]
    public class Eloado
    {
        [DataMember]
        public int eloadoAz { get; set; }
        [DataMember]
        public string eloadoName { get; set; }

        public override string ToString()
        {
            return $"{eloadoAz};{eloadoName}";
        }
    }
}