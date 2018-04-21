using System;
using System.Collections;
using System.Collections.Generic;
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
        public static T ParseXmlToObject<T>(string filepath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filepath))
            {
                return (T) serializer.Deserialize(reader);
            }
        }

        public static Element ParseXmlToElement(string filepath)
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

        public static Element FromDatabase(List<DBTag> dbTags, List<DBAttribute> dbAttributes)
        {
            var rootElementQuery =
                from tag in dbTags
                where tag.ParentId is null
                select tag;

            return ParseDatabaseTag(dbTags, dbAttributes, rootElementQuery.First());
        }

        private static Element ParseDatabaseTag(List<DBTag> dbTags, List<DBAttribute> dbAttributes, DBTag dbTag)
        {
            Element element = new Element()
            {
                ElementId = dbTag.TagId,
                InnerText = dbTag.InnerText,
                Name = dbTag.Name
            };

            var elementAttributesQuery =
                from attribute in dbAttributes
                where attribute.TagId == dbTag.TagId
                select attribute;

            foreach (var dbAttribute in elementAttributesQuery)
            {
                Attribute attribute = new Attribute()
                {
                    AttributeId = dbAttribute.AttributeId,
                    Name = dbAttribute.Name,
                    Value = dbAttribute.Value
                };
                element.Attributes.Add(attribute);
            }

            var elementChildrenQuery =
                from tag in dbTags
                where tag.ParentId == dbTag.TagId
                select tag;

            foreach (var dbChildTag in elementChildrenQuery)
            {
                var child = ParseDatabaseTag(dbTags, dbAttributes, dbChildTag);
                element.Children.Add(child);
            }

            return element;
        }

        public class TagsAndAttributes
        {
            public List<DBTag> Tags { get; }
            public List<DBAttribute> Attributes { get; }

            public static TagsAndAttributes FromObjects(object startingTag)
            {
                TagsAndAttributes tagsAndAttributes = new TagsAndAttributes();
                tagsAndAttributes.ParseTag(startingTag);

                return tagsAndAttributes;
            }

            public static TagsAndAttributes FromElements(Element root)
            {
                TagsAndAttributes tagsAndAttributes = new TagsAndAttributes();
                tagsAndAttributes.ParseElement(root);

                return tagsAndAttributes;
            }


            private TagsAndAttributes()
            {
                Tags = new List<DBTag>();
                Attributes = new List<DBAttribute>();
            }

            private void ParseElement(Element element, Guid? parentId = null)
            {
                DBTag dbTag = new DBTag()
                {
                    TagId = element.ElementId,
                    Name = element.Name,
                    InnerText = element.InnerText,
                    ParentId = parentId
                };
                Tags.Add(dbTag);

                foreach (var elementChild in element.Children)
                {
                    ParseElement(elementChild, element.ElementId);
                }

                foreach (var attribute in element.Attributes)
                {
                    DBAttribute dbAttribute = new DBAttribute()
                    {
                        AttributeId = attribute.AttributeId,
                        TagId = element.ElementId,
                        Name = attribute.Name,
                        Value = attribute.Value
                    };
                    Attributes.Add(dbAttribute);
                }
            }

            private void ParseTag(object tag, Guid? parentId = null)
            {
                // class name contains namespace qualifiers
                char[] delimiters = {'.'};
                var tagName = tag.GetType().ToString().ToLower().Split(delimiters).Last();
                var dbTag = new DBTag
                {
                    TagId = Guid.NewGuid(),
                    ParentId = parentId,
                    Name = tagName
                };

                var fieldInfos = tag.GetType().GetFields();
                foreach (var fieldInfo in fieldInfos)
                {
                    var field = fieldInfo.GetValue(tag);

                    switch (field)
                    {
                        case string _:
                            var fieldName = fieldInfo.Name;
                            if (fieldName == "InnerText")
                            {
                                dbTag.InnerText = (string) field;
                                break;
                            }

                            var dbAttribute = new DBAttribute
                            {
                                AttributeId = Guid.NewGuid(),
                                Name = fieldName.ToLower(),
                                TagId = dbTag.TagId,
                                Value = (string) field
                            };
                            Attributes.Add(dbAttribute);

                            break;
                        case IList _:
                            foreach (var listElement in (IList) field)
                            {
                                ParseTag(listElement, dbTag.TagId);
                            }

                            break;
                        default:
                            ParseTag(field, dbTag.TagId);
                            break;
                    }
                }

                Tags.Add(dbTag);
            }
        }
    }
}