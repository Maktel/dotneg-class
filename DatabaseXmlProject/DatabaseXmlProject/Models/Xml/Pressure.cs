using System.Collections.Generic;
using System.Xml.Serialization;

// <pressure post="critical" application="water" consensus="memorable">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("pressure")]
    public class Pressure
    {
        [XmlAttribute("application")] public string Application;

        [XmlAttribute("consensus")] public string Consensus;

        [XmlAttribute("post")] public string Post;

        [XmlElement("put")] public List<Put> Puts;
    }
}