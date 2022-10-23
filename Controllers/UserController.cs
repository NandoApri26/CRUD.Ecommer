using System;
using Microsoft.AspNetCore.Mvc;
using Ecommer.Models;
using Ecommer.Models.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Ecommer.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly AppDbContext _dbContext;
    private IEnumerable<Claim>? claims;

    public UserController(ILogger<UserController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    public IActionResult Login()
    {
        return View(new LoginRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if(!ModelState.IsValid){
            return View(request);
        }
        var user = _dbContext.Users.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);

        if(user == null){
            ViewBag.ErrorMessage = "Invalid Username or Password";
            return View(request);
        }
        if(user.Tipe == "Pembeli"){
            ViewBag.ErrorMessage = "You'r not admin or seller";
            return View(request);
        }

        var claim = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("fullName",user.Username),
            new Claim(ClaimTypes.Role, user.Tipe),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
        
        var authProperties = new AuthenticationProperties{

        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync();

        return RedirectToAction("Login");
    }
}