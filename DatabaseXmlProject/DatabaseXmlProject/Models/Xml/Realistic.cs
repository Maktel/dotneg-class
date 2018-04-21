using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

// <realistic swing="payment" fit="glow" bargain="pan" philosophical="graphic" slime="heroin" ceiling="think" conspiracy="spring">

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("realistic")]
    public class Realistic
    {
        [XmlAttribute("swing")]
        public string Swing;
        [XmlAttribute("fit")]
        public string Fit;
        [XmlAttribute("bargain")]
        public string Bargain;
        [XmlAttribute("philosophical")]
        public string Philosophical;
        [XmlAttribute("slime")]
        public string Slime;
        [XmlAttribute("ceiling")]
        public string Ceiling;
        [XmlAttribute("conspiracy")]
        public string Conspiracy;
        [XmlElement("disappoint")]
        public List<Disappoint> Disappoints;
    }
}
