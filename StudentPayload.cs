using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleRestApiClientApplication
{
   public  class StudentPayload
    {
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "street")]
        public string street { get; set; }
        [DataMember(Name = "city")]
        public string city { get; set; }
        [DataMember(Name = "state")]
        public string state { get; set; }
        [DataMember(Name = "zip")]
        public string zip { get; set; }
    }
}
