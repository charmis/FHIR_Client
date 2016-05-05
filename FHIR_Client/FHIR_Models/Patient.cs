using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHIR_Client.FHIR_Models
{
    public class Bundle
    {
        public string resourceType { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public int total { get; set; }
        public Link[] link { get; set; }
        public Entry[] entry { get; set; }
    }

    public class Link
    {
        public string relation { get; set; }
        public string url { get; set; }
    }

    public class Entry
    {
        public string fullUrl { get; set; }
        public Resource resource { get; set; }
    }

    public class Resource
    {
        public string resourceType { get; set; }
        public string id { get; set; }
        public Meta meta { get; set; }
        public Text text { get; set; }
        public Identifier[] identifier { get; set; }
        public bool active { get; set; }
        public Name[] name { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public Managingorganization managingOrganization { get; set; }
    }

    public class Meta
    {
        public string versionId { get; set; }
        public DateTime lastUpdated { get; set; }
    }

    public class Text
    {
        public string status { get; set; }
        public string div { get; set; }
    }

    public class Managingorganization
    {
        public string reference { get; set; }
    }

    public class Identifier
    {
        public Type type { get; set; }
        public string system { get; set; }
        public string value { get; set; }
    }

    public class Type
    {
        public Coding[] coding { get; set; }
    }

    public class Coding
    {
        public string system { get; set; }
        public string code { get; set; }
    }

    public class Name
    {
        public string use { get; set; }
        public string[] family { get; set; }
        public string[] given { get; set; }
    }



}