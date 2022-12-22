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
        public List<Areas.Admin.Models.Product> GetProducts()
        {
            List<Areas.Admin.Models.Product> list = new List<Areas.Admin.Models.Product>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from product";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Areas.Admin.Models.Product()
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
        public Product Details(string Id)
        {
            Product pro = new Product();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from product where pd_ID=@pdid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("pdid", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    pro.pd_ID = reader["pd_ID"].ToString();
                    pro.cat_name = reader["cat_name"].ToString();
                    pro.title = reader["title"].ToString();
                    pro.price = Convert.ToInt32(reader["price"]);
                    pro.thumbnail = reader["thumbnail"].ToString();
                    pro.discount = Convert.ToInt32(reader["discount"]);
                    pro.des = reader["des"].ToString();
                    pro.cat_name = reader["cat_name"].ToString();
                    pro.created_at = reader["created_at"].ToString();
                    pro.updated_at = reader["updated_at"].ToString();
                    pro.quantity = Convert.ToInt32(reader["quantity"]);
                }
            }
            return (pro);
        }

    }
}
