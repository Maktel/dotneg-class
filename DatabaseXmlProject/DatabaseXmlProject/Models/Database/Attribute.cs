using System.Data.Linq.Mapping;

namespace DatabaseXmlProject.Models.Database
{
    [Table(Name = "Attributes")]
    public class Attribute
    {
        [Column(IsPrimaryKey = true, Name = "attribute_id")]
        public int AttributeId;

        [Column(Name = "name", CanBeNull = false)]
        public string Name;

        [Column(Name = "tag_id", CanBeNull = false)]
        public int TagId;

        [Column(Name = "value", CanBeNull = true)]
        public string Value;
    }
}