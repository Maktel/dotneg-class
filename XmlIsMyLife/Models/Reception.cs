using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlIsMyLife.Models
{
    class Reception
    {
        public string Koran;
        public string Restriction;
        public string Pay;
        public string Tiger;
        public List<Hand> Hands;

        public Reception(string koran, string restriction, string pay, string tiger, List<Hand> hands)
        {
            Koran = koran;
            Restriction = restriction;
            Pay = pay;
            Tiger = tiger;
            Hands = hands;
        }
    }
}
