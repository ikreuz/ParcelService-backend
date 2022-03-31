using ParcelService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Infrastructure.Interface
{
    public interface IRolesRepository
    {
        #region Synchronous Methods
        bool Insert(Roles roles);
        bool Update(Roles roles);
        bool Delete(string rolesId);

        Roles Get(string rolesId);
        IEnumerable<Roles> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(Roles roles);
        Task<bool> UpdateAsync(Roles roles);
        Task<bool> DeleteAsync(string rolesId);

        Task<Roles> GetAsync(string rolesId);
        Task<IEnumerable<Roles>> GetAllAsync();
        #endregion
    }
}
