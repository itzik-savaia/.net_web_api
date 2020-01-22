using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService
    {

        DB.DB db = new DB.DB();
        public UserService()
        {

        }
        //GET all
        public List<User> GetUsers()
        {
            List<User> ListOfUsers = new List<User>();
            //Get from database 
            ListOfUsers = db.GetUsers();

            return ListOfUsers;
        }

        //GET one
        public User GetUser(int id)
        {
            User user = new User();
            //Get from database 
            user = db.GetUser(id);

            return user;
        }
        //POST
        public User PostUser(
            string username,
            string password,
            string role_option_1,
            string role_option_2)
        {
            User user = new User();

            //Post to database
            user = db.PostUser(username, password, role_option_1, role_option_2);

            return user;
        }
        //PUT
        public User PutUser(
            int id,
            string username,
            string password,
            string role_option_1,
            string role_option_2)
        {
            User user = new User();
            //Post to database
            user = db.PutUser(id, username, password, role_option_1, role_option_2);

            return user;
        }
        //DELETE
        public User DeleteUser(int id)
        {
            User user = new User();
            //Delte to database
            user = db.DeleteUser(id);
            return user;
        }
    }
}
