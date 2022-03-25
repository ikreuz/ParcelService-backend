using Dapper;
using Microsoft.Extensions.Configuration;
using ParcelService.CrossCutting.Common;
using ParcelService.Domain.Entity;
using ParcelService.Infrastructure.Interface;
using System.Data;

namespace ParcelService.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IConnectionFactory _connectionFactory;
        protected string _connectionString;
        public UsersRepository(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            _connectionFactory = connectionFactory; _configuration = configuration;
        }

        public Users Authenticate(string userName)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                // Sql Server
                //var query = "UsersGetByUserAndPassword";
                //var parameters = new DynamicParameters();
                //parameters.Add("UserName", userName);
                //parameters.Add("Password", password);
                //var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
                //return user;

                // Postgresql
                var query = "fn_login";

                DynamicParameters param = new DynamicParameters();

                param.Add("@_user_name", userName);

                var user = connection.QueryFirstOrDefault<Users>(query, param,
                    commandType: CommandType.StoredProcedure);

                return user;
            }

        }
    }
}
