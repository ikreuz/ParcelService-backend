using ParcelService.Domain.Entity;
using ParcelService.Domain.Interface;
using ParcelService.Infrastructure.Interface;

namespace ParcelService.Domain.Core
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Users Authenticate(string userName)
        {
            return _usersRepository.Authenticate(userName);
        }

    }
}
