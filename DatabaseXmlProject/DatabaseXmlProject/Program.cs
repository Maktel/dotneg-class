using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using DatabaseXmlProject.Models.Database;
using DatabaseXmlProject.Models.GenericXml;
using DatabaseXmlProject.Models.Xml;
using Attribute = DatabaseXmlProject.Models.GenericXml.Attribute;

namespace DatabaseXmlProject
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var methodWatch = Stopwatch.StartNew();

            var connectionString = File.ReadAllText("../../connection_string.secret.pass");
            var db = new Database(connectionString);
//            db.CreateTables();
//            db.ClearTables();
//
//            Element rootFromXml = Parser.ElementFromXml("../../input.xml");
//            var tagsAndAttributesFromXml = Converter.DatabaseFromElement(rootFromXml);
//            db.InsertTags(tagsAndAttributesFromXml.Tags);
//            db.InsertAttributes(tagsAndAttributesFromXml.Attributes);

            db.DeleteTagsByName("hall");

//            rootFromXml.InnerText = "Hello world";
//            rootFromXml.Children[0].Attributes[0].Name = "this_attribute_has_been_modified";
//            var tagsAndAttributesFromXml = Converter.DatabaseFromElement(rootFromXml);

            var tagsAndAttributesFromDatabase = db.GetTagsAndAttributes();

            var tag =
                (from t in tagsAndAttributesFromDatabase.Tags
                where t.Name == "root"
                select t).First();

            DbAttribute dbAttribute = new DbAttribute()
            {
                AttributeId = Guid.NewGuid(),
                Name = "foo" + new Random().Next(),
                TagId = tag.TagId,
                Value = "baz"
            };
            db.UpdateOrInsertAttribute(dbAttribute);

            tagsAndAttributesFromDatabase = db.GetTagsAndAttributes();
            var rootFromDatabase = Converter.ElementFromDatabase(tagsAndAttributesFromDatabase);
            XmlDocument xml = Parser.XmlFromElement(rootFromDatabase);
            Console.WriteLine(Parser.StringFromXml(xml));

            methodWatch.Stop();
            Console.WriteLine($"Program exited successfully in {methodWatch.ElapsedMilliseconds} ms");

            return;
        }
    }
}