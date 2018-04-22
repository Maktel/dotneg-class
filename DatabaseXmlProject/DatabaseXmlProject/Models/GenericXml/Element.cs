using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// FIXME inner text should be a child as well

namespace DatabaseXmlProject.Models.GenericXml
{
    class Element
    {
        public Guid ElementId;
        public string Name;
        public string InnerText;
        public List<Element> Children = new List<Element>();
        public List<Attribute> Attributes = new List<Attribute>();

        public Attribute AddAttribute(string name, string value)
        {
            Attribute attribute = new Attribute()
            {
                AttributeId = Guid.NewGuid(),
                Name = name,
                Value = value
            };
            Attributes.Add(attribute);
            return attribute;
        }
    }
}