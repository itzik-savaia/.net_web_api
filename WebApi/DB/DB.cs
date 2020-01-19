using MySql.Data.MySqlClient;
using System;
using WebApi.Models;

namespace WebApi.DB
{
    public class DB
    {
        private string connStr { get; set; }
        MySqlConnection conn;
        public DB()
        {

            connStr = "server=localhost;user=root;database=csharpdb;port=3306;password=root";
            conn = new MySqlConnection(connStr);

        }

        public void TryConnection()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "Select * from `csharpdb`.users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");

        }
        //GetUsers
        public User GetUsers()
        {
            User user = new User();
            conn.Open();

            string sql = "SELECT * FROM `csharpdb`.users where id";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.id = Int32.Parse(rdr["id"].ToString());
                user.username = rdr["username"].ToString();
                user.password = rdr["password"].ToString();
                user.role_option_1 = rdr["role_option_1"].ToString();
                user.role_option_2 = rdr["role_option_2"].ToString();
            }

            return user;
        }
        //GetUser
        public User GetUser(int id)
        {
            User user = new User();
            conn.Open();

            string sql = "Select * from `csharpdb`.users where id=" + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                user.id = Int32.Parse(rdr["id"].ToString());
                user.username = rdr["username"].ToString();
                user.password = rdr["password"].ToString();
                user.role_option_1 = rdr["role_option_1"].ToString();
                user.role_option_2 = rdr["role_option_2"].ToString();
            }

            return user;
        }
        //PostUser
        public User PostUser(string username, string password, string role_option_1, string role_option_2)
        {
            User user = new User();
            conn.Open();

            string sql = $"INSERT INTO `csharpdb`.users (`username`, `password`,`role_option_1`, `role_option_2`) " +
                $"VALUES ('{username}', '{password}','{role_option_1}', '{role_option_2}');";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.id = Int32.Parse(rdr["id"].ToString());
                user.username = rdr["username"].ToString();
                user.password = rdr["password"].ToString();
                user.role_option_1 = rdr["role_option_1"].ToString();
                user.role_option_2 = rdr["role_option_2"].ToString();
            }
            return user;
        }
        // PutUser
        public User PutUser(int id, string username, string password, string role_option_1, string role_option_2)
        {
            User user = new User();
            conn.Open();
            string sql = $"UPDATE `csharpdb`.users " +
                $"SET `username` = '{username}', `password` = '{password}', `role_option_1` = '{role_option_1}', `role_option_2` = '{role_option_2}'" +
                $"WHERE `Id` = '{id}';";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.id = Int32.Parse(rdr["id"].ToString());
                user.username = rdr["username"].ToString();
                user.password = rdr["password"].ToString();
                user.role_option_1 = rdr["role_option_1"].ToString();
                user.role_option_2 = rdr["role_option_2"].ToString();
            }
            return user;
        }

        // DeleteUser
        public User DeleteUser(int id)
        {
            User user = new User();
            conn.Open();
            string sql = $"DELETE FROM `csharpdb`.users WHERE `Id` = '{id}';";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                user.id = Int32.Parse(rdr["id"].ToString());
                user.username = rdr["username"].ToString();
                user.password = rdr["password"].ToString();
                user.role_option_1 = rdr["role_option_1"].ToString();
                user.role_option_2 = rdr["role_option_2"].ToString();
            }
            return user;
        }



    }
}
