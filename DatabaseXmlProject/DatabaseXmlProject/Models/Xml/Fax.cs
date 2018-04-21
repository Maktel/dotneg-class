using System.Collections.Generic;
using System.Xml.Serialization;

// <fax>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("fax")]
    public class Fax
    {
        [XmlElement("realistic")] public List<Realistic> Realistics;
    }
}