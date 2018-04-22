using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseXmlProject.Models.Database
{
    class DbTagsAndAttributes
    {
        public List<DbTag> Tags { get; }
        public List<DbAttribute> Attributes { get; }

        public DbTagsAndAttributes()
        {
            Tags = new List<DbTag>();
            Attributes = new List<DbAttribute>();
        }

        public DbTagsAndAttributes(List<DbTag> tags, List<DbAttribute> attributes)
        {
            Tags = tags;
            Attributes = attributes;
        }
    }
}
