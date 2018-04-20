using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlIsMyLife.Models
{
    class Currency
    {
        public string Requirement;
        public string Fraud;
        public string Sugar;
        public string Player;
        public string Capitalism;
        public string Undermine;
        public string Birthday;
        public List<Reception> Receptions;

        public Currency(string requirement, string fraud, string sugar, string player, string capitalism, string undermine, string birthday, List<Reception> receptions)
        {
            Requirement = requirement;
            Fraud = fraud;
            Sugar = sugar;
            Player = player;
            Capitalism = capitalism;
            Undermine = undermine;
            Birthday = birthday;
            Receptions = receptions;
        }
    }
}
