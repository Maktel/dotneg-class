using System.Collections.Generic;
using System.Xml.Serialization;

// <law step="fence" lesson="crystal">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("law")]
    public class Law
    {
        [XmlElement("hall")] public List<Hall> Halls;
        [XmlAttribute("lesson")] public string Lesson;
        [XmlAttribute("step")] public string Step;
    }
}