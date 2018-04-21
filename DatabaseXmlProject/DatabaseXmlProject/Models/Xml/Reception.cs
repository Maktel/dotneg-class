using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <reception koran="cabin" restriction="copy" pay="call" tiger="urine">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("reception")]
    public class Reception
    {
        [XmlAttribute("koran")]
        public string Koran;
        [XmlAttribute("restriction")]
        public string Restriction;
        [XmlAttribute("pay")]
        public string Pay;
        [XmlAttribute("tiger")]
        public string Tiger;
        [XmlElement("hand")]
        public List<Hand> Hands;
    }
}
