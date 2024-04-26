using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _20240426
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IPAddress BlockedIP { get; set; }
        public int LoginAttempts { get; set; }
    }

    public static class UserDatabase
    {
        private static List<User> users = new List<User>
        {
            new User { Username = "user1", Password = "password1" },
            new User { Username = "user2", Password = "password2" }
        };

        public static User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }
    }
}
