using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <hand violent="exclusive" privilege="raise" obese="memorable">myth</hand>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("hand")]
    public class Hand
    {
        [XmlAttribute("violent")] public string Violent;
        [XmlAttribute("privilege")] public string Privilege;
        [XmlAttribute("obese")] public string Obese;
        [XmlText] public string InnerText;
    }
}