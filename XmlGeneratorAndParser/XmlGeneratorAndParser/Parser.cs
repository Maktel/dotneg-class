using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlGeneratorAndParser
{
    class Parser
    {
        private XmlDocument _xml;

        public Parser()
        {
        }

        public void LoadFromFile(string path)
        {
            _xml = new XmlDocument();
            _xml.Load(path);
        }

        public void Save(string path)
        {
            _xml.Save(path);
        }

        public string AsString()
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter) {Formatting = Formatting.Indented};
            _xml.WriteTo(xmlTextWriter);

            return stringWriter.ToString();
        }

        public string GetElementEffort()
        {
            XmlNode elEffort = _xml.DocumentElement?.SelectSingleNode("effort");
            return elEffort.Attributes.Count.ToString();
        }

        public List<String> GetElementChildren(string elementName)
        {
            List<string> elementChildren = new List<string>();
            XmlNode element = _xml.DocumentElement?.SelectSingleNode(elementName);
            XmlNodeList elementNodeList = element?.ChildNodes;
            foreach (XmlNode node in elementNodeList)
            {
                // exclude inner text node
                if (node.NodeType == XmlNodeType.Element)
                {
                    elementChildren.Add(node.Name + " -- " + node.Attributes?["hour"].Value + ":" + node.Attributes?["minute"].Value);
                }
            }

            return elementChildren;
        }

        public void ModifyEffortInnerText()
        {
            XmlNode elEffort = _xml.DocumentElement?.SelectSingleNode("effort");
            elEffort.InnerText = "physics";
        }
    }
}