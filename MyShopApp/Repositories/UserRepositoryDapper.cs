using MyShopApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopApp.Repositories
{
    public class UserRepositoryDapper : Repository
    {
        public UserRepositoryDapper(string connectionString) : base(connectionString)
        {
        }

        public User GetUserByLogin(string login)
        {
            string sql = "SELECT * FROM Users WHERE Login = @Login";
            return QuerySingleOrDefault<User>(sql, new { Login = login });
        }

        public void InsertUser(User user)
        {
            string sql = "INSERT INTO Users (Login, Password) VALUES (@Login, @Password)";
            Execute(sql, user);
        }

      
    }
}
