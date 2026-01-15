using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagementSystem
{
    public static class CurrentUser
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string Role { get; private set; }

        public static bool IsAdmin => Role == "Admin";

        public static void Set(int userId, string username, string role)
        {
            UserId = userId;
            Username = username;
            Role = role;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
        }
    }
  
}
