using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <dangerous photograph="quiet">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("dangerous")]
    public class Dangerous
    {
        [XmlAttribute("photograph")]
        public string Photograph;
        [XmlElement("motivation")]
        public List<Motivation> Motivations;
    }
}
