using Microsoft.Data.SqlClient;
using MyShopApp.Classes;
using System;
using Dapper;
namespace MyShopApp.Repositories
{
    public class UserRepositoryDapper : Repository
    {
        private const string connectionString = "Server=localhost;Database=MyShopDb;Trusted_Connection=True;TrustServerCertificate=True;";
        private SqlConnection connection;
        public UserRepositoryDapper() : base(connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }


        public User Login(string login, string password)
        {
            ArgumentNullException.ThrowIfNull(login, nameof(login));
            ArgumentNullException.ThrowIfNull(password, nameof(password));
            var query = "SELECT TOP 1 * FROM Users WHERE [Login] = @Login AND [Password] = @Password";
            var user = this.connection.QueryFirstOrDefault<User>(sql: query, new { Login = login, Password = password });
            return user;
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
