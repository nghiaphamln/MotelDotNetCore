using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Entities;
using Repositories.Data;

namespace Repositories.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ILogger<UserRepository> logger)
    {
        _logger = logger;
    }

    public async Task<UserEntity?> UserInfo(string username)
    {
        _logger.LogInformation("UserRepository => UserInfo: {Username}", username);
        await using var context = new ApplicationDbContext();
        return await context.UserEntities.FirstOrDefaultAsync(user => user.UserName.Equals(username));
    }
}