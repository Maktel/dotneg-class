using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.SqlServer.Server;

// <visit rally="way" oral="ask" break="torch" importance="monarch" follow="admission" hungry="constellation" hurt="accident">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("visit")]
    public class Visit
    {
        [XmlAttribute("rally")]
        public string Rally;
        [XmlAttribute("oral")]
        public string Oral;
        [XmlAttribute("break")]
        public string Break;
        [XmlAttribute("importance")]
        public string Importance;
        [XmlAttribute("follow")]
        public string Follow;
        [XmlAttribute("hungry")]
        public string Hungry;
        [XmlAttribute("hurt")]
        public string Hurt;
        [XmlElement("pressure")]
        public List<Pressure> Pressures;
    }
}
