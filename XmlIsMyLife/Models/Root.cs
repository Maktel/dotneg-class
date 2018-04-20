using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlIsMyLife.Models
{
    class Root
    {
        public List<Currency> Currencies;

        public Root(List<Currency> currencies)
        {
            Currencies = currencies;
        }
    }
}
