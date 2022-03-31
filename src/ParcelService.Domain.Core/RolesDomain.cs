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
    public class RolesDomain : IRolesDomain
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesDomain(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        #region Synchronous Methods

        public bool Insert(Roles roles)
        {
            return _rolesRepository.Insert(roles);
        }

        public bool Update(Roles roles)
        {
            return _rolesRepository.Update(roles);
        }

        public bool Delete(string rolesId)
        {
            return _rolesRepository.Delete(rolesId);
        }

        public Roles Get(string rolesId)
        {
            return _rolesRepository.Get(rolesId);
        }

        public IEnumerable<Roles> GetAll()
        {
            return _rolesRepository.GetAll();
        }

        #endregion

        #region Asynchronous Methods

        public async Task<bool> InsertAsync(Roles roles)
        {
            return await _rolesRepository.InsertAsync(roles);
        }

        public async Task<bool> UpdateAsync(Roles roles)
        {
            return await _rolesRepository.UpdateAsync(roles);
        }

        public async Task<bool> DeleteAsync(string rolesId)
        {
            return await _rolesRepository.DeleteAsync(rolesId);
        }

        public async Task<Roles> GetAsync(string rolesId)
        {
            return await _rolesRepository.GetAsync(rolesId);
        }

        public async Task<IEnumerable<Roles>> GetAllAsync()
        {
            return await _rolesRepository.GetAllAsync();
        }

        #endregion
    }
}
