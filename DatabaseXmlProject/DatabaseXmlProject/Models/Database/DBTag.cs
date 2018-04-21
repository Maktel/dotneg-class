using System;
using System.Data.Linq.Mapping;

namespace DatabaseXmlProject.Models.Database
{
    [Table(Name = "Tags")]
    public class DBTag
    {
        [Column(Name = "innertext", CanBeNull = true)]
        public string InnerText;

        [Column(Name = "name", CanBeNull = false)]
        public string Name;

        [Column(Name = "parent_id", CanBeNull = true)]
        public Guid? ParentId;

        [Column(IsPrimaryKey = true, Name = "tag_id")]
        public Guid TagId;
    }
}