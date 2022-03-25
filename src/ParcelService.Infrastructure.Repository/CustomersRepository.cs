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
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Customer_Id", customers.Customer_Id);
                parameters.Add("User_Access", customers.User_Access);
                parameters.Add("Branchoffice_Id", customers.Branchoffice_Id);
                parameters.Add("Third_Type_Id", customers.Third_Type_Id);
                parameters.Add("FirstName", customers.FirstName);
                parameters.Add("MiddleName", customers.MiddleName);
                parameters.Add("LastName", customers.LastName);
                parameters.Add("TradeName", customers.TradeName);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("Rfc", customers.Rfc);
                parameters.Add("Email", customers.Email);
                parameters.Add("Area_Code", customers.Area_Code);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Customer_Type_Id", customers.Customer_Type_Id);
                parameters.Add("With_Agreement", customers.With_Agreement);
                parameters.Add("Date_Creates", customers.Date_Creates);
                parameters.Add("Date_Modifies", customers.Date_Modifies);
                parameters.Add("Date_Authorizes", customers.Date_Authorizes);
                parameters.Add("Usr_Creates_Id", customers.Usr_Creates_Id);
                parameters.Add("Usr_Modifies_id", customers.Usr_Modifies_id);
                parameters.Add("Usr_Authorizes_Id", customers.Usr_Authorizes_Id);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Update(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("Customer_Id", customers.Customer_Id);
                parameters.Add("User_Access", customers.User_Access);
                parameters.Add("Branchoffice_Id", customers.Branchoffice_Id);
                parameters.Add("Third_Type_Id", customers.Third_Type_Id);
                parameters.Add("FirstName", customers.FirstName);
                parameters.Add("MiddleName", customers.MiddleName);
                parameters.Add("LastName", customers.LastName);
                parameters.Add("TradeName", customers.TradeName);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("Rfc", customers.Rfc);
                parameters.Add("Email", customers.Email);
                parameters.Add("Area_Code", customers.Area_Code);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Customer_Type_Id", customers.Customer_Type_Id);
                parameters.Add("With_Agreement", customers.With_Agreement);
                parameters.Add("Date_Creates", customers.Date_Creates);
                parameters.Add("Date_Modifies", customers.Date_Modifies);
                parameters.Add("Date_Authorizes", customers.Date_Authorizes);
                parameters.Add("Usr_Creates_Id", customers.Usr_Creates_Id);
                parameters.Add("Usr_Modifies_id", customers.Usr_Modifies_id);
                parameters.Add("Usr_Authorizes_Id", customers.Usr_Authorizes_Id);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public Customers Get(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }

        public IEnumerable<Customers> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersList";

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
                var query = "CustomersInsert";
                var parameters = new DynamicParameters();
                parameters.Add("Customer_Id", customers.Customer_Id);
                parameters.Add("User_Access", customers.User_Access);
                parameters.Add("Branchoffice_Id", customers.Branchoffice_Id);
                parameters.Add("Third_Type_Id", customers.Third_Type_Id);
                parameters.Add("FirstName", customers.FirstName);
                parameters.Add("MiddleName", customers.MiddleName);
                parameters.Add("LastName", customers.LastName);
                parameters.Add("TradeName", customers.TradeName);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("Rfc", customers.Rfc);
                parameters.Add("Email", customers.Email);
                parameters.Add("Area_Code", customers.Area_Code);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Customer_Type_Id", customers.Customer_Type_Id);
                parameters.Add("With_Agreement", customers.With_Agreement);
                parameters.Add("Date_Creates", customers.Date_Creates);
                parameters.Add("Date_Modifies", customers.Date_Modifies);
                parameters.Add("Date_Authorizes", customers.Date_Authorizes);
                parameters.Add("Usr_Creates_Id", customers.Usr_Creates_Id);
                parameters.Add("Usr_Modifies_id", customers.Usr_Modifies_id);
                parameters.Add("Usr_Authorizes_Id", customers.Usr_Authorizes_Id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("Customer_Id", customers.Customer_Id);
                parameters.Add("User_Access", customers.User_Access);
                parameters.Add("Branchoffice_Id", customers.Branchoffice_Id);
                parameters.Add("Third_Type_Id", customers.Third_Type_Id);
                parameters.Add("FirstName", customers.FirstName);
                parameters.Add("MiddleName", customers.MiddleName);
                parameters.Add("LastName", customers.LastName);
                parameters.Add("TradeName", customers.TradeName);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("Rfc", customers.Rfc);
                parameters.Add("Email", customers.Email);
                parameters.Add("Area_Code", customers.Area_Code);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Customer_Type_Id", customers.Customer_Type_Id);
                parameters.Add("With_Agreement", customers.With_Agreement);
                parameters.Add("Date_Creates", customers.Date_Creates);
                parameters.Add("Date_Modifies", customers.Date_Modifies);
                parameters.Add("Date_Authorizes", customers.Date_Authorizes);
                parameters.Add("Usr_Creates_Id", customers.Usr_Creates_Id);
                parameters.Add("Usr_Modifies_id", customers.Usr_Modifies_id);
                parameters.Add("Usr_Authorizes_Id", customers.Usr_Authorizes_Id);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersDelete";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

                var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "CustomersGetByID";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customerId);

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
