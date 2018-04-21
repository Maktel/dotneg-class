using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <motivation matter="stuff" progressive="wire">headline</motivation>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("motivation")]
    public class Motivation
    {
        [XmlAttribute("matter")]
        public string Matter;
        [XmlAttribute("progressive")]
        public string Progressive;
        [XmlText]
        public string InnerText;
    }
}
