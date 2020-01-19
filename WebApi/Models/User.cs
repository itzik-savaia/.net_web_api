using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role_option_1 { get; set; }
        public string role_option_2 { get; set; }

        public User()
        {

        }

    }
}
