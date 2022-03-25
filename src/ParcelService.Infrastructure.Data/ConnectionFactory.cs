using Microsoft.Extensions.Configuration;
using Npgsql;
using ParcelService.CrossCutting.Common;
using System.Data;

namespace ParcelService.Infrastructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;
        protected string _connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public IDbConnection GetConnection
        {
            get
            {
                // Sql Server
                //var sqlConnection = new SqlConnection();
                //if (sqlConnection == null) return null;
                //sqlConnection.ConnectionString = _configuration.GetConnectionString("DBNorthwnd");
                //if (_configuration == null)
                //    throw new ArgumentNullException("configuration");
                //sqlConnection.Open();
                //return sqlConnection;

                _connectionString = _configuration.GetSection("ConnectionStrings").GetSection("DBParcelService").Value;

                NpgsqlConnection conn = new NpgsqlConnection(_connectionString);

                conn.Open();

                return conn;
            }
        }
    }
}