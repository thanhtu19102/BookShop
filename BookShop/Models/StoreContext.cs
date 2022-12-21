using BookShop.Areas.Admin.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace BookShop.Models
{
	public class StoreContext
	{
        public string ConnectionString { get; set; }

        public StoreContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from product";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            pd_ID = reader["pd_ID"].ToString(),
                            cat_name = reader["cat_name"].ToString(),
                            title = reader["title"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                            thumbnail = reader["thumbnail"].ToString(),
                            discount = Convert.ToInt32(reader["discount"]),
                            des = reader["des"].ToString(),
                            created_at = reader["created_at"].ToString(),
                            updated_at = reader["updated_at"].ToString(),
                            quantity = Convert.ToInt32(reader["quantity"])
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
    }
}
