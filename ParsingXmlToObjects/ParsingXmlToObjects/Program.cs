using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ParsingXmlToObjects.Models;

namespace ParsingXmlToObjects
{
    class Program
    {
        private const string Fullpath =
            @"C:\Users\Win10VM\Documents\Visual Studio 2017\Projects\ParsingXmlToObjects\ParsingXmlToObjects\";

        private const string Filename = @"input.xml";

        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(Fullpath + Filename);

            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            Root r;
            using (TextReader reader = new StringReader(XmlToString(xml)))
            {
                r = (Root) serializer.Deserialize(reader);
            }

            foreach (Appropriate a in r.Appropriates)
            {
                Console.WriteLine("a.Statues.Count: " + a.Statues.Count);
                foreach (Statue s in a.Statues)
                {
                    Console.WriteLine("  s.Presidents.Count: " + s.Presidents.Count);
                    foreach (President p in s.Presidents)
                    {
                        Console.WriteLine("    p.InnerText: " + p.InnerText);
                    }
                }
            }

            Console.WriteLine(XmlToString(xml));
        }

        private static string XmlToString(XmlDocument xml)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter) {Formatting = Formatting.Indented};
            xml.WriteTo(xmlTextWriter);

            return stringWriter.ToString();
        }
    }
}