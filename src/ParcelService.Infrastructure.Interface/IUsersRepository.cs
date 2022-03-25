using ParcelService.Domain.Entity;

namespace ParcelService.Infrastructure.Interface
{
    public interface IUsersRepository
    {
        Users Authenticate(string username);
    }
}
