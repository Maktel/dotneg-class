using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ParsingXmlToObjects.Models
{
    [XmlRoot("statue")]
    public class Statue
    {
        [XmlAttribute("worm")]
        public string Worm { get; set; }
        [XmlAttribute("concrete")]
        public string Concrete { get; set; }
        [XmlAttribute("shell")]
        public string Shell { get; set; }
        [XmlAttribute("needle")]
        public string Needle { get; set; }
        [XmlAttribute("litigation")]
        public string Litigation { get; set; }
        [XmlAttribute("overview")]
        public string Overview { get; set; }
        [XmlAttribute("assessment")]
        public string Assessment { get; set; }
        [XmlElement("president")]
        public List<President> Presidents { get; set; }
    }
}
