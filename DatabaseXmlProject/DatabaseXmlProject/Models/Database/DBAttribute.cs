using System;
using System.Data.Linq.Mapping;

namespace DatabaseXmlProject.Models.Database
{
    [Table(Name = "Attributes")]
    public class DbAttribute
    {
        [Column(IsPrimaryKey = true, Name = "attribute_id")]
        public Guid AttributeId;

        [Column(Name = "tag_id", CanBeNull = false)]
        public Guid TagId;

        [Column(Name = "name", CanBeNull = false)]
        public string Name;

        [Column(Name = "value", CanBeNull = true)]
        public string Value;
    }
}