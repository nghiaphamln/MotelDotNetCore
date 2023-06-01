using Models.Entities;

namespace Repositories.Repositories.UserRepository;

public interface IUserRepository
{
    Task<UserEntity?> UserInfo(string username);
}