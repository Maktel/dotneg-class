﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DatabaseXmlProject.Models.Database;

namespace DatabaseXmlProject
{
    internal class Parser
    {
        public static T Parse<T>(string filepath)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StreamReader(filepath))
            {
                return (T) serializer.Deserialize(reader);
            }
        }

        public class TagsAndAttributes
        {
            private int _attributeId = 1;
            private int _tagId;

            public TagsAndAttributes(object startingTag)
            {
                Tags = new List<Tag>();
                Attributes = new List<Attribute>();

                ParseTag(startingTag);
            }

            public List<Tag> Tags { get; }
            public List<Attribute> Attributes { get; }

            private void ParseTag(object tag, int? parentId = null)
            {
                // class name contains namespace qualifiers
                char[] delimiters = {'.'};
                var tagName = tag.GetType().ToString().ToLower().Split(delimiters).Last();
                var dbTag = new Tag
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

                            var dbAttribute = new Attribute
                            {
                                AttributeId = _attributeId++,
                                Name = fieldName.ToLower(),
                                TagId = dbTag.TagId,
                                Value = (string) field
                            };
                            Attributes.Add(dbAttribute);

                            break;
                        case IList _:
                            foreach (var listElement in (IList) field) ParseTag(listElement, dbTag.TagId);

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