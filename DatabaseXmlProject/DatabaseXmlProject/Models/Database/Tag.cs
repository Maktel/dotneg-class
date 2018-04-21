using System.Data.Linq.Mapping;

namespace DatabaseXmlProject.Models.Database
{
    [Table(Name = "Tags")]
    public class Tag
    {
        [Column(Name = "innertext", CanBeNull = true)]
        public string InnerText;

        [Column(Name = "name", CanBeNull = false)]
        public string Name;

        [Column(Name = "parent_id", CanBeNull = true)]
        public int? ParentId;

        [Column(IsPrimaryKey = true, Name = "tag_id")]
        public int TagId;
    }
}