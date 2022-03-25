using ParcelService.Domain.Entity;

namespace ParcelService.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username);
    }
}
