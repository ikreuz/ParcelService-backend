using ParcelService.Application.DTO;
using ParcelService.CrossCutting.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParcelService.Application.Interface
{
    public interface IUserDataApplication
    {
        #region Synchronous Methods
        Response<bool> Insert(UserDataDto userDataDto);
        Response<bool> Update(UserDataDto userDataDto);
        Response<bool> Delete(string userDataId);

        Response<UserDataDto> Get(string userDataId);
        Response<IEnumerable<UserDataDto>> GetAll();

        #endregion

        #region Métodos Asíncronos
        Task<Response<bool>> InsertAsync(UserDataDto userDataDto);
        Task<Response<bool>> UpdateAsync(UserDataDto userDataDto);
        Task<Response<bool>> DeleteAsync(string userDataId);

        Task<Response<UserDataDto>> GetAsync(string userDataId);
        Task<Response<IEnumerable<UserDataDto>>> GetAllAsync();
        #endregion
    }
}
