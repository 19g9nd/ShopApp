
using System;

namespace MyShopApp.Classes
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
      public bool isAdmin { get; set; }
        public User(string login, string password, string email, bool isAmin)
        {
            Login = login;
            Password = password;
            Email = email;
            this.isAdmin = isAmin;
        }
        public User()
        {

        }
    }


}
