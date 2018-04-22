using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using DatabaseXmlProject.Models.Database;

namespace DatabaseXmlProject
{
    internal class Database
    {
        private readonly string _connectionString;
        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTables()
        {
            var methodWatch = Stopwatch.StartNew();

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
                                tag_id uniqueidentifier NOT NULL,
                                name varchar(max) NOT NULL,
                                innertext varchar(max) NULL,
                                parent_id uniqueidentifier NULL,
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
                                attribute_id uniqueidentifier NOT NULL,
                                tag_id uniqueidentifier NOT NULL,
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

            methodWatch.Stop();
            Console.WriteLine($"Tables exist or created successfully in {methodWatch.ElapsedMilliseconds} ms");
        }

        public void ClearTables()
        {
            var methodWatch = Stopwatch.StartNew();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Attributes; DELETE FROM Tags;";
                command.ExecuteNonQuery();
            }

            methodWatch.Stop();
            Console.WriteLine(
                $"Database has been cleared (deleted all rows in both tables) in {methodWatch.ElapsedMilliseconds} ms");
        }

        public List<DbTag> GetTags()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var databaseContext = new DataContext(sqlConnection);
                var tags = databaseContext.GetTable<DbTag>();

                return tags.ToList();
            }
        }

        public List<DbAttribute> GetAttributes()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var databaseContext = new DataContext(sqlConnection);
                var attributes = databaseContext.GetTable<DbAttribute>();

                return attributes.ToList();
            }
        }

        public DbTagsAndAttributes GetTagsAndAttributes()
        {
            return new DbTagsAndAttributes(GetTags(), GetAttributes());
        }

        public void InsertTags(List<DbTag> tags)
        {
            var methodWatch = Stopwatch.StartNew();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var operationWatch = Stopwatch.StartNew();

                // insert without foreign keys
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandType = CommandType.Text;
                insertCommand.CommandText = "";
                int tagCounter = 1;
                foreach (var tag in tags)
                {
                    insertCommand.CommandText +=
                        $"INSERT INTO Tags (tag_id, name, innertext, parent_id) VALUES (@tag_id{tagCounter}, @name{tagCounter}, @innertext{tagCounter}, null);{Environment.NewLine}";
                    insertCommand.Parameters.Add($"@tag_id{tagCounter}", SqlDbType.UniqueIdentifier).Value = tag.TagId;
                    insertCommand.Parameters.Add($"@name{tagCounter}", SqlDbType.VarChar).Value = tag.Name;
                    insertCommand.Parameters.Add($"@innertext{tagCounter}", SqlDbType.VarChar).Value =
                        tag.InnerText ?? (object) DBNull.Value;


                    ++tagCounter;
                }

                Console.WriteLine($"Tag parsing ended in {operationWatch.ElapsedMilliseconds} ms. Insertion started");
                insertCommand.ExecuteNonQuery();

                operationWatch.Stop();
                Console.WriteLine(
                    $"{tags.Count} tags have been inserted with null as parent id in {operationWatch.ElapsedMilliseconds} ms");
                operationWatch.Restart();


                // update with FKs
                var updateCommand = connection.CreateCommand();
                updateCommand.CommandType = CommandType.Text;
                updateCommand.CommandText = "";

                tagCounter = 1;
                foreach (var tag in tags)
                {
                    updateCommand.CommandText +=
                        $"UPDATE Tags SET parent_id = @parent_id{tagCounter} WHERE tag_id = @tag_id{tagCounter};{Environment.NewLine}";
                    updateCommand.Parameters.Add($"@parent_id{tagCounter}", SqlDbType.UniqueIdentifier).Value =
                        tag.ParentId ?? (object) DBNull.Value;
                    updateCommand.Parameters.Add($"@tag_id{tagCounter}", SqlDbType.UniqueIdentifier).Value = tag.TagId;

                    ++tagCounter;
                }

                Console.WriteLine($"Tag parsing ended in {operationWatch.ElapsedMilliseconds} ms. Update started");
                updateCommand.ExecuteNonQuery();

                Console.WriteLine(
                    $"{tags.Count} tags have been updated with appropriate parent ids in {operationWatch.ElapsedMilliseconds} ms");
            }

            methodWatch.Stop();
            Console.WriteLine($"Tags added successfully in {methodWatch.ElapsedMilliseconds} ms");
        }

        public void InsertAttributes(List<DbAttribute> attributes)
        {
            var methodWatch = Stopwatch.StartNew();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "";
                int attributeCounter = 1;
                foreach (var attribute in attributes)
                {
                    command.CommandText +=
                        $"INSERT INTO Attributes (attribute_id, tag_id, name, value) VALUES (@attribute_id{attributeCounter}, @tag_id{attributeCounter}, @name{attributeCounter}, @value{attributeCounter});{Environment.NewLine}";
                    command.Parameters.Add($"@attribute_id{attributeCounter}", SqlDbType.UniqueIdentifier).Value =
                        attribute.AttributeId;
                    command.Parameters.Add($"@tag_id{attributeCounter}", SqlDbType.UniqueIdentifier).Value =
                        attribute.TagId;
                    command.Parameters.Add($"@name{attributeCounter}", SqlDbType.VarChar).Value = attribute.Name;
                    command.Parameters.Add($"@value{attributeCounter}", SqlDbType.VarChar).Value =
                        attribute.Value ?? (object) DBNull.Value;

                    ++attributeCounter;
                }

                Console.WriteLine(
                    $"Attribute parsing ended in {methodWatch.ElapsedMilliseconds} ms. Insertion started");
                command.ExecuteNonQuery();

                Console.WriteLine($"{attributes.Count} attributes have been inserted");
            }

            methodWatch.Stop();
            Console.WriteLine($"Attributes added successfully in {methodWatch.ElapsedMilliseconds} ms");
        }

        public void DeleteAttributeById(string idForDeletion)
        {
            DeleteAttributeById(Guid.Parse(idForDeletion));
        }

        public void DeleteAttributeById(Guid idForDeletion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"DELETE FROM Attributes WHERE attribute_id = @attribute_id";
                command.Parameters.Add("@attribute_id", SqlDbType.UniqueIdentifier).Value = idForDeletion;

                command.ExecuteNonQuery();
            }
        }

        public void DeleteTagById(string idForDeletion)
        {
            DeleteTagById(Guid.Parse(idForDeletion));
        }

        public void DeleteTagById(Guid idForDeletion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"SELECT tag_id FROM Tags WHERE parent_id = @deleted_id";
                command.Parameters.Add("@deleted_id", SqlDbType.UniqueIdentifier).Value = idForDeletion;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DeleteTagById(reader.GetGuid(0));

                        // use this if first column is actually a tag_id xD
                        // DeleteTagById(reader.GetGuid(0));
                    }
                }

                command.CommandText = $"DELETE FROM Attributes WHERE tag_id = @deleted_id";
                command.ExecuteNonQuery();

                command.CommandText = $"DELETE FROM Tags WHERE tag_id = @deleted_id";
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTagsByName(string tagName)
        {
            var methodWatch = Stopwatch.StartNew();

            int rowCount = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"SELECT tag_id FROM Tags WHERE name = @deleted_name";
                command.Parameters.Add($"@deleted_name", SqlDbType.VarChar).Value = tagName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DeleteTagById(reader.GetGuid(0));
                        ++rowCount;
                    }
                }
            }

            methodWatch.Stop();
            Console.WriteLine(
                $"Successfully deleted {rowCount} rows with name {tagName} in {methodWatch.ElapsedMilliseconds} ms");
        }
    }
}