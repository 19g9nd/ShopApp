using System.Data;

using Dapper;
using Microsoft.Data.SqlClient;

namespace MyShopApp.Repositories
{

    public class Repository
    {
        private readonly IDbConnection connection;

        public Repository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        protected T QuerySingleOrDefault<T>(string sql, object? parameters)
        {
            return this.connection.QuerySingleOrDefault<T>(sql, parameters);
        }

        protected int Execute(string sql, object? parameters)
        {
            return this.connection.Execute(sql, parameters);
        }
    }
}
