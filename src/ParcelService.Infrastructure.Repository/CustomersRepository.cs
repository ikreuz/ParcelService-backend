using Dapper;
using ParcelService.CrossCutting.Common;
using ParcelService.Domain.Entity;
using ParcelService.Infrastructure.Interface;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ParcelService.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        public readonly IConnectionFactory _connectionFactory;

        public CustomersRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #region Synchronous Methods

        public bool Insert(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_insert_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customers.Customer_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_branch_office_id", customers.Branch_Office_Id);
                parameters.Add("@_third_type_id", customers.Third_Type_Id);
                parameters.Add("@_firstname", customers.Firtsname);
                parameters.Add("@_lastname", customers.Lastname);
                parameters.Add("@_business_name", customers.Business_Name);
                parameters.Add("@_company_name", customers.Company_Name);
                parameters.Add("@_rfc", customers.Rfc);
                parameters.Add("@_email", customers.Email);
                parameters.Add("@_area_code", customers.Area_Code);
                parameters.Add("@_phone", customers.Phone);
                parameters.Add("@_customer_type_id", customers.Customer_Type_Id);
                parameters.Add("@_with_agreement", customers.With_Agreement);
                parameters.Add("@_date_creation", customers.Date_Creation);
                parameters.Add("@_date_modification", customers.Date_Modification);
                parameters.Add("@_date_authorization", customers.Date_Authorization);
                parameters.Add("@_usr_creates_id", customers.Usr_Creates_Id);
                parameters.Add("@_usr_modifies_id", customers.Usr_Modifies_Id);
                parameters.Add("@_usr_authorizes_id", customers.Usr_Authorizes_Id);
                

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_update_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customers.Customer_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_branch_office_id", customers.Branch_Office_Id);
                parameters.Add("@_third_type_id", customers.Third_Type_Id);
                parameters.Add("@_firstname", customers.Firtsname);
                parameters.Add("@_lastname", customers.Lastname);
                parameters.Add("@_business_name", customers.Business_Name);
                parameters.Add("@_company_name", customers.Company_Name);
                parameters.Add("@_rfc", customers.Rfc);
                parameters.Add("@_email", customers.Email);
                parameters.Add("@_area_code", customers.Area_Code);
                parameters.Add("@_phone", customers.Phone);
                parameters.Add("@_customer_type_id", customers.Customer_Type_Id);
                parameters.Add("@_with_agreement", customers.With_Agreement);
                parameters.Add("@_date_creation", customers.Date_Creation);
                parameters.Add("@_date_modification", customers.Date_Modification);
                parameters.Add("@_date_authorization", customers.Date_Authorization);
                parameters.Add("@_usr_creates_id", customers.Usr_Creates_Id);
                parameters.Add("@_usr_modifies_id", customers.Usr_Modifies_Id);
                parameters.Add("@_usr_authorizes_id", customers.Usr_Authorizes_Id);
                

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_delete_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_all_customers";

                var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion


        #region Asynchronous Methods
        public async Task<bool> InsertAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_insert_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customers.Customer_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_branch_office_id", customers.Branch_Office_Id);
                parameters.Add("@_third_type_id", customers.Third_Type_Id);
                parameters.Add("@_firstname", customers.Firtsname);
                parameters.Add("@_lastname", customers.Lastname);
                parameters.Add("@_business_name", customers.Business_Name);
                parameters.Add("@_company_name", customers.Company_Name);
                parameters.Add("@_rfc", customers.Rfc);
                parameters.Add("@_email", customers.Email);
                parameters.Add("@_area_code", customers.Area_Code);
                parameters.Add("@_phone", customers.Phone);
                parameters.Add("@_customer_type_id", customers.Customer_Type_Id);
                parameters.Add("@_with_agreement", customers.With_Agreement);
                parameters.Add("@_date_creation", customers.Date_Creation);
                parameters.Add("@_date_modification", customers.Date_Modification);
                parameters.Add("@_date_authorization", customers.Date_Authorization);
                parameters.Add("@_usr_creates_id", customers.Usr_Creates_Id);
                parameters.Add("@_usr_modifies_id", customers.Usr_Modifies_Id);
                parameters.Add("@_usr_authorizes_id", customers.Usr_Authorizes_Id);
                

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_update_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customers.Customer_Id);
                parameters.Add("@_user_access_id", customers.User_Access_Id);
                parameters.Add("@_branch_office_id", customers.Branch_Office_Id);
                parameters.Add("@_third_type_id", customers.Third_Type_Id);
                parameters.Add("@_firstname", customers.Firtsname);
                parameters.Add("@_lastname", customers.Lastname);
                parameters.Add("@_business_name", customers.Business_Name);
                parameters.Add("@_company_name", customers.Company_Name);
                parameters.Add("@_rfc", customers.Rfc);
                parameters.Add("@_email", customers.Email);
                parameters.Add("@_area_code", customers.Area_Code);
                parameters.Add("@_phone", customers.Phone);
                parameters.Add("@_customer_type_id", customers.Customer_Type_Id);
                parameters.Add("@_with_agreement", customers.With_Agreement);
                parameters.Add("@_date_creation", customers.Date_Creation);
                parameters.Add("@_date_modification", customers.Date_Modification);
                parameters.Add("@_date_authorization", customers.Date_Authorization);
                parameters.Add("@_usr_creates_id", customers.Usr_Creates_Id);
                parameters.Add("@_usr_modifies_id", customers.Usr_Modifies_Id);
                parameters.Add("@_usr_authorizes_id", customers.Usr_Authorizes_Id);
                

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_delete_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "fn_get_customers";
                var parameters = new DynamicParameters();
                parameters.Add("@_customer_id", customerId);

                var customer = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";

                var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        #endregion
    }
}
