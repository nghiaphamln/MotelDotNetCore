using Microsoft.Extensions.Logging;
using Models.Entities;
using Repositories.Repositories.UserRepository;

namespace Logics.UserLogic;

public class UserLogic : IUserLogic
{
    private readonly ILogger<UserLogic> _logger;
    private readonly IUserRepository _userRepository;

    public UserLogic(
        ILogger<UserLogic> logger,
        IUserRepository userRepository
    )
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<UserEntity?> UserInfo(string username)
    {
        _logger.LogInformation("UserLogic => UserInfo: {Username}", username);
        return await _userRepository.UserInfo(username);
    }
}