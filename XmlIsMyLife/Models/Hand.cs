using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace XmlIsMyLife.Models
{
    class Hand
    {
        public string Violent;
        public string Privilege;
        public string Obese;
        public string InnerText;

        public Hand(string violent, string privilege, string obese, string innerText)
        {
            Violent = violent;
            Privilege = privilege;
            Obese = obese;
            InnerText = innerText;
        }
    }
}
