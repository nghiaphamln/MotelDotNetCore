using Models.Entities;

namespace Logics.UserLogic;

public interface IUserLogic
{
    Task<UserEntity?> UserInfo(string username);
}