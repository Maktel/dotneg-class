using System.Collections.Generic;
using System.Xml.Serialization;

// <hall population="professional" sea="doubt" widen="swipe" tongue="incident">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("hall")]
    public class Hall
    {
        [XmlElement("insurance")] public List<Insurance> Insurances;

        [XmlAttribute("population")] public string Population;

        [XmlAttribute("sea")] public string Sea;

        [XmlAttribute("tongue")] public string Tongue;

        [XmlAttribute("widen")] public string Widen;
    }
}