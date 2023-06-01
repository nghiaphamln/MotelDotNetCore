using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MotelDotNetCore.Models;
using Repositories.Repositories.UserRepository;

namespace MotelDotNetCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserRepository _userRepository;

    public HomeController(
        ILogger<HomeController> logger,
        IUserRepository userRepository
    )
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("User enter a index of website");
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("user-info")]
    public async Task<IActionResult> UserInfo(string username)
    {
        return Ok(new
        {
            Info = await _userRepository.UserInfo(username)
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}