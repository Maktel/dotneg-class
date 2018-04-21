using System.Xml.Serialization;

// <motivation matter="stuff" progressive="wire">headline</motivation>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("motivation")]
    public class Motivation
    {
        [XmlText] public string InnerText;

        [XmlAttribute("matter")] public string Matter;

        [XmlAttribute("progressive")] public string Progressive;
    }
}