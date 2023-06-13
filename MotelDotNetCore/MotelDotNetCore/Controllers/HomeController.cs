using System.Diagnostics;
using Helpers;
using Logics.UserLogic;
using Microsoft.AspNetCore.Mvc;
using MotelDotNetCore.Models;
using Repositories.Repositories.UserRepository;

namespace MotelDotNetCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserLogic _userLogic;

    public HomeController(
        ILogger<HomeController> logger,
        IUserLogic userLogic
    )
    {
        _logger = logger;
        _userLogic = userLogic;
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
            Info = await _userLogic.UserInfo(username)
        });
    }

    [HttpGet("get-env")]
    public IActionResult GetEnv(string env)
    {
        return Ok(new
        {
            Data = AppSettings.Get(env)
        });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}