using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <pressure post="critical" application="water" consensus="memorable">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("pressure")]
    public class Pressure
    {
        [XmlAttribute("post")]
        public string Post;
        [XmlAttribute("application")]
        public string Application;
        [XmlAttribute("consensus")]
        public string Consensus;

        [XmlElement("put")]
        public List<Put> Puts;
    }
}
