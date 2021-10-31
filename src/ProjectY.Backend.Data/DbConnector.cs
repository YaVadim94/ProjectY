using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ProjectY.Backend.Data
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("Postgres");

            return new NpgsqlConnection(connectionString);
        }
    }
}
