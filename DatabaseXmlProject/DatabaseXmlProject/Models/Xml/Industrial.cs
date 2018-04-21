using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <industrial taxi="old" publication="hurt" informal="belong">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("industrial")]
    public class Industrial
    {
        [XmlAttribute("taxi")]
        public string Taxi;
        [XmlAttribute("publication")]
        public string Publication;
        [XmlAttribute("informal")]
        public string Informal;
        [XmlElement("dangerous")]
        public List<Dangerous> Dangerouses;
    }
}
