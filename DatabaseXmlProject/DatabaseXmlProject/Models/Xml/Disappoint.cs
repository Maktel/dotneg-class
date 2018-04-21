using System.Xml.Serialization;

// <disappoint>shape</disappoint>

namespace DatabaseXmlProject.Models.Xml
{
    [XmlRoot("disappoint")]
    public class Disappoint
    {
        [XmlText] public string InnerText;
    }
}