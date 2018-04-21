using System;
using System.IO;
using DatabaseXmlProject.Models.Xml;

namespace DatabaseXmlProject
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var connectionString = File.ReadAllText("../../connection_string.secret.pass");
            var db = new Database(connectionString);
            db.CreateTagsAndAttributesTables();
            db.Clear();

            var root = Parser.ParseXmlToObject<Root>("../../input.xml");

            var tagsAndAttributes = new Parser.TagsAndAttributes(root);
            db.InsertTags(tagsAndAttributes.Tags);
            db.InsertAttributes(tagsAndAttributes.Attributes);

            Console.WriteLine("Program exited successfully");

            return;
        }

//        static void ReadFromExample()
//        {
//            SqlConnection sqlConnection = new SqlConnection(_connectionString);
//            var sqlCommand = sqlConnection.CreateCommand();
//            sqlCommand.CommandType = CommandType.Text;
//            sqlCommand.CommandText = @"SELECT * FROM SalesLT.Address;";
//
//            sqlConnection.Open();
//            var reader = sqlCommand.ExecuteReader();
//
//            StringBuilder sb = new StringBuilder();
//            try
//            {
//                while (reader.Read())
//                {
//                    for (var i = 0; i < reader.FieldCount; ++i)
//                    {
//                        sb.Append($"{reader.GetName(i)}: {reader[i]}, ");
//                    }
//
//                    sb.Append($"{Environment.NewLine}");
//                }
//            }
//            finally
//            {
//                reader.Close();
//                Console.WriteLine(sb);
//            }
//
//            sqlConnection.Close();
//        }
    }
}