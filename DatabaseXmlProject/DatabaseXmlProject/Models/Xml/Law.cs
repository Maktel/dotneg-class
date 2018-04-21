using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <law step="fence" lesson="crystal">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("law")]
    public class Law
    {
        [XmlAttribute("step")] public string Step;
        [XmlAttribute("lesson")] public string Lesson;
        [XmlElement("hall")] public List<Hall> Halls;
    }
}