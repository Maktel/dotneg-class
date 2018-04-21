using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

// <insurance share="scrap" bland="pop" past="independent" memorandum="stone" pop="boot">discrimination</insurance>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("insurance")]
    public class Insurance
    {
        [XmlAttribute("share")]
        public string Share;
        [XmlAttribute("bland")]
        public string Bland;
        [XmlAttribute("past")]
        public string Past;
        [XmlAttribute("memorandum")]
        public string Memorandum;
        [XmlAttribute("pop")]
        public string Pop;
        [XmlText]
        public string InnerText;
    }
}
