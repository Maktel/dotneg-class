using System.Collections.Generic;
using System.Xml.Serialization;

// <visit rally="way" oral="ask" break="torch" importance="monarch" follow="admission" hungry="constellation" hurt="accident">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("visit")]
    public class Visit
    {
        [XmlAttribute("break")] public string Break;

        [XmlAttribute("follow")] public string Follow;

        [XmlAttribute("hungry")] public string Hungry;

        [XmlAttribute("hurt")] public string Hurt;

        [XmlAttribute("importance")] public string Importance;

        [XmlAttribute("oral")] public string Oral;

        [XmlElement("pressure")] public List<Pressure> Pressures;

        [XmlAttribute("rally")] public string Rally;
    }
}