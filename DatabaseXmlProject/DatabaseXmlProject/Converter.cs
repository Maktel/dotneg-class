using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseXmlProject.Models.Database;
using DatabaseXmlProject.Models.GenericXml;
using Attribute = DatabaseXmlProject.Models.GenericXml.Attribute;

namespace DatabaseXmlProject
{
    internal static class Converter
    {
        public static Element ElementFromDatabase(DbTagsAndAttributes tagsAndAttributes)
        {
            var rootElementQuery =
                from tag in tagsAndAttributes.Tags
                where tag.ParentId is null
                select tag;

            var rootTag = rootElementQuery.First();
            // database contains no root element or is empty
            if (rootTag is null)
            {
                return new Element();
            }

            var helper = new HelperDbTagsAndAttributes(tagsAndAttributes);
            return helper.ElementFromDatabaseTag(rootTag);
        }
        
        public static DbTagsAndAttributes DatabaseFromObject(object startingTag)
        {
            HelperDbTagsAndAttributes tagsAndAttributes = new HelperDbTagsAndAttributes();
            tagsAndAttributes.ParseObject(startingTag);

            return tagsAndAttributes.TagsAndAttributes;
        }

        public static DbTagsAndAttributes DatabaseFromElement(Element element)
        {
            HelperDbTagsAndAttributes tagsAndAttributes = new HelperDbTagsAndAttributes();
            tagsAndAttributes.ParseElement(element);

            return tagsAndAttributes.TagsAndAttributes;
        }


        private class HelperDbTagsAndAttributes
        {
            public DbTagsAndAttributes TagsAndAttributes = new DbTagsAndAttributes();

            public HelperDbTagsAndAttributes() { }

            public HelperDbTagsAndAttributes(DbTagsAndAttributes tagsAndAttributes)
            {
                TagsAndAttributes = tagsAndAttributes;
            }

            public void ParseElement(Element element, Guid? parentId = null)
            {
                DbTag dbTag = new DbTag()
                {
                    TagId = element.ElementId,
                    Name = element.Name,
                    InnerText = element.InnerText,
                    ParentId = parentId
                };
                TagsAndAttributes.Tags.Add(dbTag);

                foreach (var elementChild in element.Children)
                {
                    ParseElement(elementChild, element.ElementId);
                }

                foreach (var attribute in element.Attributes)
                {
                    DbAttribute dbAttribute = new DbAttribute()
                    {
                        AttributeId = attribute.AttributeId,
                        TagId = element.ElementId,
                        Name = attribute.Name,
                        Value = attribute.Value
                    };
                    TagsAndAttributes.Attributes.Add(dbAttribute);
                }
            }
            public void ParseObject(object tag, Guid? parentId = null)
            {
                // class name contains namespace qualifiers
                char[] delimiters = { '.' };
                var tagName = tag.GetType().ToString().ToLower().Split(delimiters).Last();
                var dbTag = new DbTag
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
                                dbTag.InnerText = (string)field;
                                break;
                            }

                            var dbAttribute = new DbAttribute
                            {
                                AttributeId = Guid.NewGuid(),
                                Name = fieldName.ToLower(),
                                TagId = dbTag.TagId,
                                Value = (string)field
                            };
                            TagsAndAttributes.Attributes.Add(dbAttribute);

                            break;
                        case IList _:
                            foreach (var listElement in (IList)field)
                            {
                                ParseObject(listElement, dbTag.TagId);
                            }

                            break;
                        default:
                            ParseObject(field, dbTag.TagId);
                            break;
                    }
                }

                TagsAndAttributes.Tags.Add(dbTag);
            }
            public Element ElementFromDatabaseTag(DbTag dbTag)
            {
                Element element = new Element()
                {
                    ElementId = dbTag.TagId,
                    InnerText = dbTag.InnerText,
                    Name = dbTag.Name
                };

                var elementAttributesQuery =
                    from attribute in TagsAndAttributes.Attributes
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
                    from tag in TagsAndAttributes.Tags
                    where tag.ParentId == dbTag.TagId
                    select tag;

                foreach (var dbChildTag in elementChildrenQuery)
                {
                    var child = ElementFromDatabaseTag(dbChildTag);
                    element.Children.Add(child);
                }

                return element;
            }
        }
    }
}