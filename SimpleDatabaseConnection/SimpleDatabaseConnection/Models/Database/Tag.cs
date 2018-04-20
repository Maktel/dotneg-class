using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleDatabaseConnection.Models.Database
{
    [Table(Name = "Tags")]
    public class Tag
    {
        [Column(IsPrimaryKey = true, Name = "tag_id")]
        public int TagId;

        [Column(Name = "name", CanBeNull = false)] public string Name;
        [Column(Name = "parent_id", CanBeNull = true)] public int? ParentId;
        [Column(Name = "innertext", CanBeNull = true)] public string InnerText;
    }
}