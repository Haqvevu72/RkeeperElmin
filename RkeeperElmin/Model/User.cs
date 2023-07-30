using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    internal class User
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username{ get; set; }
        public string Password { get; set; }
    }
}
