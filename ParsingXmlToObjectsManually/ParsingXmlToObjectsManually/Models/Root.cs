using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingXmlToObjectsManually.Models
{
    public class Root
    {
        public List<Help> Helps;

        public Root(List<Help> helps)
        {
            Helps = helps;
        }
    }
}
