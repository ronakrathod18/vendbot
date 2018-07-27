using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using VendBot.Models;

namespace VendBot.Controllers
{
    public class InventoryManager
    {
        public static IList<Item> GetInventory()
        {
            IList<Item> vendingMachine = new List<Item>();
            try
            {
                using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["VendBot"].ConnectionString))
                {
                    using (var command = new MySqlCommand("GetInventory", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        if (conn.State.Equals(ConnectionState.Closed))
                        {
                            conn.Open();
                        }

                        var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        
                        while (reader.Read())
                        {
                            var item = new Item
                            {
                                Id = reader["Id"] != System.DBNull.Value ? Convert.ToInt32(reader["Id"]) : 0,
                                Type = reader["Type"] != System.DBNull.Value ? reader["Type"].ToString() : string.Empty,
                                Name = reader["Name"] != System.DBNull.Value ? reader["Name"].ToString() : string.Empty,
                                Quantity = reader["Quantity"] != System.DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                                Image = reader["Image"] != System.DBNull.Value ? reader["Image"].ToString() : "http://images.agoramedia.com/wte3.0/gcms/lemon_bigger.jpg"
                            };

                            vendingMachine.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var errEx = new Exception(string.Format("Error in GetInventory Method."), ex);
            }

            return vendingMachine;
        }

        public static int GetItem(string itemType, int itemId)
        {
            int itemCount = 0;
            try
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["VendBot"].ConnectionString))
                {
                    using (var command = new MySqlCommand("GetItem", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add(new MySqlParameter("itemType", itemType));
                        command.Parameters.Add(new MySqlParameter("itemId", itemId));

                        if (conn.State.Equals(ConnectionState.Closed))
                        {
                            conn.Open();
                        }

                        var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        
                        while (reader.Read())
                        {
                            itemCount = reader["Quantity"] != System.DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var errEx = new Exception(string.Format("Error in GetItem Method."), ex);
            }

            return itemCount;
        }

        public static int StockItem(string itemType, int itemId, int itemCount)
        {
            int quantity = 0;
            try
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.ConnectionStrings["VendBot"].ConnectionString))
                {
                    using (var command = new MySqlCommand("StockItem", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add(new MySqlParameter("itemType", itemType));
                        command.Parameters.Add(new MySqlParameter("itemId", itemId));
                        command.Parameters.Add(new MySqlParameter("itemCount", itemCount));

                        if (conn.State.Equals(ConnectionState.Closed))
                        {
                            conn.Open();
                        }

                        var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                        while (reader.Read())
                        {
                            quantity = reader["Quantity"] != System.DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var errEx = new Exception(string.Format("Error in StockItem Method."), ex);
            }

            return quantity;
        }

    }
}