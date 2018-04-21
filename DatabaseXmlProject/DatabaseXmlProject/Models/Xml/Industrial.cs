using System.Collections.Generic;
using System.Xml.Serialization;

// <industrial taxi="old" publication="hurt" informal="belong">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("industrial")]
    public class Industrial
    {
        [XmlElement("dangerous")] public List<Dangerous> Dangerouses;

        [XmlAttribute("informal")] public string Informal;

        [XmlAttribute("publication")] public string Publication;

        [XmlAttribute("taxi")] public string Taxi;
    }
}