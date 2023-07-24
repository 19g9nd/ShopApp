
using System;

namespace MyShopApp.Classes
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
      public bool isAdmin { get; set; }
        public decimal? Balance { get; set; }
        public User(string login, string password, string email, bool isAdmin)
        {
            Login = login;
            Password = password;
            Email = email;
            this.isAdmin = isAdmin;
        }
        public User()
        {
            this.Login = "Unknown";
            this.Password = "Unknown";
            this.Email = "Unknown";
            this.isAdmin = false;
        }

        public override string ToString()
        {
            var maskedPass = "";

                foreach (var item in this.Password)
            {
                maskedPass += "*";
            }

            return $"#[{this.Id} {maskedPass} {this.Email} {this.isAdmin}]";
        }
    }


}
