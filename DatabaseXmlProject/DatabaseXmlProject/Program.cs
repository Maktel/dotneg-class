using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DatabaseXmlProject.Models.Xml;

namespace DatabaseXmlProject
{
    static class Program
    {
        private static void Main(string[] args)
        {
            string connectionString = System.IO.File.ReadAllText("../../connection_string.secret.pass");
            Database db = new Database(connectionString);
//            db.CreateTagsAndAttributesTables();
//            db.Clear();

            Root root = Parser.Parse<Root>("../../input.xml");

            var tagsAndAttributes = new Parser.TagsAndAttributes(root);
//            db.InsertTags(tagsAndAttributes.Tags);
            db.InsertAttributes(tagsAndAttributes.Attributes);

            Console.WriteLine("Program exited. Press any key to continue...");
            Console.ReadKey();
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