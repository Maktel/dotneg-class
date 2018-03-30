using System;
using System.Collections.Generic;
using System.Net.Cache;

namespace ParsingXmlToObjectsManually.Models
{
    public class Help
    {
        public string Free;
        public string Bottom;
        public string Curtain;
        public List<Cage> Cages;

        public Help(string free, string bottom, string curtain, List<Cage> cages)
        {
            Free = free;
            Bottom = bottom;
            Curtain = curtain;
            Cages = cages;
        }
    }
}