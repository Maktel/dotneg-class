using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <currency requirement="power" fraud="fog" sugar="quarter" player="ban" capitalism="lemon" undermine="default" birthday="adequate">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("currency")]
    public class Currency
    {
        [XmlAttribute("requirement")] public string Requiremenet;
        [XmlAttribute("fraud")] public string Fraud;
        [XmlAttribute("sugar")] public string Sugar;
        [XmlAttribute("player")] public string Player;
        [XmlAttribute("capitalism")] public string Capitalism;
        [XmlAttribute("undermine")] public string Undermine;
        [XmlAttribute("birthday")] public string Birthday;
        [XmlElement("reception")] public List<Reception> Receptions;
    }
}