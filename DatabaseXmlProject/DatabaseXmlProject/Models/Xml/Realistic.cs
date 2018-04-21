using System.Collections.Generic;
using System.Xml.Serialization;

// <realistic swing="payment" fit="glow" bargain="pan" philosophical="graphic" slime="heroin" ceiling="think" conspiracy="spring">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("realistic")]
    public class Realistic
    {
        [XmlAttribute("bargain")] public string Bargain;

        [XmlAttribute("ceiling")] public string Ceiling;

        [XmlAttribute("conspiracy")] public string Conspiracy;

        [XmlElement("disappoint")] public List<Disappoint> Disappoints;

        [XmlAttribute("fit")] public string Fit;

        [XmlAttribute("philosophical")] public string Philosophical;

        [XmlAttribute("slime")] public string Slime;

        [XmlAttribute("swing")] public string Swing;
    }
}