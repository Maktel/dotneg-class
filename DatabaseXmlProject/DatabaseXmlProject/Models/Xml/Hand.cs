using System.Xml.Serialization;

// <hand violent="exclusive" privilege="raise" obese="memorable">myth</hand>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("hand")]
    public class Hand
    {
        [XmlText] public string InnerText;
        [XmlAttribute("obese")] public string Obese;
        [XmlAttribute("privilege")] public string Privilege;
        [XmlAttribute("violent")] public string Violent;
    }
}