using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHIR_Client.Models
{
    public class Patient
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
