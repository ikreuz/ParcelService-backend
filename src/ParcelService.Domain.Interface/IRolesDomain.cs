using ParcelService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Domain.Interface
{
    public interface IRolesDomain
    {
        #region Synchronous Methods
        bool Insert(Roles roles);
        bool Update(Roles roles);
        bool Delete(string roleId);

        Roles Get(string roleId);
        IEnumerable<Roles> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Roles roles);
        Task<bool> UpdateAsync(Roles roles);
        Task<bool> DeleteAsync(string roleId);

        Task<Roles> GetAsync(string roleId);
        Task<IEnumerable<Roles>> GetAllAsync();
        #endregion

    }
}
