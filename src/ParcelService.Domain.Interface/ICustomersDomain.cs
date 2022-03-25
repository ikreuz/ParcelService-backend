using ParcelService.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParcelService.Domain.Interface
{
    public interface ICustomersDomain
    {
        #region Synchronous Methods
        bool Insert(Customers customers);
        bool Update(Customers customers);
        bool Delete(string customerId);

        Customers Get(string customerId);
        IEnumerable<Customers> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Customers customers);
        Task<bool> UpdateAsync(Customers customers);
        Task<bool> DeleteAsync(string customerId);

        Task<Customers> GetAsync(string customerId);
        Task<IEnumerable<Customers>> GetAllAsync();
        #endregion
    }
}
