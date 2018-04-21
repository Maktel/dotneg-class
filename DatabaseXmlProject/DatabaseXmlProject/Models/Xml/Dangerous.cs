using System.Collections.Generic;
using System.Xml.Serialization;

// <dangerous photograph="quiet">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("dangerous")]
    public class Dangerous
    {
        [XmlElement("motivation")] public List<Motivation> Motivations;

        [XmlAttribute("photograph")] public string Photograph;
    }
}