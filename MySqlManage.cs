using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using WFAConnectToMySql.Models;

namespace WFAConnectToMySql
{
    // https://docs.microsoft.com/en-us/azure/mysql/connect-csharp
    // dotnet add package MySqlConnector
    public class MySqlManage
    {
        public async Task CreateTableInventory(string ConnectionString)
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "DROP TABLE IF EXISTS inventory;";
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Finished dropping table (if existed)");

                    command.CommandText = "CREATE TABLE inventory (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER);";
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine("Finished creating table");

                    command.CommandText = @"INSERT INTO inventory (name, quantity) VALUES (@name1, @quantity1),
                        (@name2, @quantity2), (@name3, @quantity3);";
                    command.Parameters.AddWithValue("@name1", "banana");
                    command.Parameters.AddWithValue("@quantity1", 150);
                    command.Parameters.AddWithValue("@name2", "orange");
                    command.Parameters.AddWithValue("@quantity2", 154);
                    command.Parameters.AddWithValue("@name3", "apple");
                    command.Parameters.AddWithValue("@quantity3", 100);

                    int rowCount = await command.ExecuteNonQueryAsync();
                    Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
                }

                // connection will be closed by the 'using' block
                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }

        public async Task CreateTableInventory(string ConnectionString, string tableName)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    Console.WriteLine("Opening connection");
                    await conn.OpenAsync();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = string.Format("DROP TABLE IF EXISTS {0};", tableName);
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Finished dropping table (if existed)");

                        command.CommandText = string.Format("CREATE TABLE {0} (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER);", tableName);
                        await command.ExecuteNonQueryAsync();
                        Console.WriteLine("Finished creating table");

                        command.CommandText = string.Format(@"INSERT INTO {0} (name, quantity) VALUES (@name1, @quantity1),
                        (@name2, @quantity2), (@name3, @quantity3);", tableName);
                        command.Parameters.AddWithValue("@name1", "banana");
                        command.Parameters.AddWithValue("@quantity1", 150);
                        command.Parameters.AddWithValue("@name2", "orange");
                        command.Parameters.AddWithValue("@quantity2", 154);
                        command.Parameters.AddWithValue("@name3", "apple");
                        command.Parameters.AddWithValue("@quantity3", 100);

                        int rowCount = await command.ExecuteNonQueryAsync();
                        Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
                    }

                    // connection will be closed by the 'using' block
                    Console.WriteLine("Closing connection");
                }

                //Console.WriteLine("Press RETURN to exit");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                string sErr = string.Empty;
                if (ex.InnerException != null)
                    sErr = string.Format("Source: {0}{4} - Message: {1}{4} - InnerException:{2}{4} - StackTrace: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException, Environment.NewLine);
                else
                    sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);


                if (ex.Message.Contains("already exists"))
                    sErr = ex.Message;

                // Table 'testdb.inventory' doesn't exist
                if (ex.Message.Contains("doesn't exist"))
                    sErr = ex.Message;

                throw new Exception(sErr);
            }
        }

        public async Task<List<Inventory>> getData(string ConnectionString, string query)
        {
            List<Inventory> listInventory = null;
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    Console.WriteLine("Opening connection");
                    await conn.OpenAsync();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = query; // "SELECT * FROM inventory;";

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            listInventory = new List<Inventory>();
                            Inventory item = null;
                            while (await reader.ReadAsync())
                            {
                                item = new Inventory();
                                item.id = reader.GetInt32(0);
                                item.name = reader.GetString(1);
                                item.quantity = reader.GetInt32(2);

                                listInventory.Add(item);
                                //Console.WriteLine(string.Format(
                                //    "Reading from table=({0}, {1}, {2})",
                                //    reader.GetInt32(0),
                                //    reader.GetString(1),
                                //    reader.GetInt32(2)));
                            }
                        }
                    }

                    Console.WriteLine("Closing connection");
                }

                //Console.WriteLine("Press RETURN to exit");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                string sErr = string.Empty;
                if (ex.InnerException != null)
                    sErr = string.Format("Source: {0}{4} - Message: {1}{4} - InnerException:{2}{4} - StackTrace: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException, Environment.NewLine);
                else
                    sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);

                throw new Exception(sErr);
            }
            return listInventory;
        }


        public async Task<List<string>> getFromSchema(string ConnectionString, string query)
        {
            List<string> listTables = null;
            try
            {
                using (var conn = new MySqlConnection(ConnectionString))
                {
                    Console.WriteLine("Opening connection");
                    await conn.OpenAsync();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = query;

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            listTables = new List<string>();
                            while (await reader.ReadAsync())
                            {
                                var row = reader.GetValue(0);
                                var tableName = reader.GetString(0);

                                listTables.Add(tableName);
                            }
                        }
                    }

                }

            }
            catch(Exception ex)
            {
                string sErr = string.Empty;
                if (ex.InnerException != null)
                    sErr = string.Format("Source: {0}{4} - Message: {1}{4} - InnerException:{2}{4} - StackTrace: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException, Environment.NewLine);
                else
                    sErr = string.Format("Source: {0} - Message: {1} - StackTrace: {2}", ex.Source, ex.Message, ex.StackTrace);
            }
            
            return listTables;
        }

    }
}
