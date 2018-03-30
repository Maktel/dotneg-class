using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlGeneratorAndParser
{
    class Program
    {
        private const string Fullpath =
                @"C:\\Users\\Win10VM\\Documents\\Visual Studio 2017\\Projects\\XmlGeneratorAndParser\\XmlGeneratorAndParser\\"
            ;

        private const string OutputFile = Fullpath + "output.xml";

        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.Generate2();
//            generator.Save(OutputFile);

            Console.WriteLine(generator.AsString());
            Console.WriteLine("\n");

//            Parser parser = new Parser();
//            parser.LoadFromFile(OutputFile);
//            Console.WriteLine(parser.AsString());
//
//            Console.WriteLine(parser.GetElementEffort());
//
//            var children = parser.GetElementChildren("breathe/do");
//            foreach (var child in children)
//            {
//                Console.WriteLine(child);
//            }
//            parser.ModifyEffortInnerText();
//            parser.Save(Fullpath + "output_mod.xml");
        }
    }
}