using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BookShop.Areas.Admin.Models
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

        public int CheckLogin(string username, string password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int i = 0;
                conn.Open();
                var str = "select * from USER where username=@username and password=@password";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read() && i < 1)
                    {
                        i++;
                    }
                }
                return i;

            }
        }
        public List<User> GetUsers()
        {
            List<User> list = new List<User>();


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from user";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            user_ID = reader["user_ID"].ToString(),
                            fullname = reader["fullname"].ToString(),
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(),
                            email = reader["email"].ToString(),
                            address = reader["address"].ToString(),
                            phone = reader["phone"].ToString(),
                            role = reader["role"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public List<Order> GetOrders()
        {
            List<Order> list = new List<Order>();


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from `order`";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Order()
                        {
                            od_ID = reader["od_ID"].ToString(),
                            user_ID = reader["user_ID"].ToString(),
                            fullname = reader["fullname"].ToString(),
                            email = reader["email"].ToString(),
                            phone = reader["phone"].ToString(),
                            address = reader["address"].ToString(),
                            order_Date = reader["order_date"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }
        public int UpdateUser(User us)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update user set fullname = @fn, username = @un, password = @pw, email = @e, address = @add, phone = @p, role = @r where user_ID=@uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", us.user_ID);
                cmd.Parameters.AddWithValue("fn", us.fullname);
                cmd.Parameters.AddWithValue("un", us.username);
                cmd.Parameters.AddWithValue("e", us.email);
                cmd.Parameters.AddWithValue("pw", us.password);
                cmd.Parameters.AddWithValue("add", us.address);
                cmd.Parameters.AddWithValue("p", us.phone);
                cmd.Parameters.AddWithValue("r", us.role);
                return (cmd.ExecuteNonQuery());
            }
        }

        public User ViewUser(string Id)
        {
            User us = new User();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from User where User_ID=@uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    us.user_ID = reader["user_ID"].ToString();
                    us.fullname = reader["fullname"].ToString();
                    us.username = reader["username"].ToString();
                    us.password = reader["password"].ToString();
                    us.email = reader["email"].ToString();
                    us.address = reader["address"].ToString();
                    us.phone = reader["phone"].ToString();
                    us.role = reader["role"].ToString();
                }
            }
            return (us);
        }
       
        public List<Order_detail> ViewOrder(string Id)
        {
            List<Order_detail> list = new List<Order_detail>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "SELECT *, (SELECT sum(order_detail.quantity * product.price) FROM order_detail, product WHERE order_detail.pd_ID = product.pd_ID AND order_detail.od_id = @oid) as s FROM order_detail, product WHERE order_detail.pd_ID = product.pd_ID AND order_detail.od_id = @oid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("oid", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Order_detail()
                        {
                            dt_ID = reader["dt_ID"].ToString(),
                            od_ID = reader["od_ID"].ToString(),
                            pd_ID = reader["pd_ID"].ToString(),
                            quantity = Convert.ToInt32(reader["quantity"]),
                            price = Convert.ToInt32(reader["price"]),
                            total = Convert.ToInt32(reader["price"]) * Convert.ToInt32(reader["quantity"]),
                            sub_total = Convert.ToInt32(reader["s"]),
                            pd_title = reader["title"].ToString()
                        });
                    }
                    reader.Close();
                }

                conn.Close();
            }
            return list;
        }
        public int DeleteUser(string id)
        {
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "delete from USER where user_ID=@uid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("uid", id);

                return (cmd.ExecuteNonQuery());

            }
        }

        public List<Category> GetCategorys()
        {
            List<Category> list = new List<Category>();


            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from category";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category()
                        {
                            cat_ID = reader["cat_ID"].ToString(),
                            name = reader["name"].ToString()

                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public int AddCategory(Category cat)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into CATEGORY (`name`) values(@name)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                //cmd.Parameters.AddWithValue("id", cat.cat_ID);
                cmd.Parameters.AddWithValue("name", cat.name);

                return (cmd.ExecuteNonQuery());
            }
        }

        public Category ViewCategory(string Id)
        {
            Category cat = new Category();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from category where cat_ID=@cid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cid", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cat.cat_ID = reader["cat_ID"].ToString();
                    cat.name = reader["name"].ToString();

                }
            }
            return (cat);
        }

        public int UpdateCategory(Category cat)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update category set name = @name where cat_ID = @cid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cid", cat.cat_ID);
                cmd.Parameters.AddWithValue("name", cat.name);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int DeleteCategory(string id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from category where cat_ID=@cid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cid", id);

                return (cmd.ExecuteNonQuery());

            }
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
        public int AddProduct(Product pro)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "INSERT INTO `product` (`cat_name`, `title`, `price`, `thumbnail`, `discount`, `des`, `created_at`, `updated_at`, `quantity`) " +
                    "VALUES(@cat_name, @tit, @price, @thumb, @dis, @des, @ca, @ua, @quan)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("cat_name", pro.cat_name);
                cmd.Parameters.AddWithValue("tit", pro.title);
                cmd.Parameters.AddWithValue("price", pro.price);
                cmd.Parameters.AddWithValue("thumb", pro.thumbnail);
                cmd.Parameters.AddWithValue("dis", pro.discount);
                cmd.Parameters.AddWithValue("des", pro.des);
                cmd.Parameters.AddWithValue("ca", pro.created_at);
                cmd.Parameters.AddWithValue("ua", pro.updated_at);
                cmd.Parameters.AddWithValue("quan", pro.quantity);

                return (cmd.ExecuteNonQuery());
            }
        }

        public Product ViewProduct(string Id)
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
                    pro.created_at = reader["created_at"].ToString() ;
                    pro.updated_at = reader["updated_at"].ToString();
                    pro.quantity = Convert.ToInt32(reader["quantity"]);
                }
            }
            return (pro);
        }

        public int UpdateProduct(Product pro)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "update product set cat_name=@cn, title = @tit, price=@p, " +
                    " des=@d, quantity=@q where pd_ID = @pid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("pid", pro.pd_ID);
                cmd.Parameters.AddWithValue("cn", pro.cat_name);
                cmd.Parameters.AddWithValue("tit", pro.title);
                cmd.Parameters.AddWithValue("p", pro.price);
                cmd.Parameters.AddWithValue("tn", pro.thumbnail);
                cmd.Parameters.AddWithValue("d", pro.des);
                cmd.Parameters.AddWithValue("q", pro.quantity);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int DeleteProduct(string id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from product where pd_ID=@pid";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("pid", id);

                return (cmd.ExecuteNonQuery());

            }
        }
    }
}
