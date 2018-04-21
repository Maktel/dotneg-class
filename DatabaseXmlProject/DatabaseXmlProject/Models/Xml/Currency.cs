using System.Collections.Generic;
using System.Xml.Serialization;

// <currency requirement="power" fraud="fog" sugar="quarter" player="ban" capitalism="lemon" undermine="default" birthday="adequate">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("currency")]
    public class Currency
    {
        [XmlAttribute("birthday")] public string Birthday;
        [XmlAttribute("capitalism")] public string Capitalism;
        [XmlAttribute("fraud")] public string Fraud;
        [XmlAttribute("player")] public string Player;
        [XmlElement("reception")] public List<Reception> Receptions;
        [XmlAttribute("requirement")] public string Requiremenet;
        [XmlAttribute("sugar")] public string Sugar;
        [XmlAttribute("undermine")] public string Undermine;
    }
}