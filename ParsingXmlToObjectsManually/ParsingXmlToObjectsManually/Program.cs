using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ParsingXmlToObjectsManually.Models;

namespace ParsingXmlToObjectsManually
{
    class Program
    {
        private const string Filepath =
                @"C:\Users\Win10VM\Documents\Visual Studio 2017\Projects\ParsingXmlToObjectsManually\ParsingXmlToObjectsManually\input.xml"
            ;

        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Filepath);

            Root root = parseXml(xml);
            Console.WriteLine(root);
        }

        static Root parseXml(XmlDocument xml)
        {
            XmlNode rootNode = xml.SelectSingleNode("/root");
            Debug.Assert(rootNode != null, nameof(rootNode) + " != null");
            XmlNode helpNode = rootNode.FirstChild;
            XmlNodeList cageNodeList = helpNode.ChildNodes;

            List<Cage> cages = new List<Cage>();
            foreach (XmlNode cageNode in cageNodeList)
            {
                List<Judgement> judgements = new List<Judgement>();
                foreach (XmlNode judgementNode in cageNode.ChildNodes)
                {
                    Judgement judgement = new Judgement(judgementNode.InnerText);
                    judgements.Add(judgement);
                }
                Debug.Assert(cageNode.Attributes != null, "cageNode.Attributes != null");
                string race = cageNode.Attributes["race"].Value;
                string future = cageNode.Attributes["future"].Value;
                string chronic = cageNode.Attributes["chronic"].Value;
                string pen = cageNode.Attributes["pen"].Value;
                string brake = cageNode.Attributes["brake"].Value;
                string rage = cageNode.Attributes["rage"].Value;
                string slip = cageNode.Attributes["slip"].Value;

                Cage cage = new Cage(race, future, chronic, pen, brake, rage, slip, judgements);
                cages.Add(cage);
            }

            Debug.Assert(helpNode.Attributes != null, "helpNode.Attributes != null");
            string free = helpNode.Attributes["free"].Value;
            string bottom = helpNode.Attributes["bottom"].Value;
            string curtain = helpNode.Attributes["curtain"].Value;

            Help help = new Help(free, bottom, curtain, cages);
            List<Help> helps = new List<Help> {help};
            Root root = new Root(helps);

            return root;
        }
    }
}