using ParcelService.Application.DTO;
using ParcelService.CrossCutting.Common;

namespace ParcelService.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
