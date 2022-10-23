using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ecommer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Ecommer.Controllers;

public class RegisterController : Controller
{
    private readonly ILogger<RegisterController> _logger;
    private readonly AppDbContext _dbContext;
    private IEnumerable<Claim> claims;

    public RegisterController(ILogger<RegisterController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IActionResult Register(){
        return View();
    }

}

