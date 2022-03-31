using ParcelService.Domain.Entity;
using ParcelService.Domain.Interface;
using ParcelService.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Domain.Core
{
    public class UserDataDomain : IUserDataDomain
    {
        private readonly IUserDataRepository _userDataRepository;

        public UserDataDomain(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        #region Synchronous Methods

        public bool Insert(UserData roles)
        {
            return _userDataRepository.Insert(roles);
        }

        public bool Update(UserData roles)
        {
            return _userDataRepository.Update(roles);
        }

        public bool Delete(string rolesId)
        {
            return _userDataRepository.Delete(rolesId);
        }

        public UserData Get(string rolesId)
        {
            return _userDataRepository.Get(rolesId);
        }

        public IEnumerable<UserData> GetAll()
        {
            return _userDataRepository.GetAll();
        }

        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(UserData roles)
        {
            return await _userDataRepository.InsertAsync(roles);
        }

        public async Task<bool> UpdateAsync(UserData roles)
        {
            return await _userDataRepository.UpdateAsync(roles);
        }

        public async Task<bool> DeleteAsync(string rolesId)
        {
            return await _userDataRepository.DeleteAsync(rolesId);
        }

        public async Task<UserData> GetAsync(string rolesId)
        {
            return await _userDataRepository.GetAsync(rolesId);
        }

        public async Task<IEnumerable<UserData>> GetAllAsync()
        {
            return await _userDataRepository.GetAllAsync();
        }

        #endregion
    }
}
