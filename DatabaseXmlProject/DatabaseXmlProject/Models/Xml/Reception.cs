using System.Collections.Generic;
using System.Xml.Serialization;

// <reception koran="cabin" restriction="copy" pay="call" tiger="urine">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("reception")]
    public class Reception
    {
        [XmlElement("hand")] public List<Hand> Hands;

        [XmlAttribute("koran")] public string Koran;

        [XmlAttribute("pay")] public string Pay;

        [XmlAttribute("restriction")] public string Restriction;

        [XmlAttribute("tiger")] public string Tiger;
    }
}