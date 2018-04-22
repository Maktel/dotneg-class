using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Xml;
using System.Xml.Serialization;
using DatabaseXmlProject.Models.Database;
using DatabaseXmlProject.Models.GenericXml;
using Attribute = DatabaseXmlProject.Models.GenericXml.Attribute;

namespace DatabaseXmlProject
{
    internal static class Parser
    {
        public static T ObjectFromXmlFile<T>(string filepath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filepath))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static T ObjectFromXmlString<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xml))
            {
                return (T) serializer.Deserialize(reader);
            }
        }

        public static Element ElementFromXml(string filepath)
        {
            var xml = new XmlDocument();
            xml.Load(filepath);

            XmlNode rootNode = xml.DocumentElement;
            return ElementFromXmlNode(rootNode);
        }

        private static Element ElementFromXmlNode(XmlNode node)
        {
            Element e = new Element()
            {
                ElementId = Guid.NewGuid(),
                Name = node.Name,
                Children = new List<Element>(),
                Attributes = new List<Attribute>()
            };

            if (node.Attributes != null)
            {
                foreach (XmlAttribute nodeAttribute in node.Attributes)
                {
                    var attribute = new Attribute()
                    {
                        AttributeId = Guid.NewGuid(),
                        Name = nodeAttribute.Name,
                        Value = nodeAttribute.Value
                    };
                    e.Attributes.Add(attribute);
                }
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                // get inner text without all child nodes' inner text
                if (childNode is XmlText)
                {
                    e.InnerText = childNode.Value;
                    continue; // don't include text nodes in the Elements' structure
                }

                e.Children.Add(ElementFromXmlNode(childNode));
            }

            return e;
        }

        public static XmlDocument XmlFromElement(Element element)
        {
            XmlDocument xml = new XmlDocument();

            XmlDeclaration decl = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(decl);

            xml.AppendChild(XmlNodeFromElement(element, xml));
            return xml;
        }

        private static XmlNode XmlNodeFromElement(Element element, XmlDocument xml)
        {
            XmlNode node = xml.CreateElement(element.Name);
            node.InnerText = element.InnerText;
            foreach (var elementAttribute in element.Attributes)
            {
                XmlAttribute attribute = xml.CreateAttribute(elementAttribute.Name);
                attribute.Value = elementAttribute.Value;
                Debug.Assert(node.Attributes != null, "node.Attributes != null");
                node.Attributes.Append(attribute);
            }

            foreach (var elementChild in element.Children)
            {
                node.AppendChild(XmlNodeFromElement(elementChild, xml));
            }

            return node;
        }

        public static string StringFromXml(XmlDocument xml)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
            xml.WriteTo(xmlTextWriter);

            return stringWriter.ToString();
        }
    }
}