using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseXmlProject
{
    static class Program
    {
        private static void Main(string[] args)
        {
            string connectionString = System.IO.File.ReadAllText("../../connection_string.secret.pass");
            Database db = new Database(connectionString);

//            db.CreateTagsAndAttributesTables();
            db.TryGettingSomeExampleData();

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