using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using DatabaseXmlProject.Models.GenericXml;
using DatabaseXmlProject.Models.Xml;

namespace DatabaseXmlProject
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var methodWatch = Stopwatch.StartNew();

            var connectionString = File.ReadAllText("../../connection_string.secret.pass");
            var db = new Database(connectionString);
            db.CreateTables();
            db.ClearTables();

            Element rootFromXml = Parser.ElementFromXml("../../input.xml");
            var tagsAndAttributesFromXml = Converter.DatabaseFromElement(rootFromXml);
            db.InsertTags(tagsAndAttributesFromXml.Tags);
            db.InsertAttributes(tagsAndAttributesFromXml.Attributes);

            db.DeleteTagsByName("hall");

            var tagsAndAttributesFromDatabase = db.GetTagsAndAttributes();
            Element rootFromDatabase = Converter.ElementFromDatabase(tagsAndAttributesFromDatabase);

            XmlDocument xml = Parser.XmlFromElement(rootFromDatabase);
            Console.WriteLine(Parser.StringFromXml(xml));

            methodWatch.Stop();
            Console.WriteLine($"Program exited successfully in {methodWatch.ElapsedMilliseconds} ms");

            return;
        }
    }
}