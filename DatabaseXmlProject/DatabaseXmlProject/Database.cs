using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using DatabaseXmlProject.Models.Database;
using Attribute = DatabaseXmlProject.Models.Database.Attribute;

namespace DatabaseXmlProject
{
    internal class Database
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTagsAndAttributesTables()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    // FIXME: both primary keys have been degraded to NOT NULL instead of IDENTITY
                    // its values should be retrieved from db after insertion

                    var createTagsTableCommand = connection.CreateCommand();
                    createTagsTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tags')
                        BEGIN
                            CREATE TABLE dbo.Tags (
                                tag_id int NOT NULL,
                                name varchar(max) NOT NULL,
                                innertext varchar(max) NULL,
                                parent_id int NULL,
                                PRIMARY KEY CLUSTERED (tag_id)
                            )

                            ALTER TABLE Tags
                                ADD FOREIGN KEY (parent_id) REFERENCES dbo.Tags (tag_id)
                        END
                   ";

                    var createAttributesTableCommand = connection.CreateCommand();
                    createAttributesTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Attributes')
                        BEGIN
                            CREATE TABLE dbo.Attributes (
                                attribute_id int NOT NULL,
                                tag_id int NOT NULL,
                                name varchar(max) NOT NULL,
                                value varchar(max) NULL,
                                PRIMARY KEY CLUSTERED (attribute_id)
                            )

                            ALTER TABLE Attributes
                                ADD FOREIGN KEY (tag_id) REFERENCES dbo.Tags (tag_id)
                        END
                    ";

                    createTagsTableCommand.ExecuteNonQuery();
                    createAttributesTableCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.ToString());
                    return;
                }
            }

            Console.WriteLine("Tables exist or created successfully");
        }

        public void Clear()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Attributes; DELETE FROM Tags;";
                command.ExecuteNonQuery();
            }

            Console.WriteLine("Database has been cleared (deleted all rows in both tables)");
        }

        public void TryGettingSomeExampleData()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var databaseContext = new DataContext(sqlConnection);
                var tags = databaseContext.GetTable<Tag>();
//                db.Log = Console.Out;
                var queryable =
                    from tag in tags
                    where tag.Name == "root"
                    select tag;

                foreach (var tag in queryable) Console.WriteLine(tag.InnerText);
            }
        }

        public void InsertTags(List<Tag> tags)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // insert without foreign keys
                foreach (var tag in tags)
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        @"INSERT INTO Tags (tag_id, name, innertext, parent_id) VALUES (@tag_id, @name, @innertext, null)";
                    command.Parameters.Add("@tag_id", SqlDbType.Int).Value = tag.TagId;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = tag.Name;
                    command.Parameters.Add("@innertext", SqlDbType.VarChar).Value =
                        tag.InnerText ?? (object) DBNull.Value;
                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"{tags.Count} tags have been inserted with null as parent id");

                // update with FKs
                foreach (var tag in tags)
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        @"UPDATE Tags SET parent_id=@parent_id WHERE tag_id=@tag_id";
                    command.Parameters.Add("@parent_id", SqlDbType.Int).Value = tag.ParentId ?? (object) DBNull.Value;
                    command.Parameters.Add("@tag_id", SqlDbType.Int).Value = tag.TagId;
                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"{tags.Count} tags have been updated with appropriate parent ids");
            }

            Console.WriteLine("Tags added successfully");
        }

        public void InsertAttributes(List<Attribute> attributes)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                foreach (var attribute in attributes)
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText =
                        @"INSERT INTO Attributes (attribute_id, tag_id, name, value) VALUES (@attribute_id, @tag_id, @name, @value)";
                    command.Parameters.Add("@attribute_id", SqlDbType.Int).Value = attribute.AttributeId;
                    command.Parameters.Add("@tag_id", SqlDbType.Int).Value = attribute.TagId;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = attribute.Name;
                    command.Parameters.Add("@value", SqlDbType.VarChar).Value =
                        attribute.Value ?? (object) DBNull.Value;
                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"{attributes.Count} attributes have been inserted");
            }

            Console.WriteLine("Attributes added successfully");
        }
    }
}