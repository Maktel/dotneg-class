using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using DatabaseXmlProject.Models.Database;
using DatabaseXmlProject.Models.Xml;
using Attribute = DatabaseXmlProject.Models.Database.Attribute;

namespace DatabaseXmlProject
{
    class Parser
    {
        public static T Parse<T>(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(filepath))
            {
                return (T) serializer.Deserialize(reader);
            }
        }

        public class TagsAndAttributes
        {
            public List<Tag> Tags { get; }
            private int _tagId = 0;
            public List<Attribute> Attributes { get; }
            private int _attributeId = 1;

            public TagsAndAttributes(object startingTag)
            {
                Tags = new List<Tag>();
                Attributes = new List<Attribute>();

                ParseTag(startingTag);
            }

            private void ParseTag(object tag, int? parentId = null)
            {
                // class name contains namespace qualifiers
                char[] delimiters = {'.'};
                string tagName = tag.GetType().ToString().ToLower().Split(delimiters).Last();
                Tag dbTag = new Tag
                {
                    TagId = ++_tagId,
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

                            Attribute dbAttribute = new Attribute
                            {
                                AttributeId = _attributeId++,
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