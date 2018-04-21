using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("root")]
    public class Root
    {
        [XmlElement("currency")] public Currency Currency;
        [XmlElement("visit")] public Visit Visit;
        [XmlElement("law")] public Law Law;
        [XmlElement("industrial")] public Industrial Industrial;
        [XmlElement("fax")] public Fax Fax;
    }
}