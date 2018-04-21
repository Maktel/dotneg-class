using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <hall population="professional" sea="doubt" widen="swipe" tongue="incident">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("hall")]
    public class Hall
    {
        [XmlAttribute("population")]
        public string Population;
        [XmlAttribute("sea")]
        public string Sea;
        [XmlAttribute("widen")]
        public string Widen;
        [XmlAttribute("tongue")]
        public string Tongue;
        [XmlElement("insurance")]
        public List<Insurance> Insurances;
    }
}
