using System.Xml.Serialization;

namespace ParsingXmlToObjects.Models
{
    [XmlRoot("president")]
    public class President
    {
        [XmlAttribute("disk")]
        public string Disk { get; set; }
        [XmlAttribute("break")]
        public string Break { get; set; }
        [XmlAttribute("knock")]
        public string Knock { get; set; }
        [XmlAttribute("tune")]
        public string Tune { get; set; }
        [XmlAttribute("cousing")]
        public string Cousing { get; set; }
        [XmlText]
        public string InnerText { get; set; }
    }
}
