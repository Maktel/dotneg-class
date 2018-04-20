using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabaseConnection.Models.Database
{
    [Table(Name = "Attributes")]
    public class Attribute
    {
        [Column(IsPrimaryKey = true, Name = "attribute_id")]
        public int AttributeId;

        [Column(Name = "tag_id", CanBeNull = false)]
        public int TagId;

        [Column(Name = "name", CanBeNull = false)]
        public string Name;

        [Column(Name = "value", CanBeNull = true)] public string Value;
    }
}