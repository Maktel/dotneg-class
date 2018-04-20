using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DatabaseXmlProject.Models.Database;

namespace DatabaseXmlProject
{
    class Database
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

                    var createTagsTableCommand = connection.CreateCommand();
                    createTagsTableCommand.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Tags')
                        BEGIN
                            CREATE TABLE dbo.Tags (
                                tag_id int IDENTITY,
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
                                attribute_id int IDENTITY,
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

        public void TryGettingSomeExampleData()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                DataContext databaseContext = new DataContext(sqlConnection);
                Table<Tag> tags = databaseContext.GetTable<Tag>();
//                db.Log = Console.Out;
                IQueryable<Tag> queryable =
                    from tag in tags
                    where tag.Name == "root"
                    select tag;

                foreach (Tag tag in queryable)
                {
                    Console.WriteLine(tag.InnerText);
                }
            }
        }
    }
}