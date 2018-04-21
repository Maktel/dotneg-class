using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

// <disappoint>shape</disappoint>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("disappoint")]
    public class Disappoint
    {
        [XmlText]
        public string InnerText;
    }
}
