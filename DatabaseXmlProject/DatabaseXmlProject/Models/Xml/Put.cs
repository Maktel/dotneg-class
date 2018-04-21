using System.Xml.Serialization;

// <put demonstrate="cover">loyalty</put>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("put")]
    public class Put
    {
        [XmlAttribute("demonstrate")] public string Demonstrate;

        [XmlText] public string InnerText;
    }
}