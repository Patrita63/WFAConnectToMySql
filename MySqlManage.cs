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

        public async Task<List<Inventory>> getData(string ConnectionString, string query)
        {
            List<Inventory> listInventory = null;
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

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
            return listInventory;
        }


        public async Task<List<Inventory>> getFromGuest(string ConnectionString, string query)
        {
            List<Inventory> listInventory = null;
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

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
            return listInventory;
        }

    }
}
