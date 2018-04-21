using System.Xml.Serialization;

// <insurance share="scrap" bland="pop" past="independent" memorandum="stone" pop="boot">discrimination</insurance>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("insurance")]
    public class Insurance
    {
        [XmlAttribute("bland")] public string Bland;

        [XmlText] public string InnerText;

        [XmlAttribute("memorandum")] public string Memorandum;

        [XmlAttribute("past")] public string Past;

        [XmlAttribute("pop")] public string Pop;

        [XmlAttribute("share")] public string Share;
    }
}