using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlGeneratorAndParser
{
    class Generator
    {
        public Generator()
        {
        }

        private XmlDocument _xml;

        public string AsString()
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter) {Formatting = Formatting.Indented};
            _xml.WriteTo(xmlTextWriter);

            return stringWriter.ToString();
        }

        public void Generate2()
        {
            _xml = new XmlDocument();
            GenerateHead();

            XmlElement rootElement = _xml.CreateElement("root");
            _xml.AppendChild(rootElement);

            XmlElement principleElement = _xml.CreateElement("principle");
            rootElement.AppendChild(principleElement);
            principleElement.InnerText = "1404677380.1897664";
            XmlAttribute particularlyAttribute = _xml.CreateAttribute("particularly");
            particularlyAttribute.Value = "great";
            principleElement.Attributes.Append(particularlyAttribute);

            XmlElement includeElement = _xml.CreateElement("include");
            rootElement.AppendChild(includeElement);
            XmlAttribute airAttribute = _xml.CreateAttribute("air");
            airAttribute.Value = "growth";
            includeElement.Attributes.Append(airAttribute);

            XmlElement bottleElement = _xml.CreateElement("bottle");
            includeElement.AppendChild(bottleElement);
            bottleElement.InnerText = "1095962081.3495286";
            XmlAttribute selectAttribute = _xml.CreateAttribute("select");
            selectAttribute.Value = "powder";
            bottleElement.Attributes.Append(selectAttribute);

            XmlElement lonelyElement = _xml.CreateElement("lonely");
            includeElement.AppendChild(lonelyElement);

            XmlElement peopleElement = _xml.CreateElement("people");
            lonelyElement.AppendChild(peopleElement);
            peopleElement.InnerText = "frighten";

            XmlElement laidElement = _xml.CreateElement("laid");
            lonelyElement.AppendChild(laidElement);
            XmlAttribute fenceAttribute = _xml.CreateAttribute("fence");
            fenceAttribute.Value = "zoo";
            laidElement.Attributes.Append(fenceAttribute);
            laidElement.InnerText = "-82700906.25475245";

            XmlElement doingElement = _xml.CreateElement("doing");
            lonelyElement.AppendChild(doingElement);
            doingElement.InnerText = "which";
            XmlAttribute aliveAttribute = _xml.CreateAttribute("alive");
            aliveAttribute.Value = "drop";
            doingElement.Attributes.Append(aliveAttribute);

            XmlElement universeElement = _xml.CreateElement("universe");
            includeElement.AppendChild(universeElement);
            universeElement.InnerText = "sale";

            XmlElement thanElement = _xml.CreateElement("than");
            rootElement.AppendChild(thanElement);
            XmlAttribute identityAttribute = _xml.CreateAttribute("identity");
            identityAttribute.Value = "harbor";
            thanElement.Attributes.Append(identityAttribute);
            thanElement.InnerText = "165427654.65864";
        }

        public void Generate()
        {
            _xml = new XmlDocument();
            GenerateHead();

            XmlElement root = _xml.CreateElement("root");
            _xml.AppendChild(root);

            XmlElement elEffort = _xml.CreateElement("effort");
            elEffort.InnerText = "mathematics";
            root.AppendChild(elEffort);

            XmlElement elBreathe = _xml.CreateElement("breathe");
            XmlAttribute elBreateAttribute = _xml.CreateAttribute("machine");
            elBreateAttribute.Value = "home";
            elBreathe.Attributes.Append(elBreateAttribute);
            root.AppendChild(elBreathe);

            XmlElement elDo = _xml.CreateElement("do");
            elDo.InnerText = "main";
            elBreathe.AppendChild(elDo);

//            AppendMultipleElements(elDo, 5, "auto_gen");
            AppendMultipleElements(elDo, 3);

            XmlElement elJungle = _xml.CreateElement("jungle");
            XmlAttribute elJungleAttribute = _xml.CreateAttribute("outer");
            elJungleAttribute.Value = "sudden";
            elJungle.Attributes.Append(elJungleAttribute);
            elJungle.InnerText = "-2103654072.5085454";
            elBreathe.AppendChild(elJungle);
        }

        public void Save(string filepath)
        {
            _xml?.Save(filepath);
        }

        private void GenerateHead()
        {
            XmlDeclaration decl = _xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = _xml.DocumentElement;
            _xml.InsertBefore(decl, root);
        }

        private void AppendMultipleElements(XmlElement root, int count, string baseName)
        {
            for (int i = 0; i < count; ++i)
            {
                XmlElement e = _xml.CreateElement(baseName + i);
                root.AppendChild(e);
            }
        }

        private void AppendMultipleElements(XmlElement root, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                root.AppendChild(GenerateDateNode(i));
            }
        }

        public XmlElement GenerateDateNode(int counter = 0)
        {
            XmlElement dateElement = _xml.CreateElement("date" + counter);

            XmlAttribute hourAttribute = _xml.CreateAttribute("hour");
            hourAttribute.Value = DateTime.Now.Hour.ToString();
            dateElement.Attributes.Append(hourAttribute);

            XmlAttribute minuteAttribute = _xml.CreateAttribute("minute");
            minuteAttribute.Value = DateTime.Now.Minute.ToString();
            dateElement.Attributes.Append(minuteAttribute);
            //            dateElement.Attributes["hour"].Value = DateTime.Now.Hour.ToString();
//            dateElement.Attributes["minute"].Value = DateTime.Now.Minute.ToString();

            return dateElement;
        }
    }
}