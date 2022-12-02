using MySql.Data.MySqlClient;
using System.Collections.Generic;

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
                var str = "select * from USER where username=@username and password=@password and role='0'";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                            username = reader["username"].ToString(),
                            password = reader["password"].ToString(),
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
