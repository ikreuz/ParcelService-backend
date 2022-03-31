using Dapper;
using ParcelService.CrossCutting.Common;
using ParcelService.Domain.Entity;
using ParcelService.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ParcelService.Infrastructure.Repository
{
    public class UserDataRepository : IUserDataRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public UserDataRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(UserData userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_insert_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_user_id", userData.User_Id);
                parameters.Add("@_role_id", userData.Role_Id);
                parameters.Add("@_role_name", userData.Role_Name);
                parameters.Add("@_app_user", userData.App_User);
                parameters.Add("@_firstnama", userData.Firstname);
                parameters.Add("@_lastname", userData.Lastname);
                parameters.Add("@_username", userData.Username);
                parameters.Add("@_email", userData.Email);
                parameters.Add("@_activity_status", userData.Activity_Status);
                parameters.Add("@_app_user_type", userData.App_User_Type);
                parameters.Add("@_app_user_type_txt", userData.App_User_Type_Txt);
                parameters.Add("@_date_creation", userData.Date_Creation);
                parameters.Add("@_date_modification", userData.Date_Modification);
                parameters.Add("@_usr_creates_id", userData.Usr_Creates_Id);
                parameters.Add("@_usr_creates", userData.Usr_Creates);
                parameters.Add("@_usr_modifies_id", userData.Usr_Modifies_Id);
                parameters.Add("@_usr_modifies", userData.Usr_Modifies);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(UserData userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_update_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_user_id", userData.User_Id);
                parameters.Add("@_role_id", userData.Role_Id);
                parameters.Add("@_role_name", userData.Role_Name);
                parameters.Add("@_app_user", userData.App_User);
                parameters.Add("@_firstnama", userData.Firstname);
                parameters.Add("@_lastname", userData.Lastname);
                parameters.Add("@_username", userData.Username);
                parameters.Add("@_email", userData.Email);
                parameters.Add("@_activity_status", userData.Activity_Status);
                parameters.Add("@_app_user_type", userData.App_User_Type);
                parameters.Add("@_app_user_type_txt", userData.App_User_Type_Txt);
                parameters.Add("@_date_creation", userData.Date_Creation);
                parameters.Add("@_date_modification", userData.Date_Modification);
                parameters.Add("@_usr_creates_id", userData.Usr_Creates_Id);
                parameters.Add("@_usr_creates", userData.Usr_Creates);
                parameters.Add("@_usr_modifies_id", userData.Usr_Modifies_Id);
                parameters.Add("@_usr_modifies", userData.Usr_Modifies);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_delete_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public UserData Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var customer = connection.QuerySingle<UserData>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<UserData> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_all_users";

                var userData = connection.Query<UserData>(query, commandType: CommandType.StoredProcedure);
                return userData;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(UserData userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_insert_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_user_id", userData.User_Id);
                parameters.Add("@_role_id", userData.Role_Id);
                parameters.Add("@_role_name", userData.Role_Name);
                parameters.Add("@_app_user", userData.App_User);
                parameters.Add("@_firstnama", userData.Firstname);
                parameters.Add("@_lastname", userData.Lastname);
                parameters.Add("@_username", userData.Username);
                parameters.Add("@_email", userData.Email);
                parameters.Add("@_activity_status", userData.Activity_Status);
                parameters.Add("@_app_user_type", userData.App_User_Type);
                parameters.Add("@_app_user_type_txt", userData.App_User_Type_Txt);
                parameters.Add("@_date_creation", userData.Date_Creation);
                parameters.Add("@_date_modification", userData.Date_Modification);
                parameters.Add("@_usr_creates_id", userData.Usr_Creates_Id);
                parameters.Add("@_usr_creates", userData.Usr_Creates);
                parameters.Add("@_usr_modifies_id", userData.Usr_Modifies_Id);
                parameters.Add("@_usr_modifies", userData.Usr_Modifies);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(UserData userData)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_update_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_user_id", userData.User_Id);
                parameters.Add("@_role_id", userData.Role_Id);
                parameters.Add("@_role_name", userData.Role_Name);
                parameters.Add("@_app_user", userData.App_User);
                parameters.Add("@_firstnama", userData.Firstname);
                parameters.Add("@_lastname", userData.Lastname);
                parameters.Add("@_username", userData.Username);
                parameters.Add("@_email", userData.Email);
                parameters.Add("@_activity_status", userData.Activity_Status);
                parameters.Add("@_app_user_type", userData.App_User_Type);
                parameters.Add("@_app_user_type_txt", userData.App_User_Type_Txt);
                parameters.Add("@_date_creation", userData.Date_Creation);
                parameters.Add("@_date_modification", userData.Date_Modification);
                parameters.Add("@_usr_creates_id", userData.Usr_Creates_Id);
                parameters.Add("@_usr_creates", userData.Usr_Creates);
                parameters.Add("@_usr_modifies_id", userData.Usr_Modifies_Id);
                parameters.Add("@_usr_modifies", userData.Usr_Modifies);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_delete_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<UserData> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_users";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var customer = await connection.QuerySingleAsync<UserData>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<UserData>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_all_users";

                var userData = await connection.QueryAsync<UserData>(query, commandType: CommandType.StoredProcedure);
                return userData;
            }
        }
        #endregion
    }
}
