using ParcelService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Domain.Interface
{
    public interface IUserDataDomain
    {
        #region Synchronous Methods
        bool Insert(UserData userData);
        bool Update(UserData userData);
        bool Delete(string userDataId);

        UserData Get(string userDataId);
        IEnumerable<UserData> GetAll();
        #endregion


        #region Asynchronous Methods
        Task<bool> InsertAsync(UserData userData);
        Task<bool> UpdateAsync(UserData userData);
        Task<bool> DeleteAsync(string roleId);

        Task<UserData> GetAsync(string roleId);
        Task<IEnumerable<UserData>> GetAllAsync();
        #endregion

    }
}
