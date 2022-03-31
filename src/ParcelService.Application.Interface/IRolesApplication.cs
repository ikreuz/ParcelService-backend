using ParcelService.Application.DTO;
using ParcelService.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Application.Interface
{
    public interface IRolesApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(RolesDto rolesDto);
        Response<bool> Update(RolesDto rolesDto);
        Response<bool> Delete(string rolesId);

        Response<RolesDto> Get(string rolesId);
        Response<IEnumerable<RolesDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(RolesDto rolesDto);
        Task<Response<bool>> UpdateAsync(RolesDto rolesDto);
        Task<Response<bool>> DeleteAsync(string rolesId);

        Task<Response<RolesDto>> GetAsync(string rolesId);
        Task<Response<IEnumerable<RolesDto>>> GetAllAsync();
        #endregion
    }
}