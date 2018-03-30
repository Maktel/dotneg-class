using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

//  <appropriate tail="display" jump="mixture" activate="electron" thinker="form" reference="major">

namespace ParsingXmlToObjects.Models
{
    [XmlRoot("appropriate")]
    public class Appropriate
    {
        [XmlAttribute("tail")]
        public string Tail { get; set; }
        [XmlAttribute("jump")]
        public string Jump { get; set; }
        [XmlAttribute("activite")]
        public string Activate { get; set; }
        [XmlAttribute("thinker")]
        public string Thinker { get; set; }
        [XmlAttribute("reference")]
        public string Reference { get; set; }
        [XmlElement("statue")]
        public List<Statue> Statues { get; set; }
    }
}
