using Dapper;
using ParcelService.CrossCutting.Common;
using ParcelService.Domain.Entity;
using ParcelService.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ParcelService.Infrastructure.Repository
{
    public class RolesRepository : IRolesRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public RolesRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_insert_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);


                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_update_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_delete_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Roles Get(string rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var customer = connection.QuerySingle<Roles>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Roles> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_all_roles";

                var roles = connection.Query<Roles>(query, commandType: CommandType.StoredProcedure);
                return roles;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_insert_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Roles roles)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_update_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", roles.Role_Id);
                parameters.Add("@_role_name", roles.Role_Name);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_delete_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Roles> GetAsync(string rolesId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_roles";
                var parameters = new DynamicParameters();
                parameters.Add("@_role_id", rolesId);

                var customer = await connection.QuerySingleAsync<Roles>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_all_roles";

                var roles = await connection.QueryAsync<Roles>(query, commandType: CommandType.StoredProcedure);
                return roles;
            }
        }
        #endregion
    }
}
