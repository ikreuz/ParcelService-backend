using ParcelService.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Infrastructure.Interface
{
    public interface IUserDataRepository
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
        Task<bool> DeleteAsync(string userDataId);

        Task<UserData> GetAsync(string userDataId);
        Task<IEnumerable<UserData>> GetAllAsync();
        #endregion
    }
}
