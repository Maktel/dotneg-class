using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlIsMyLife.Models;

namespace XmlIsMyLife
{
    class Program
    {
        private const string Filename = @"../../10.xml";

        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Filename);

            Root root = Parse(xml);

        }

        private static Root Parse(XmlDocument xml)
        {
            XmlNode rootNode = xml.SelectSingleNode("/root");
            XmlNode currencyNode = rootNode.FirstChild;

            XmlNodeList receptionNodeList = currencyNode.ChildNodes;

            List<Reception> receptions = new List<Reception>();
            foreach (XmlNode receptionNode in receptionNodeList)
            {
                XmlNodeList handNodeList = receptionNode.ChildNodes;
                List<Hand> hands = new List<Hand>();

                foreach (XmlNode handNode in handNodeList)
                {
                    Hand hand = new Hand(handNode.Attributes["violent"].Value, handNode.Attributes["privilege"].Value,
                        handNode.Attributes["obese"].Value, handNode.InnerText);
                    hands.Add(hand);
                }

                Reception reception = new Reception(receptionNode.Attributes["koran"].Value,
                    receptionNode.Attributes["restriction"].Value, receptionNode.Attributes["pay"].Value,
                    receptionNode.Attributes["tiger"].Value, hands);
                receptions.Add(reception);
            }

            Currency currency = new Currency(currencyNode.Attributes["requirement"].Value, currencyNode.Attributes["fraud"].Value, currencyNode.Attributes["sugar"].Value, currencyNode.Attributes["player"].Value, currencyNode.Attributes["capitalism"].Value, currencyNode.Attributes["undermine"].Value, currencyNode.Attributes["birthday"].Value, receptions);
            List<Currency> currencies = new List<Currency> {currency};
            return new Root(currencies);
        }
    }
}